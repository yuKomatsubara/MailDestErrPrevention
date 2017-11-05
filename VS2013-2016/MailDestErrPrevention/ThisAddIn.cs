using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

namespace MailDestErrPrevention
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.ItemSend += Application_ItemSend;
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            // 変数定義
            string currentAddress;
            List<string> DestinationAddressList;
            confirmDialog cnfDialog = new confirmDialog();


            if (true)
            {
                Outlook.MailItem CurrentMail = Item as Outlook.MailItem;

                // 各宛先についてアドレス（currentAddress）を取得し、cnfDialog内のリストへ格納する。
                foreach (Outlook.Recipient currentRecipient in CurrentMail.Recipients) {
                    currentAddress = GetRecipientAddress(currentRecipient);

                    // アドレスごとに宛先のタイプを判定し、「DestinationAddressList」が示すオブジェクトを切りかえる。
                    // MailItem.Typeの実体はOlMailRecipientTypeであり以下の通り対応する。
                    //      olOriginator    0
                    //      olTo			1
                    //		olBCC			3
                    //      olCC			2
                    switch (currentRecipient.Type) {
                        case 1:
                            DestinationAddressList = cnfDialog.ToAddressList;
                            break;
                        case 2:
                            DestinationAddressList = cnfDialog.CcAddressList;
                            break;
                        case 3:
                            DestinationAddressList = cnfDialog.BccAddressList;
                            break;

                        case 0:
                        default:
                            // 送信者アドレスについては何も処理を行わない。
                            continue;
                    }

                    DestinationAddressList.Add(currentAddress);
                }

                // アドインの起動がインストールしてから初めての場合プロパティがnullであるため、オブジェクトを生成する。
                InitProperties();

                // アドレスリストからドメインを抜き出してドメインリストに格納する。
                // （重複排除はExtractDomains内で行っている）
                cnfDialog.ToDomainList = ExtractDomains(cnfDialog.ToAddressList);
                cnfDialog.CcDomainList = ExtractDomains(cnfDialog.CcAddressList);
                cnfDialog.BccDomainList = ExtractDomains(cnfDialog.BccAddressList);


                // cnfDialog側でチェック内容の操作が行えるよう「内部ドメインのみか否か」「添付ファイルが有るか」を渡す。
                cnfDialog.includesExternalDomain = true;

                if (!HasExternalDomain(cnfDialog.ToDomainList) &&
                    !HasExternalDomain(cnfDialog.CcDomainList) &&
                    !HasExternalDomain(cnfDialog.BccDomainList)) {
                    cnfDialog.includesExternalDomain = false;
                }

                if (CurrentMail.Attachments.Count != 0) {
                    cnfDialog.hasAttachment = true;
                } else {
                    cnfDialog.hasAttachment = false;
                }


                // 確認スキップが有効かつ外部ドメインが含まれていない場合、ここでアドインを抜けて送信処理に移る。
                if (cnfDialog.includesExternalDomain == false) {
                    if (Properties.Settings.Default.EnableConfirmationSkip == true) {
                        Cancel = false;
                        return;
                    }
                }


                // 「社内ドメイン」「既知のドメイン」情報を元にリスト内のドメインへ会社名を付与する。
                if (Properties.Settings.Default.InternalDomainList.Count != 0 &&
                    Properties.Settings.Default.KnownDomainList.Count != 0) {

                    cnfDialog.ToDomainList = ConvertKnownDomains(cnfDialog.ToDomainList);
                    cnfDialog.CcDomainList = ConvertKnownDomains(cnfDialog.CcDomainList);
                    cnfDialog.BccDomainList = ConvertKnownDomains(cnfDialog.BccDomainList);
                } else {
                    // 「社内ドメイン」「既知のドメイン」が空の場合は警告を表示し、ドメインに関する処理は行わない。
                    if (Properties.Settings.Default.InternalDomainList.Count == 0) {
                        MessageBox.Show("内部ドメインが登録されていません。右上の「歯車」ボタンからインポートしてください。");
                    }
                    if (Properties.Settings.Default.KnownDomainList.Count == 0) {
                        MessageBox.Show("既知のドメインが登録されていません。右上の「歯車」ボタンからインポートしてください。");
                    }
                }

                // 確認用ダイアログ（confirmDialog.cs）を表示する。
                cnfDialog.ShowDialog();

                // 確認用ダイアログで「送信」が押下された場合のみ送信処理を続ける。
                if (cnfDialog.sendFlag == 1) {
                    Cancel = false;
                } else {
                    Cancel = true;
                }
            }   
        }


        private string GetRecipientAddress(Outlook.Recipient currentRecipient)
        {
            string currentAddress = currentRecipient.Address;
            StringBuilder messageString = new StringBuilder();

            Outlook.OlAddressEntryUserType currentAddressType;

            Outlook.ExchangeUser currentExcUser;
            Outlook.ExchangeDistributionList currentExcDistList;


            if (currentAddress.Contains('@') == true) {
                // Recipient.Address is judged to be a plain e-mail address because it contains '@'.
                // No additional process is needed.
            } else {
                // Recipient.Address does not contain '@'.
                // This Recipient is judged to be a Microsoft Exchange account.

                currentAddressType = currentRecipient.AddressEntry.AddressEntryUserType;

                if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry) {
                    currentExcUser = currentRecipient.AddressEntry.GetExchangeUser();
                    if (currentExcUser == null) {
                        messageString.AppendLine("Failed to get ExchangeUser from olExchangeUserAddressEntry");
                        messageString.AppendLine("currentAddress:");
                        messageString.AppendLine(currentAddress);
                        MessageBox.Show(messageString.ToString());
                    }

                    currentAddress = currentExcUser.PrimarySmtpAddress;
                    if (currentAddress == null) {
                        messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeUserAddressEntry");
                        MessageBox.Show(messageString.ToString());
                    }

                } else if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry) {
                    currentExcUser = currentRecipient.AddressEntry.GetExchangeUser();
                    if (currentExcUser == null) {
                        messageString.AppendLine("Failed to get ExchangeUser from olExchangeRemoteUserAddressEntry");
                        messageString.AppendLine("currentAddress:");
                        messageString.AppendLine(currentAddress);
                        MessageBox.Show(messageString.ToString());
                    }

                    currentAddress = currentExcUser.PrimarySmtpAddress;
                    if (currentAddress == null) {
                        messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeRemoteUserAddressEntry");
                        MessageBox.Show(messageString.ToString());
                    }

                } else if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry) {
                    currentExcDistList = currentRecipient.AddressEntry.GetExchangeDistributionList();
                    if (currentExcDistList == null) {
                        messageString.AppendLine("Failed to get ExchangeUser from olExchangeRemoteUserAddressEntry");
                        messageString.AppendLine("currentAddress:");
                        messageString.AppendLine(currentAddress);
                        MessageBox.Show(messageString.ToString());
                    }

                    currentAddress = currentExcDistList.PrimarySmtpAddress;
                    if (currentAddress == null) {
                        messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeRemoteUserAddressEntry");
                        MessageBox.Show(messageString.ToString());
                    }
                }


            }

            return currentAddress;
        }

        // Listに格納された複数のドメインを受取り、名称を付与したリストを返す。
        private List<string> ConvertKnownDomains(List<string> DomainList)
        {
            List<string> ConvertedList = new List<string>();

            foreach (string currentDomain in DomainList) {
                ConvertedList.Add(ConvertKnownDomain(currentDomain));
            }

            return ConvertedList;
        }

        // ドメインを受け取り、名称を付与した文字列を返す。
        private string ConvertKnownDomain(string currentDomain)
        {
            int Index;
            StringBuilder ReturnString = new StringBuilder();

            // まずはKnownDomainListから調査する。
            if (Properties.Settings.Default.KnownDomainList.Count != 0) {
                for (Index = 0; Index < Properties.Settings.Default.KnownDomainList.Count; Index++) {
                    if (Properties.Settings.Default.KnownDomainList[Index][0].ToLower() == currentDomain.ToLower()) {
                        break;
                    }
                }

                if ((Index >= 0) && (Index < Properties.Settings.Default.KnownDomainList.Count)) {
                    ReturnString.Append(Properties.Settings.Default.KnownDomainList[Index][1].ToString());
                    ReturnString.Append(" (");
                } else {
                    // KnownDomainListに無ければInternalDomainListを調査する。
                    if (Properties.Settings.Default.InternalDomainList.Count != 0) {
                        for (Index = 0; Index < Properties.Settings.Default.InternalDomainList.Count; Index++) {
                            if (Properties.Settings.Default.InternalDomainList[Index][0].ToLower() == currentDomain.ToLower()) {
                                break;
                            }
                        }

                        if ((Index >= 0) && (Index < Properties.Settings.Default.InternalDomainList.Count)) {
                            ReturnString.Append(Properties.Settings.Default.InternalDomainList[Index][1].ToString());
                            ReturnString.Append(" (");
                        } else {
                            // KnownDomainListにもInternalDomainListにも含まれなかった場合「未登録のドメイン」と表示する。
                            ReturnString.Append("未登録のドメイン (");
                        }

                    }
                }

                ReturnString.Append(currentDomain);
                ReturnString.Append(")");
            }

            return ReturnString.ToString();
        }

        ////// InitProperties()
        //	Check the List<string> in the properties and initialize if it's null.
        private void InitProperties()
        {
            if (Properties.Settings.Default.InternalDomainList == null) {
                Properties.Settings.Default.EnableConfirmationSkip = false;
                Properties.Settings.Default.InternalDomainList = new List<List<string>>();
                Properties.Settings.Default.KnownDomainList = new List<List<string>>();
            }
        }

        private List<string> ExtractDomains(List<string> AddressList)
        {
            List<string> ReturnDomainList = new List<string>();
            string CurrentDomain;

            foreach (string CurrentAddress in AddressList) {
                // ドメインは全て小文字にしてから処理する。
                CurrentDomain = CurrentAddress.Split('@')[1].ToLower();

                if (ReturnDomainList.Contains(CurrentDomain) == false) {
                    ReturnDomainList.Add(CurrentDomain);
                }
            }

            return ReturnDomainList;
        }

        private bool HasExternalDomain(List<string> DomainList)
        {
            bool ContainsExternalDomain;
            bool NotContainsExternalDomain;
            bool ThisDomainIsInternal;

            if (DomainList.Count == 0) {
                return false;
            } else {
                if (Properties.Settings.Default.InternalDomainList.Count == 0) {
                    // 内部ドメインの登録が無い場合は問答無用で「外部ドメインを含む」と判定。
                    ContainsExternalDomain = true;
                } else {
                    NotContainsExternalDomain = true;

                    foreach (string CurrentDomain in DomainList) {
                        ThisDomainIsInternal = false;

                        foreach (List<string> CurrentInternalDomain in Properties.Settings.Default.InternalDomainList) {
                            if (CurrentInternalDomain[0].Contains(CurrentDomain) == true) {
                                ThisDomainIsInternal = true;
                                break;
                            }
                        }

                        NotContainsExternalDomain &= ThisDomainIsInternal;
                    }

                    ContainsExternalDomain = !NotContainsExternalDomain;
                }

                return ContainsExternalDomain;
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //注: Outlook はこのイベントを発行しなくなりました。Outlook が
            //    を Outlook のシャットダウン時に実行する必要があります。https://go.microsoft.com/fwlink/?LinkId=506785 をご覧ください
        }

        #region VSTO で生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
