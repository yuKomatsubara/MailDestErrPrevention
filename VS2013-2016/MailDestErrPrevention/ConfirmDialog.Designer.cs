namespace confirmDialog
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
			this.checkBoxConfirm = new System.Windows.Forms.CheckBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.listBoxCcDomainList = new System.Windows.Forms.ListBox();
			this.listBoxBccDomainList = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
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
			this.listBoxToDomainList.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listBoxToDomainList.FormattingEnabled = true;
			this.listBoxToDomainList.ItemHeight = 15;
			this.listBoxToDomainList.Location = new System.Drawing.Point(19, 75);
			this.listBoxToDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
			this.listBoxToDomainList.Name = "listBoxToDomainList";
			this.listBoxToDomainList.Size = new System.Drawing.Size(302, 169);
			this.listBoxToDomainList.TabIndex = 1;
			this.listBoxToDomainList.UseTabStops = false;
			// 
			// checkBoxConfirm
			// 
			this.checkBoxConfirm.AutoSize = true;
			this.checkBoxConfirm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.checkBoxConfirm.Location = new System.Drawing.Point(41, 258);
			this.checkBoxConfirm.Name = "checkBoxConfirm";
			this.checkBoxConfirm.Size = new System.Drawing.Size(307, 20);
			this.checkBoxConfirm.TabIndex = 2;
			this.checkBoxConfirm.Text = "誤った宛先が含まれていないことを確認した。";
			this.checkBoxConfirm.UseVisualStyleBackColor = true;
			this.checkBoxConfirm.CheckStateChanged += new System.EventHandler(this.checkBoxConfirm_CheckStateChanged);
			// 
			// buttonSend
			// 
			this.buttonSend.Enabled = false;
			this.buttonSend.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonSend.Location = new System.Drawing.Point(41, 284);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(103, 44);
			this.buttonSend.TabIndex = 3;
			this.buttonSend.Text = "送信";
			this.buttonSend.UseVisualStyleBackColor = true;
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonCancel.Location = new System.Drawing.Point(804, 284);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(126, 44);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "キャンセル";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// listBoxCcDomainList
			// 
			this.listBoxCcDomainList.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listBoxCcDomainList.FormattingEnabled = true;
			this.listBoxCcDomainList.ItemHeight = 15;
			this.listBoxCcDomainList.Location = new System.Drawing.Point(341, 75);
			this.listBoxCcDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
			this.listBoxCcDomainList.Name = "listBoxCcDomainList";
			this.listBoxCcDomainList.Size = new System.Drawing.Size(302, 169);
			this.listBoxCcDomainList.TabIndex = 1;
			this.listBoxCcDomainList.UseTabStops = false;
			// 
			// listBoxBccDomainList
			// 
			this.listBoxBccDomainList.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listBoxBccDomainList.FormattingEnabled = true;
			this.listBoxBccDomainList.ItemHeight = 15;
			this.listBoxBccDomainList.Location = new System.Drawing.Point(663, 75);
			this.listBoxBccDomainList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
			this.listBoxBccDomainList.Name = "listBoxBccDomainList";
			this.listBoxBccDomainList.Size = new System.Drawing.Size(302, 169);
			this.listBoxBccDomainList.TabIndex = 1;
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
			// confirmDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 338);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.checkBoxConfirm);
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
        private System.Windows.Forms.CheckBox checkBoxConfirm;
        private System.Windows.Forms.Button buttonSend;
        internal System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox listBoxCcDomainList;
		private System.Windows.Forms.ListBox listBoxBccDomainList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}