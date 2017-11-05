using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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

            RecordCount = Properties.Settings.Default.InternalDomainList.Count;
            recordList = new DataGridViewRow[RecordCount];

            for (int i = 0; i < RecordCount; i++)
            {
                this.dataGridViewInternalDomain.Rows.Add(new string[] { Properties.Settings.Default.InternalDomainList[i][0], Properties.Settings.Default.InternalDomainList[i][1] });
            }
            removeBlankRows(dataGridViewInternalDomain);


            //// Initialize process of GridViewKnownDomain
            // 1. Setting the format of the matrix. 
            // 2. Loading the records.
            this.dataGridViewKnownDomain.ColumnCount = 2;

            this.dataGridViewKnownDomain.Columns[0].ValueType = typeof(string);
            this.dataGridViewKnownDomain.Columns[0].Name = "ドメイン";
            this.dataGridViewKnownDomain.Columns[1].ValueType = typeof(string);
            this.dataGridViewKnownDomain.Columns[1].Name = "会社名";


            RecordCount = Properties.Settings.Default.KnownDomainList.Count;
            recordList = new DataGridViewRow[RecordCount];

            for (int i = 0; i < RecordCount; i++)
            {
                this.dataGridViewKnownDomain.Rows.Add(new string[] { Properties.Settings.Default.KnownDomainList[i][0], Properties.Settings.Default.KnownDomainList[i][1] });
            }

            removeBlankRows(dataGridViewKnownDomain);

            this.dataGridViewInternalDomain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dataGridViewKnownDomain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void buttonStoreSetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableConfirmationSkip = this.checkBoxEnableConfirmationSkip.Checked;
            Properties.Settings.Default.InternalDomainList = RetrieveList(this.dataGridViewInternalDomain);
            Properties.Settings.Default.KnownDomainList = RetrieveList(this.dataGridViewKnownDomain);
            Properties.Settings.Default.Save();

            this.Close();
        }


        // DataGridViewからデータを取り出してList<List<string>>型にして返す。
        // 環境変数へ保存するために使用する。
        private List<List<string>> RetrieveList(DataGridView currentDataGridView)
        {
            int RecordCount;
            List<List<string>> ReturnList = new List<List<string>>();
            string[] currentRow = new string[2];


            RecordCount = currentDataGridView.Rows.Count;
            for (int i = 0; i < RecordCount; i++)
            {
                currentRow[0] = (currentDataGridView.Rows[i].Cells[0].Value ?? "").ToString().Trim();
                currentRow[1] = (currentDataGridView.Rows[i].Cells[1].Value ?? "").ToString().Trim();

                ReturnList.Add(new List<string>(currentRow));
            }

            return ReturnList;
        }


        // DataGridView内でnullを含む行を削除する。
        private void removeBlankRows(DataGridView currentDataGridView)
        {
            int RecordCount;

            RecordCount = currentDataGridView.Rows.Count;
            for (int currentRecord = 0; currentRecord < RecordCount; currentRecord++)
            {
                if (currentDataGridView.Rows[currentRecord].Cells[0].Value == null ||
                    currentDataGridView.Rows[currentRecord].Cells[1].Value == null)
                {
                    currentDataGridView.Rows.RemoveAt(currentRecord);
                }
            }
        }


        // CSVファイルの読み込みは「TextFieldParser」を使うのが正しい方法なのかも。まぁおいおい。
        private void loadDomains(DataGridView currentDataGridView)
        {
            Stream inputText = null;
            StreamReader inputTextReader;

            // まずはOpenfileDialogBoxでCSVファイルを開く。
            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputText = openFileDialogCSV.OpenFile()) != null)
                    {
                        // inputTextが空でないことを確認する。
                        if (inputText.Length == 0)
                        {
                            MessageBox.Show("指定されたファイルにはデータが含まれていません。[Length = " + inputText.Length + "]");
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ファイルの読み込みに失敗しました[" + ex.Message + "]");
                    return;
                }
            }

            // まずは現在のリストをクリア。
            currentDataGridView.Rows.Clear();

            // とりあえず改行で分ける。
            inputTextReader = new StreamReader(inputText);
            string[] inputTextRows = inputTextReader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // 各行についてリストに追加する。
            for (int currentRecord = 0; currentRecord < inputTextRows.Length; currentRecord++)
            {
                // 現在の行に","が1個のみ有るか確認する。
                if (inputTextRows[currentRecord].Split(',').Length == 2)
                {
                    // あれば新しい行にパラメータを流し込む。
                    currentDataGridView.Rows.Add(new string[] { inputTextRows[currentRecord].Split(',')[0].ToLower(), inputTextRows[currentRecord].Split(',')[1].ToLower() });
                }
                else
                {
                    // 無い、または2個以上有ればエラーを表示して中断。リストはそのままにしておく。
                    MessageBox.Show(currentRecord.ToString() + "行目に有る要素数が正しくありません。\r\nLength = " + inputTextRows[currentRecord].Replace(',', ' ').Length);
                    MessageBox.Show(inputTextRows[currentRecord].Replace(',', ' ')[0].ToString());

                    break;
                }

            }

            removeBlankRows(currentDataGridView);
            openFileDialogCSV.Dispose();
        }


        // CSVファイルの読み込みは「TextFieldParser」を使うのが正しい方法なのかも。まぁおいおい。
        private void buttonImportInternalDomain_Click(object sender, EventArgs e)
        {
            loadDomains(this.dataGridViewInternalDomain);
            this.dataGridViewInternalDomain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void buttonImportKnownDomain_Click(object sender, EventArgs e)
        {
            loadDomains(this.dataGridViewKnownDomain);
            this.dataGridViewKnownDomain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
