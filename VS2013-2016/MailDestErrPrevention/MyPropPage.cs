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
	[System.Runtime.InteropServices.ComVisible(true)]
	public partial class MyPropPage : Form
	{
		private Microsoft.Office.Interop.Outlook.PropertyPageSite _propertyPageSite;

		public MyPropPage()
		{
			InitializeComponent();

			checkBoxEnableConfirmationSkip.Checked = Properties.Settings.Default.EnableConfirmationSkip;

			checkBoxEnableConfirmationSkip.CheckedChanged += (sender, e) =>
			{
				if (_propertyPageSite != null)
				{
					_propertyPageSite.OnStatusChange();
				}

			};
		}


		protected override void OnLoad(EventArgs e)
		{
			// プロパティ変更の通知先を得ます
			// => リフレクションを利用して .NET ライブラリ中の System.Windows.Forms.UnsafeNativeMethods.IOleObject クラスにある GetClientSite メソッドを呼び出します。
			Type type = typeof(System.Object);
			string assembly = type.Assembly.CodeBase.Replace("mscorlib.dll", "System.Windows.Forms.dll");
			assembly = assembly.Replace("file:///", "");

			string assemblyName = System.Reflection.AssemblyName.GetAssemblyName(assembly).FullName;
			Type unsafeNativeMethods = Type.GetType(System.Reflection.Assembly.CreateQualifiedName(assemblyName, "System.Windows.Forms.UnsafeNativeMethods"));

			Type oleObj = unsafeNativeMethods.GetNestedType("IOleObject");
			System.Reflection.MethodInfo methodInfo = oleObj.GetMethod("GetClientSite");
			_propertyPageSite = methodInfo.Invoke(this, null) as Microsoft.Office.Interop.Outlook.PropertyPageSite;
		}

		private void buttonSet_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.EnableConfirmationSkip = checkBoxEnableConfirmationSkip.Checked;
			Properties.Settings.Default.Save();

//			this.Close();
		}

		public void Apply()
		{
			// OK や 適用ボタンをクリックされたときの処理を記述します。
			Properties.Settings.Default.EnableConfirmationSkip = checkBoxEnableConfirmationSkip.Checked;
			Properties.Settings.Default.Save();
		}

		public bool Dirty
		{
			get
			{
				// 適用ボタンを有効にしたい状態の場合は true を返すようにします。ここでは、「設定」の記憶値とテキストボックスの値が異なっている場合に true を返すようにしています。
				return (checkBoxEnableConfirmationSkip.Checked != Properties.Settings.Default.EnableConfirmationSkip);
			}
		}

		public void GetPageInfo(ref string HelpFile, ref int HelpContext)
		{
			// ヘルプファイル (.chm) を指定できるようです。不要なら何も書かないでよいです。
		}

	}
}
