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

			// ドメインリストをリストボックスに登録する。
			this.listBoxToDomainList.DataSource = ToDomainList;
			this.listBoxCcDomainList.DataSource = CcDomainList;
			this.listBoxBccDomainList.DataSource = BccDomainList;
			/*			this.listBoxToDomainList.DataSource = ToAddressList;
						this.listBoxCcDomainList.DataSource = CcAddressList;
						this.listBoxBccDomainList.DataSource = BccAddressList;*/

		}

		private void buttonSettingChange_Click(object sender, EventArgs e)
		{
			SettingDialog setDialog = new SettingDialog();

			setDialog.ShowDialog();
		}
	}
}
