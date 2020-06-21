using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

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
            string database = "whois.iana.org";

            TcpClient client = new TcpClient(database, 43);
            Stream site = client.GetStream();
            byte[] domain = Encoding.ASCII.GetBytes(addressBox.Text + "\n");
            site.Write(domain, 0, addressBox.Text.Length + 1);
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);

            bool startWriting = false;
            database = "";
            int counter = 0;

            foreach (char x in reader.ReadToEnd())
            {
                if (startWriting == true && counter == 2)
                {
                    if (x == '\n')
                    {
                        break;
                    }
                    else
                    {
                        database += x;
                    }
                }
                if (x == ':')
                {
                    startWriting = true;
                    counter++;
                }
            }

            try
            {
                Program.LookUp(database.Trim(), addressBox.Text, resultBox);
            }
            catch(Exception)
            {
                MessageBox.Show("This program doesn't support that TLD");
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
    }
}
