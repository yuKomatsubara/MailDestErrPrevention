#define _DEBUG_

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
			bool confirmFlag;
			confirmDialog cnfDialog = new confirmDialog();


			if (true)
//			if (Item.GetType() is Outlook.MailItem)
			{
				Outlook.MailItem CurrentMail = Item as Outlook.MailItem;

				foreach (Outlook.Recipient currentRecipient in CurrentMail.Recipients)
				{
					// 各宛先についてアドレス（currentAddress）を取得する。
					currentAddress = GetRecipientAddress(currentRecipient);

					// アドレスごとに宛先のタイプを判定し、「DestinationAddressList」が示すオブジェクトを切りかえる。
					// MailItem.Typeの実体はOlMailRecipientTypeであり以下の通り対応する。
					//      olOriginator    0
					//      olTo			1
					//		olBCC			3
					//      olCC			2
					switch (currentRecipient.Type)
					{
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

#if _DEBUG_
				MessageBox.Show("[Debug] Finished to gather addresses.");
#endif


				InitProperties();

				cnfDialog.ToDomainList = ExtractDomains(cnfDialog.ToAddressList);
				cnfDialog.CcDomainList = ExtractDomains(cnfDialog.CcAddressList);
				cnfDialog.BccDomainList = ExtractDomains(cnfDialog.BccAddressList);



				// 宛先に社内ドメインしか含まないかつ、設定で確認スキップを許可している場合は確認ダイアログをスキップする機能。
				// ただし、単純なうっかり送信防止機能（例えば、他のウインドウをクリックした積もりで「送信」押しちゃうとか）として
				// 使いたいという要望も想定し、最終的には外部ファイルを読み込んでEnable/Disableを切り替えられるようにする。

				confirmFlag = true;

				if (!HasExternalDomain(cnfDialog.ToDomainList) &&
					!HasExternalDomain(cnfDialog.CcDomainList) &&
					!HasExternalDomain(cnfDialog.BccDomainList))
				{
					confirmFlag = false;
				}


				if (confirmFlag == false)
				{
					if(Properties.Settings.Default.EnableConfirmationSkip == true) {
	#if _DEBUG_
						MessageBox.Show("[Debug] Destination includes only internal domain.\nand EnableConfirmatinSkip is TRUE.\nConfirmation dialog will be skipped.");
	#endif
						Cancel = false;
						return;
					}
					else
					{
	#if _DEBUG_
						MessageBox.Show("[Debug] Destination includes only internal domain.\nbut EnableConfirmatinSkip is FALSE.\nConfirmation dialog will be shown.");
	#endif
					}
				}
				else
				{
	#if _DEBUG_
					MessageBox.Show("[Debug] Destination includes external domain.\nConfirmation dialog will be shown.");
	#endif
				}


				cnfDialog.ToDomainList = ConvertKnownDomains(cnfDialog.ToDomainList);
				cnfDialog.CcDomainList = ConvertKnownDomains(cnfDialog.CcDomainList);
				cnfDialog.BccDomainList = ConvertKnownDomains(cnfDialog.BccDomainList);



				// 確認用ダイアログ（confirmDialog.cs）を表示する。
				cnfDialog.ShowDialog();

				// 確認用ダイアログで「送信」が押下された場合のみ送信処理を続ける。
				if (cnfDialog.sendFlag == 1)
				{
					Cancel = false;
				}
				else
				{
					Cancel = true;
				}
			}   //Item.GetType() is Outlook.MailItem
				/*			else if (Item.GetType() is Outlook.AppointmentItem)
							{
								Outlook.AppointmentItem CurrentMail = Item as Outlook.AppointmentItem;


								return;
							}   //Item.GetType() is Outlook.AppointmentItem
							else
							{
								return;
							}*/

		}


		private string GetRecipientAddress(Outlook.Recipient currentRecipient)
		{
			string currentAddress = currentRecipient.Address;
			StringBuilder messageString = new StringBuilder();

			Outlook.OlAddressEntryUserType currentAddressType;

			Outlook.ExchangeUser currentExcUser;
			Outlook.ExchangeDistributionList currentExcDistList;


			if (currentAddress.Contains('@') == true)
			{
				// Recipient.Address is judged to be a plain e-mail address because it contains '@'.
				// No additional process is needed.
#if _DEBUG_
				messageString.AppendLine("Succeeded to get Address from a non-Exchange address");
				messageString.AppendLine("currentAddress:");
				messageString.AppendLine(currentAddress);
				MessageBox.Show(messageString.ToString());
#endif
			}
			else
			{
				// Recipient.Address does not contain '@'.
				// This Recipient is judged to be a Microsoft Exchange account.

				currentAddressType = currentRecipient.AddressEntry.AddressEntryUserType;

				if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry)
				{
					currentExcUser = currentRecipient.AddressEntry.GetExchangeUser();
					if (currentExcUser == null)
					{
						messageString.AppendLine("Failed to get ExchangeUser from olExchangeUserAddressEntry");
						messageString.AppendLine("currentAddress:");
						messageString.AppendLine(currentAddress);
						MessageBox.Show(messageString.ToString());
					}

					currentAddress = currentExcUser.PrimarySmtpAddress;
					if (currentAddress == null)
					{
						messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeUserAddressEntry");
						MessageBox.Show(messageString.ToString());
					}

#if _DEBUG_
					messageString.AppendLine("Succeeded to get Address from olExchangeUserAddressEntry");
					messageString.AppendLine("Recipient.Address:");
					messageString.AppendLine(currentRecipient.Address.ToString());
					messageString.AppendLine("currentAddress:");
					messageString.AppendLine(currentAddress);
					MessageBox.Show(messageString.ToString());
#endif
				}
				else if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
				{
					currentExcUser = currentRecipient.AddressEntry.GetExchangeUser();
					if (currentExcUser == null)
					{
						messageString.AppendLine("Failed to get ExchangeUser from olExchangeRemoteUserAddressEntry");
						messageString.AppendLine("currentAddress:");
						messageString.AppendLine(currentAddress);
						MessageBox.Show(messageString.ToString());
					}

					currentAddress = currentExcUser.PrimarySmtpAddress;
					if (currentAddress == null)
					{
						messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeRemoteUserAddressEntry");
						MessageBox.Show(messageString.ToString());
					}

#if _DEBUG_
					messageString.AppendLine("Succeeded to get Address from olExchangeRemoteUserAddressEntry");
					messageString.AppendLine("Recipient.Address:");
					messageString.AppendLine(currentRecipient.Address.ToString());
					messageString.AppendLine("currentAddress:");
					messageString.AppendLine(currentAddress);
					MessageBox.Show(messageString.ToString());
#endif
				}
				else if (currentAddressType == Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry)
				{
					currentExcDistList = currentRecipient.AddressEntry.GetExchangeDistributionList();
					if (currentExcDistList == null)
					{
						messageString.AppendLine("Failed to get ExchangeUser from olExchangeRemoteUserAddressEntry");
						messageString.AppendLine("currentAddress:");
						messageString.AppendLine(currentAddress);
						MessageBox.Show(messageString.ToString());
					}

					currentAddress = currentExcDistList.PrimarySmtpAddress;
					if (currentAddress == null)
					{
						messageString.AppendLine("Failed to get PrimarySmtpAddress from olExchangeRemoteUserAddressEntry");
						MessageBox.Show(messageString.ToString());
					}

#if _DEBUG_
					messageString.AppendLine("Succeeded to get Address from olExchangeRemoteUserAddressEntry");
					messageString.AppendLine("Recipient.Address:");
					messageString.AppendLine(currentRecipient.Address.ToString());
					messageString.AppendLine("currentAddress:");
					messageString.AppendLine(currentAddress);
					MessageBox.Show(messageString.ToString());
#endif
				}


			}

			return currentAddress;
		}

		private List<string> ConvertKnownDomains(List<string> DomainList)
		{
			List<string> ConvertedList = new List<string>();

			foreach (string currentDomain in DomainList)
			{
				ConvertedList.Add(ConvertKnownDomain(currentDomain));
			}

			return ConvertedList;
		}

		private string ConvertKnownDomain(string currentDomain)
		{
			int Index;
			StringBuilder ReturnString = new StringBuilder();

			Index = Properties.Settings.Default.KnownDomainList[0].IndexOf(currentDomain);

			if ((Index >= 0) && (Index < Properties.Settings.Default.KnownDomainList.Count))
			{
				ReturnString.Append(Properties.Settings.Default.KnownDomainList[1][Index].ToString());
				ReturnString.Append(" (");
			}
			else
			{
				// currentDomainがKnownDomainList内に無かった場合「未登録のドメイン」と表示する。
				ReturnString.Append("未登録のドメイン (");
			}

			ReturnString.Append(currentDomain);
			ReturnString.Append(")");

			return ReturnString.ToString();
		}

		////// InitProperties()
		//	Check the List<string> in the properties and initialize if it's null.
		private void InitProperties()
		{
			if (Properties.Settings.Default.InternalDomainList == null)
			{
				Properties.Settings.Default.EnableConfirmationSkip = false;
				Properties.Settings.Default.InternalDomainList = new List<List<string>>();
				Properties.Settings.Default.KnownDomainList = new List<List<string>>();
			}
		}

		private List<string> ExtractDomains(List<string> AddressList)
		{
			List<string> ReturnDomainList = new List<string>();
			string CurrentDomain;

			foreach (string CurrentAddress in AddressList)
			{
				CurrentDomain = CurrentAddress.Split('@')[1];

				if (ReturnDomainList.Contains(CurrentDomain) == false)
				{
					ReturnDomainList.Add(CurrentDomain);
				}
			}

			return ReturnDomainList;
		}

		private bool HasExternalDomain(List<string> DomainList)
		{
			bool ContainsExternalDomain;

			if (DomainList.Count == 0) {
				return false;
			} else {
				ContainsExternalDomain = false;

				foreach (string CurrentDomain in DomainList)
				{
					if (Properties.Settings.Default.InternalDomainList[0].Contains(CurrentDomain) == false)
					{
						ContainsExternalDomain = true;
					}
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
