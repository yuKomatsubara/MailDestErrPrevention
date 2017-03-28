namespace MailDestErrPrevention
{
	partial class MyPropPage
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
			this.buttonSet = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxEnableConfirmationSkip
			// 
			this.checkBoxEnableConfirmationSkip.AutoSize = true;
			this.checkBoxEnableConfirmationSkip.Location = new System.Drawing.Point(23, 23);
			this.checkBoxEnableConfirmationSkip.Name = "checkBoxEnableConfirmationSkip";
			this.checkBoxEnableConfirmationSkip.Size = new System.Drawing.Size(351, 16);
			this.checkBoxEnableConfirmationSkip.TabIndex = 0;
			this.checkBoxEnableConfirmationSkip.Text = "宛先が\"@advanet.jp\"のみである場合に確認ダイアログを表示しない。";
			this.checkBoxEnableConfirmationSkip.UseVisualStyleBackColor = true;
			// 
			// buttonSet
			// 
			this.buttonSet.Location = new System.Drawing.Point(316, 226);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.Size = new System.Drawing.Size(75, 23);
			this.buttonSet.TabIndex = 1;
			this.buttonSet.Text = "設定";
			this.buttonSet.UseVisualStyleBackColor = true;
			this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(410, 226);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "キャンセル";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// MyPropPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 261);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSet);
			this.Controls.Add(this.checkBoxEnableConfirmationSkip);
			this.Name = "MyPropPage";
			this.Text = "MyPropPage";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxEnableConfirmationSkip;
		private System.Windows.Forms.Button buttonSet;
		private System.Windows.Forms.Button buttonCancel;
	}
}