using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTestLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string lang = Properties.Settings.Default.Language;
            if (!string.IsNullOrEmpty(lang))
            {
                System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.GetCultureInfo(lang);
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            }


            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(MyStrings.ExitMessage, MyStrings.ExitTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(MyStrings.GoodbyeMessage);
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]
                {
                    System.Globalization.CultureInfo.GetCultureInfo("ru"),
                    System.Globalization.CultureInfo.GetCultureInfo("en")
                };
            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";

            if(!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
