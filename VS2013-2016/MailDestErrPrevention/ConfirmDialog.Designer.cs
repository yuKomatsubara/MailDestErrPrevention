namespace MailDestErrPrevention
{
	partial class confirmDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxToDomainList = new System.Windows.Forms.ListBox();
            this.checkBoxDomainConfirm = new System.Windows.Forms.CheckBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxCcDomainList = new System.Windows.Forms.ListBox();
            this.listBoxBccDomainList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSettingChange = new System.Windows.Forms.Button();
            this.checkBoxFilePassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "以下のドメインへメールを送ろうとしています。\r\n誤った宛先が含まれていないか確認してください。";
            // 
            // listBoxToDomainList
            // 
            this.listBoxToDomainList.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxToDomainList.FormattingEnabled = true;
            this.listBoxToDomainList.ItemHeight = 19;
            this.listBoxToDomainList.Location = new System.Drawing.Point(19, 75);
            this.listBoxToDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.listBoxToDomainList.Name = "listBoxToDomainList";
            this.listBoxToDomainList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxToDomainList.Size = new System.Drawing.Size(302, 156);
            this.listBoxToDomainList.TabIndex = 1;
            this.listBoxToDomainList.UseTabStops = false;
            // 
            // checkBoxDomainConfirm
            // 
            this.checkBoxDomainConfirm.AutoSize = true;
            this.checkBoxDomainConfirm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxDomainConfirm.Location = new System.Drawing.Point(41, 283);
            this.checkBoxDomainConfirm.Name = "checkBoxDomainConfirm";
            this.checkBoxDomainConfirm.Size = new System.Drawing.Size(307, 20);
            this.checkBoxDomainConfirm.TabIndex = 5;
            this.checkBoxDomainConfirm.Text = "誤った宛先が含まれていないことを確認した。";
            this.checkBoxDomainConfirm.UseVisualStyleBackColor = true;
            this.checkBoxDomainConfirm.CheckStateChanged += new System.EventHandler(this.checkBoxConfirm_CheckStateChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSend.Location = new System.Drawing.Point(41, 317);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(103, 29);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "送信";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCancel.Location = new System.Drawing.Point(819, 317);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 29);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxCcDomainList
            // 
            this.listBoxCcDomainList.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCcDomainList.FormattingEnabled = true;
            this.listBoxCcDomainList.ItemHeight = 19;
            this.listBoxCcDomainList.Location = new System.Drawing.Point(341, 75);
            this.listBoxCcDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.listBoxCcDomainList.Name = "listBoxCcDomainList";
            this.listBoxCcDomainList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxCcDomainList.Size = new System.Drawing.Size(302, 156);
            this.listBoxCcDomainList.TabIndex = 2;
            this.listBoxCcDomainList.UseTabStops = false;
            // 
            // listBoxBccDomainList
            // 
            this.listBoxBccDomainList.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBccDomainList.FormattingEnabled = true;
            this.listBoxBccDomainList.ItemHeight = 19;
            this.listBoxBccDomainList.Location = new System.Drawing.Point(663, 75);
            this.listBoxBccDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.listBoxBccDomainList.Name = "listBoxBccDomainList";
            this.listBoxBccDomainList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxBccDomainList.Size = new System.Drawing.Size(302, 156);
            this.listBoxBccDomainList.TabIndex = 3;
            this.listBoxBccDomainList.UseTabStops = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(337, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(659, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bcc";
            // 
            // buttonSettingChange
            // 
            this.buttonSettingChange.Image = global::MailDestErrPrevention.Properties.Resources.gear_30x30;
            this.buttonSettingChange.Location = new System.Drawing.Point(910, 12);
            this.buttonSettingChange.Name = "buttonSettingChange";
            this.buttonSettingChange.Size = new System.Drawing.Size(55, 41);
            this.buttonSettingChange.TabIndex = 8;
            this.buttonSettingChange.UseVisualStyleBackColor = true;
            this.buttonSettingChange.Click += new System.EventHandler(this.buttonSettingChange_Click);
            // 
            // checkBoxFilePassword
            // 
            this.checkBoxFilePassword.AutoSize = true;
            this.checkBoxFilePassword.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxFilePassword.Location = new System.Drawing.Point(41, 257);
            this.checkBoxFilePassword.Name = "checkBoxFilePassword";
            this.checkBoxFilePassword.Size = new System.Drawing.Size(370, 20);
            this.checkBoxFilePassword.TabIndex = 4;
            this.checkBoxFilePassword.Text = "添付ファイルにパスワードが掛かっていることを確認した。";
            this.checkBoxFilePassword.UseVisualStyleBackColor = true;
            this.checkBoxFilePassword.CheckStateChanged += new System.EventHandler(this.checkBoxFilePassword_CheckStateChanged);
            // 
            // confirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(984, 355);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxFilePassword);
            this.Controls.Add(this.buttonSettingChange);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.checkBoxDomainConfirm);
            this.Controls.Add(this.listBoxBccDomainList);
            this.Controls.Add(this.listBoxCcDomainList);
            this.Controls.Add(this.listBoxToDomainList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "confirmDialog";
            this.Text = "誤送信防止アドイン";
            this.Shown += new System.EventHandler(this.confirmDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBoxToDomainList;
		private System.Windows.Forms.CheckBox checkBoxDomainConfirm;
		private System.Windows.Forms.Button buttonSend;
		internal System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox listBoxCcDomainList;
		private System.Windows.Forms.ListBox listBoxBccDomainList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonSettingChange;
        private System.Windows.Forms.CheckBox checkBoxFilePassword;
    }
}