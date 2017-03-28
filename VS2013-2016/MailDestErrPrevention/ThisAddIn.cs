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
using confirmDialog;


namespace MailDestErrPrevention
{
	public partial class ThisAddIn
	{
		//        Outlook.Inspectors inspectors;
		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{
			//            inspectors = this.Application.Inspectors;
			//            inspectors.NewInspector +=
			//                new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

			Application.ItemSend += Application_ItemSend;

			Application.OptionsPagesAdd += Application_OptionsPagesAdd;
		}

		void Application_OptionsPagesAdd(Outlook.PropertyPages Pages)
		{
			Pages.Add(new MyPropPage(), "General");
			// 複数ページあれば、さらに Add します。
		}

		private void Application_ItemSend(object Item, ref bool Cancel)
		{

			// 変数定義
			string currentAddress, currentDomain;
			ArrayList targetDomainList;
			int currentType;
			confirmDialog.confirmDialog cnfDialog = new confirmDialog.confirmDialog();
			bool confirmFlag;

			Outlook.MailItem CurrentMail = Item as Outlook.MailItem;


			foreach (Outlook.Recipient currentRecipient in CurrentMail.Recipients)
			{
				// 各宛先についてアドレス（currentAddress）を取得し、currentDomainとしてドメインを分離する。
				currentAddress = GetRecipientAddress(currentRecipient);
				currentDomain = currentAddress.Split('@')[1];

				currentType = currentRecipient.Type;
				// MailItem.Typeの実体はOlMailRecipientTypeであり以下の通り対応する。
				//      olOriginator    0
				//      olTo			1
				//		olBCC			3
				//      olCC			2


				switch (currentType)
				{
					case 1:
						targetDomainList = cnfDialog.ToDomainList;
						break;
					case 2:
						targetDomainList = cnfDialog.CcDomainList;
						break;
					case 3:
						targetDomainList = cnfDialog.BccDomainList;
						break;

					case 0:
					default:
						// 送信者アドレスについては何も処理を行わない。
						continue;
				}

				// DestDomainsにcurrentDomainが含まれていない場合、末尾に追加する。
				if (targetDomainList.Contains(currentDomain) == false)
				{
					targetDomainList.Add(currentDomain);
				}
			}

#if _DEBUG_
			MessageBox.Show("[Debug] Finished to gather addresses.");
#endif

			confirmFlag = true;

			if ((cnfDialog.ToDomainList.Count == 1) && (cnfDialog.ToDomainList.Contains("advanet.jp") == true))
			{
				if ((cnfDialog.CcDomainList.Count == 0) ||
					((cnfDialog.CcDomainList.Count == 1) && (cnfDialog.CcDomainList.Contains("advanet.jp"))))
				{
					if ((cnfDialog.BccDomainList.Count == 0) ||
						((cnfDialog.BccDomainList.Count == 1) && (cnfDialog.BccDomainList.Contains("advanet.jp"))))
					{
						if (Properties.Settings.Default.EnableConfirmationSkip)
						{
#if _DEBUG_
							MessageBox.Show("[Debug] All destinations are 'advanet.jp'\nand EnableConfirmatinSkip is TRUE.\nConfirmation dialog will be skipped.");
#endif
							confirmFlag = false;
						}
						else
						{
#if _DEBUG_
							MessageBox.Show("[Debug] All destinations are 'advanet.jp'\nbut EnableConfirmatinSkip is FALSE.");
#endif
						}
					}
				}
			}

			if (!confirmFlag)
			{
				// advanet.jpしか含まない場合は確認ダイアログをスキップする機能。
				// ただし、単純なうっかり送信防止機能（例えば、他のウインドウをクリックした積もりで「送信」押しちゃうとか）として
				// 使いたいという要望も想定し、最終的には外部ファイルを読み込んでEnable/Disableを切り替えられるようにする。

				Cancel = false;
			}
			else
			{
#if _DEBUG_
				MessageBox.Show("[Debug] Address list includes external domain\nor EnableConfirmatinSkip is FALSE.\nConfirmation dialog will be shown.");
#endif

				// 確認用ダイアログ（confirmDialog.cs）を表示する。
				cnfDialog.ShowDialog();

				// 確認用ダイアログで「送信」が押下された場合のみ送信処理を続ける。
				if (cnfDialog.sendFlag == 1)
				{
					//                MessageBox.Show("message will be sent.");
					Cancel = false;
				}
				else
				{
					//               MessageBox.Show("message send process was aborted by User.");
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
