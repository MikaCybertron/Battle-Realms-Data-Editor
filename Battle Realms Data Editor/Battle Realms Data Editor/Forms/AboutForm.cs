namespace BattleRealmsDataEditor.Forms
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ShowInTaskbar = false;
            MinimizeBox = false;
            MaximizeBox = false;

            DarkTitleBar.EnabledDarkTheme(Handle, true);

            InitializeAboutBoxInfo();
        }

        private void InitializeAboutBoxInfo()
        {
            Text = "About";
            labelProductName.Text = Application.ProductName;
            labelVersion.Text = $"Version {Application.ProductVersion}";
            labelCopyRight.Text = AssemblyCopyright;
        }

        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
