using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            char[] charArray = addressBox.Text.ToString().ToCharArray();
            Array.Reverse(charArray);
            string endName = charArray[2].ToString() + charArray[1].ToString() + charArray[0].ToString();
            resultBox.Text = endName;
            //org whois.pir.org
            //net whois.verisign-grs.com
            //com whois.verisign-grs.com
            //edu whois.educause.netS
            //string database = "whois.verisign-grs.com";
            //Program.lookUp(database, addressBox.Text, resultBox);
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
