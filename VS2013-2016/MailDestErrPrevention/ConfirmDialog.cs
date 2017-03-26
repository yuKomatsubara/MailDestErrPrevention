using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace confirmDialog
{
    public partial class confirmDialog : Form
    {
		public ArrayList ToDomainList = new ArrayList();
		public ArrayList CcDomainList = new ArrayList();
		public ArrayList BccDomainList = new ArrayList();

		public int sendFlag;
        
        public confirmDialog()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.sendFlag = 1;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.sendFlag = 0;
            this.Close();
        }

        private void checkBoxConfirm_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBoxConfirm.Checked == true)
            {
                buttonSend.Enabled = true;
            } else
            {
                buttonSend.Enabled = false;
            }
        }

		private void confirmDialog_Shown(object sender, EventArgs e)
		{
			int i;

			i = 0;

			for (i=0; i<ToDomainList.Count; i++)
			{
				ToDomainList[i] = ConvertKnownDomain(ToDomainList[i].ToString());
			}

			for (i = 0; i < CcDomainList.Count; i++)
			{
				CcDomainList[i] = ConvertKnownDomain(CcDomainList[i].ToString());
			}

			for (i = 0; i < BccDomainList.Count; i++)
			{
				BccDomainList[i] = ConvertKnownDomain(BccDomainList[i].ToString());
			}

			// ドメインリストをリストボックスに登録する。
			this.listBoxToDomainList.Items.AddRange(ToDomainList.ToArray());
			this.listBoxCcDomainList.Items.AddRange(CcDomainList.ToArray());
			this.listBoxBccDomainList.Items.AddRange(BccDomainList.ToArray());
		}

		private string ConvertKnownDomain(string currentDomain)
		{
			int Index;
			StringBuilder ReturnString = new StringBuilder();

			Index = KnownDomainList.ToList().IndexOf(currentDomain);

			if ((Index >= 0) && (Index < KnownDomainList.Length))
			{
				ReturnString.Append(KnownDomainNameList[Index].ToString());
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

		private string[] KnownDomainList = new string[] {
				"ti.com",
				"teldevice.co.jp",
				"oki.com",
				"oec.okaya.co.jp",
				"murata.co.jp",
				"eurotech.com",
				"elsena.co.jp",
				"avnet.com",
				"advanet.jp"
		};

		private string[] KnownDomainNameList = new string[] {
				"texas instruments",
				"東京エレクトロンデバイス",
				"沖グループ",
				"岡谷エレクトロニクス",
				"村田製作所",
				"Eurotech",
				"エルセナ",
				"アヴネット",
				"アドバネット"
		};
	}
}
