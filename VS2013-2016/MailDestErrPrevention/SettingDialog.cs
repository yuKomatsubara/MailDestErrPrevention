using System;
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
	public partial class SettingDialog : Form
	{
		public SettingDialog()
		{
			InitializeComponent();
		}

		private void SettingDialog_Shown(object sender, EventArgs e)
		{
			this.checkBoxEnableConfirmationSkip.Checked = Properties.Settings.Default.EnableConfirmationSkip;

			initDataGrid();
		}

		private void initDataGrid()
		{
			int RecordCount;
			DataGridViewRow[] recordList;


			//// Initialize process of GridViewInternalDomain
			// 1. Setting the format of the matrix. 
			// 2. Loading the records.
			this.dataGridViewInternalDomain.ColumnCount = 2;

			this.dataGridViewInternalDomain.Columns[0].ValueType = typeof(string);
			this.dataGridViewInternalDomain.Columns[0].Name = "ドメイン";
			this.dataGridViewInternalDomain.Columns[1].ValueType = typeof(string);
			this.dataGridViewInternalDomain.Columns[1].Name = "会社名";

#if _DEBUG_
			MessageBox.Show(string.Concat("Properties.Settings.Default.InternalDomainList.Count = ", RecordCount.ToString()));
#endif


			RecordCount = Properties.Settings.Default.InternalDomainList.Count;
			recordList = new DataGridViewRow[RecordCount];

			for (int i = 0; i < RecordCount; i++)
			{
#if _DEBUG_
				MessageBox.Show("Properties.Settings.Default.InternalDomainList[" + i.ToString() + "] is" + Properties.Settings.Default.InternalDomainList[i]);
#endif
				this.dataGridViewInternalDomain.Rows.Add(new string[] { Properties.Settings.Default.InternalDomainList[i][0], Properties.Settings.Default.InternalDomainList[i][1] });
			}


			//// Initialize process of GridViewKnownDomain
			// 1. Setting the format of the matrix. 
			// 2. Loading the records.
			this.dataGridViewKnownDomain.ColumnCount = 2;

			this.dataGridViewKnownDomain.Columns[0].ValueType = typeof(string);
			this.dataGridViewKnownDomain.Columns[0].Name = "ドメイン";
			this.dataGridViewKnownDomain.Columns[1].ValueType = typeof(string);
			this.dataGridViewKnownDomain.Columns[1].Name = "会社名";


#if _DEBUG_
			MessageBox.Show(string.Concat("Properties.Settings.Default.InternalDomainList.Count = ", RecordCount.ToString()));
#endif
			RecordCount = Properties.Settings.Default.KnownDomainList.Count;
			recordList = new DataGridViewRow[RecordCount];

			for (int i = 0; i < RecordCount; i++)
			{
				this.dataGridViewKnownDomain.Rows.Add(new string[] { Properties.Settings.Default.KnownDomainList[i][0], Properties.Settings.Default.KnownDomainList[i][1] });
			}
		}

		private void buttonStoreSetting_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.EnableConfirmationSkip = this.checkBoxEnableConfirmationSkip.Checked;
			Properties.Settings.Default.InternalDomainList = RetrieveList(this.dataGridViewInternalDomain);
			Properties.Settings.Default.KnownDomainList = RetrieveList(this.dataGridViewKnownDomain);
			Properties.Settings.Default.Save();

			this.Close();
		}

		private List<List<string>> RetrieveList(DataGridView currentDataGridView)
		{
			int RecordCount;
			List<List<string>> ReturnList = new List<List<string>>();


			RecordCount = currentDataGridView.Rows.Count;
			for(int i =0; i<RecordCount; i++)
			{
				ReturnList.Add(new List<string> { currentDataGridView.Rows[i].Cells[0].ToString(), currentDataGridView.Rows[i].Cells[1].ToString() });
			}

			return ReturnList;
		}

		private void buttonImportInternalDomain_Click(object sender, EventArgs e)
		{
			this.dataGridViewInternalDomain.Rows.Add(new List<string> { DateTime.Now.ToString(), DateTime.Now.DayOfWeek.ToString() });
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonImportKnownDomain_Click(object sender, EventArgs e)
		{
			this.dataGridViewKnownDomain.Rows.Add(new List<string> { DateTime.Now.ToString(), DateTime.Now.DayOfWeek.ToString() });
		}
	}
}
