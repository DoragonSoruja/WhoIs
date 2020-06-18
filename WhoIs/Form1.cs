using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WhoIs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void searchButton_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
            string TLD = GetTLD(addressBox.Text.ToLower());
            string database = "";
            switch(TLD)
            {
                case "org":
                    database += "whois.pir.org";
                    break;
                case "net":
                    database += "whois.verisign-grs.com";
                    break;
                case "com":
                    database += "whois.verisign-grs.com";
                    break;
                case "edu":
                    database += "whois.educause.net";
                    break;
                case "invalid":
                    return;
                default:
                    MessageBox.Show("Unrecognized Top Level Domain");
                    return;
            }
            Program.LookUp(database, addressBox.Text, resultBox);
            if(resultBox.Text.Contains("Registrar WHOIS Server"))
            {
                string[] information = resultBox.Text.Split(new string[] { ":", "   "}, StringSplitOptions.None);
                resultBox.Clear();
                //resultBox.Text = information[20];
                //for(int x = 0; x < information.Length; x++){ resultBox.Text += x + " " + information[x] + " "; }
                Program.LookUp(information[6].Trim(), addressBox.Text, resultBox);
            }
        }

        private string GetTLD(string url)
        {
            if (url.Contains("."))
            {
                string[] urlList = url.Split('.');
                return urlList[urlList.Length-1];
            }
            else
            {
                MessageBox.Show("Enter in a valid url");
                return "invalid";
            }
        }


        private void addressBox_Enter(object sender, EventArgs e)
        {
            if (addressBox.Text == "Ex: google.com")
            {
                addressBox.Text = "";
                addressBox.ForeColor = Color.Black;
            }
        }

        private void addressBox_Leave(object sender, EventArgs e)
        {
            if (addressBox.Text == "")
            {
                addressBox.Text = "Ex: google.com";
                addressBox.ForeColor = Color.Silver;
            }
        }

        private void addressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchButton_Click(null, null);
            }
        }
    }
}
