using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
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

		}

		private void Application_ItemSend(object Item, ref bool Cancel)
		{

			// 変数定義
			string currentAddress, currentDomain;
			ArrayList targetDomainList;
			int currentType;
			confirmDialog.confirmDialog cnfDialog = new confirmDialog.confirmDialog();

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


		private string GetRecipientAddress(Outlook.Recipient currentRecipient)
		{
			string currentAddress = currentRecipient.Address;
			Outlook.ExchangeUser currentExcUser;

			if (currentAddress.Contains('@') == true)
			{
				// Recipient.Address is judged to be a plain e-mail address because it contains '@'.
				// No additional process is needed.
			}
			else
			{
				// Recipient.Address does not contain '@'.
				// This Recipient is judged to be a Microsoft Exchange account.

				currentExcUser = currentRecipient.AddressEntry.GetExchangeUser();
				currentAddress = currentExcUser.PrimarySmtpAddress;
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
