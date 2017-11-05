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

namespace MailDestErrPrevention
{
    public partial class confirmDialog : Form
    {
		public List<string> ToAddressList = new List<string>();
		public List<string> CcAddressList = new List<string>();
		public List<string> BccAddressList = new List<string>();

		public List<string> ToDomainList = new List<string>();
		public List<string> CcDomainList = new List<string>();
		public List<string> BccDomainList = new List<string>();

		public int sendFlag;
        public bool includesExternalDomain;
        public bool hasAttachment                                                                                                                                                                                                                        ;


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

        private void buttonSend_stateUpdate()
        {
            if (this.checkBoxDomainConfirm.Checked == true &&
                this.checkBoxFilePassword.Checked == true) {
                buttonSend.Enabled = true;
            } else {
                buttonSend.Enabled = false;
            }
        }

        private void checkBoxConfirm_CheckStateChanged(object sender, EventArgs e)
        {
            buttonSend_stateUpdate();
        }

        private void checkBoxFilePassword_CheckStateChanged(object sender, EventArgs e)
        {
            buttonSend_stateUpdate();
        }

        private void confirmDialog_Shown(object sender, EventArgs e)
		{

			// ドメインリストをリストボックスに登録する。
			this.listBoxToDomainList.DataSource = ToDomainList;
			this.listBoxCcDomainList.DataSource = CcDomainList;
			this.listBoxBccDomainList.DataSource = BccDomainList;

            // 外部ドメイン向け かつ 添付ファイルが有るときのみ、添付ファイル確認用のチェックボックスを表示する。   
            if (this.includesExternalDomain == true && this.hasAttachment == true) {
                this.checkBoxFilePassword.Show();
                this.checkBoxFilePassword.Checked = false;
            } else {
                this.checkBoxFilePassword.Hide();
                this.checkBoxFilePassword.Checked = true;
            }
        }

		private void buttonSettingChange_Click(object sender, EventArgs e)
		{
			SettingDialog setDialog = new SettingDialog();

			setDialog.ShowDialog();
		}
    }
}
