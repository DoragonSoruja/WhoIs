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

            StreamReader file = new StreamReader(@"D:\Projects\WhoIs\WhoIs\WhoIs\WhoIs_Server.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, TLD.Length) == TLD) { database += line; }
            }

            string[] TLDServer = database.Split(' ');

            try
            {
                Program.LookUp(TLDServer[1].Trim(), addressBox.Text, resultBox);
            }
            catch(Exception)
            {
                MessageBox.Show("This program doesn't support TLD: " + TLD);
            }

            if(resultBox.Text.Contains("Registrar WHOIS Server"))
            {
                database = "";
                int colon = 0;
                foreach(char x in resultBox.Text)
                {
                    if(colon == 3)
                    {
                        if (x == '\n')
                            break;
                        database += x;
                    }

                    if (x == ':')
                        colon++;
                }
                resultBox.Clear();
                Program.LookUp(database.Trim(), addressBox.Text, resultBox);
            }
        }

        private string GetTLD(string url)
        {
            if (url.Contains("."))
            {
                string[] urlList = url.Split('.');
                if (urlList.Length > 2)
                {
                    return urlList[urlList.Length - 2] + '.' + urlList[urlList.Length - 1];
                }
                else
                {
                    return urlList[urlList.Length - 1];
                }
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
