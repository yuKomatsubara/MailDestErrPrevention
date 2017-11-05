namespace MailDestErrPrevention
{
	partial class SettingDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.checkBoxEnableConfirmationSkip = new System.Windows.Forms.CheckBox();
            this.dataGridViewInternalDomain = new System.Windows.Forms.DataGridView();
            this.groupBoxInternalDomain = new System.Windows.Forms.GroupBox();
            this.buttonImportInternalDomain = new System.Windows.Forms.Button();
            this.groupBoxKnownDomain = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImportKnownDomain = new System.Windows.Forms.Button();
            this.dataGridViewKnownDomain = new System.Windows.Forms.DataGridView();
            this.buttonStoreSetting = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternalDomain)).BeginInit();
            this.groupBoxInternalDomain.SuspendLayout();
            this.groupBoxKnownDomain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKnownDomain)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxEnableConfirmationSkip
            // 
            this.checkBoxEnableConfirmationSkip.AutoSize = true;
            this.checkBoxEnableConfirmationSkip.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.checkBoxEnableConfirmationSkip.Location = new System.Drawing.Point(13, 28);
            this.checkBoxEnableConfirmationSkip.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.checkBoxEnableConfirmationSkip.Name = "checkBoxEnableConfirmationSkip";
            this.checkBoxEnableConfirmationSkip.Size = new System.Drawing.Size(339, 16);
            this.checkBoxEnableConfirmationSkip.TabIndex = 1;
            this.checkBoxEnableConfirmationSkip.Text = "宛先が以下に示される社内ドメインのみの場合は確認を省略する。";
            this.checkBoxEnableConfirmationSkip.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInternalDomain
            // 
            this.dataGridViewInternalDomain.AllowUserToAddRows = false;
            this.dataGridViewInternalDomain.AllowUserToDeleteRows = false;
            this.dataGridViewInternalDomain.AllowUserToResizeRows = false;
            this.dataGridViewInternalDomain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInternalDomain.Location = new System.Drawing.Point(13, 54);
            this.dataGridViewInternalDomain.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.dataGridViewInternalDomain.Name = "dataGridViewInternalDomain";
            this.dataGridViewInternalDomain.ReadOnly = true;
            this.dataGridViewInternalDomain.RowTemplate.Height = 21;
            this.dataGridViewInternalDomain.Size = new System.Drawing.Size(400, 150);
            this.dataGridViewInternalDomain.TabIndex = 0;
            this.dataGridViewInternalDomain.TabStop = false;
            // 
            // groupBoxInternalDomain
            // 
            this.groupBoxInternalDomain.Controls.Add(this.buttonImportInternalDomain);
            this.groupBoxInternalDomain.Controls.Add(this.dataGridViewInternalDomain);
            this.groupBoxInternalDomain.Controls.Add(this.checkBoxEnableConfirmationSkip);
            this.groupBoxInternalDomain.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxInternalDomain.Location = new System.Drawing.Point(14, 12);
            this.groupBoxInternalDomain.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxInternalDomain.Name = "groupBoxInternalDomain";
            this.groupBoxInternalDomain.Size = new System.Drawing.Size(442, 252);
            this.groupBoxInternalDomain.TabIndex = 1;
            this.groupBoxInternalDomain.TabStop = false;
            this.groupBoxInternalDomain.Text = "社内向けメールに関する設定";
            // 
            // buttonImportInternalDomain
            // 
            this.buttonImportInternalDomain.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.buttonImportInternalDomain.Location = new System.Drawing.Point(251, 217);
            this.buttonImportInternalDomain.Name = "buttonImportInternalDomain";
            this.buttonImportInternalDomain.Size = new System.Drawing.Size(162, 23);
            this.buttonImportInternalDomain.TabIndex = 2;
            this.buttonImportInternalDomain.Text = "社内ドメインをインポートする";
            this.buttonImportInternalDomain.UseVisualStyleBackColor = true;
            this.buttonImportInternalDomain.Click += new System.EventHandler(this.buttonImportInternalDomain_Click);
            // 
            // groupBoxKnownDomain
            // 
            this.groupBoxKnownDomain.Controls.Add(this.label1);
            this.groupBoxKnownDomain.Controls.Add(this.buttonImportKnownDomain);
            this.groupBoxKnownDomain.Controls.Add(this.dataGridViewKnownDomain);
            this.groupBoxKnownDomain.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxKnownDomain.Location = new System.Drawing.Point(14, 286);
            this.groupBoxKnownDomain.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxKnownDomain.Name = "groupBoxKnownDomain";
            this.groupBoxKnownDomain.Size = new System.Drawing.Size(442, 247);
            this.groupBoxKnownDomain.TabIndex = 2;
            this.groupBoxKnownDomain.TabStop = false;
            this.groupBoxKnownDomain.Text = "既知のドメイン";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "以下のドメインについては送信可否の確認時にドメインとともに会社名が表示されます。";
            // 
            // buttonImportKnownDomain
            // 
            this.buttonImportKnownDomain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonImportKnownDomain.Location = new System.Drawing.Point(251, 214);
            this.buttonImportKnownDomain.Name = "buttonImportKnownDomain";
            this.buttonImportKnownDomain.Size = new System.Drawing.Size(162, 23);
            this.buttonImportKnownDomain.TabIndex = 1;
            this.buttonImportKnownDomain.Text = "既知のドメインをインポートする";
            this.buttonImportKnownDomain.UseVisualStyleBackColor = true;
            this.buttonImportKnownDomain.Click += new System.EventHandler(this.buttonImportKnownDomain_Click);
            // 
            // dataGridViewKnownDomain
            // 
            this.dataGridViewKnownDomain.AllowUserToAddRows = false;
            this.dataGridViewKnownDomain.AllowUserToDeleteRows = false;
            this.dataGridViewKnownDomain.AllowUserToResizeRows = false;
            this.dataGridViewKnownDomain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKnownDomain.Location = new System.Drawing.Point(13, 51);
            this.dataGridViewKnownDomain.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.dataGridViewKnownDomain.Name = "dataGridViewKnownDomain";
            this.dataGridViewKnownDomain.ReadOnly = true;
            this.dataGridViewKnownDomain.RowTemplate.Height = 21;
            this.dataGridViewKnownDomain.Size = new System.Drawing.Size(400, 150);
            this.dataGridViewKnownDomain.TabIndex = 0;
            this.dataGridViewKnownDomain.TabStop = false;
            // 
            // buttonStoreSetting
            // 
            this.buttonStoreSetting.Location = new System.Drawing.Point(27, 537);
            this.buttonStoreSetting.Name = "buttonStoreSetting";
            this.buttonStoreSetting.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreSetting.TabIndex = 3;
            this.buttonStoreSetting.Text = "設定を保存";
            this.buttonStoreSetting.UseVisualStyleBackColor = true;
            this.buttonStoreSetting.Click += new System.EventHandler(this.buttonStoreSetting_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(352, 537);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialogCSV
            // 
            this.openFileDialogCSV.FileName = "domains.csv";
            this.openFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files(*.*)|*.*";
            this.openFileDialogCSV.InitialDirectory = "%USERPROFILE%\\Desktop";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(470, 572);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStoreSetting);
            this.Controls.Add(this.groupBoxKnownDomain);
            this.Controls.Add(this.groupBoxInternalDomain);
            this.Name = "SettingDialog";
            this.Text = "誤送信防止アドイン設定";
            this.Shown += new System.EventHandler(this.SettingDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternalDomain)).EndInit();
            this.groupBoxInternalDomain.ResumeLayout(false);
            this.groupBoxInternalDomain.PerformLayout();
            this.groupBoxKnownDomain.ResumeLayout(false);
            this.groupBoxKnownDomain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKnownDomain)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxEnableConfirmationSkip;
		private System.Windows.Forms.DataGridView dataGridViewInternalDomain;
		private System.Windows.Forms.GroupBox groupBoxInternalDomain;
		private System.Windows.Forms.Button buttonImportInternalDomain;
		private System.Windows.Forms.GroupBox groupBoxKnownDomain;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonImportKnownDomain;
		private System.Windows.Forms.DataGridView dataGridViewKnownDomain;
		private System.Windows.Forms.Button buttonStoreSetting;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSV;
    }
}