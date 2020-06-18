using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace WhoIs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        public static void LookUp(string database, string website, RichTextBox resultLabel)
        {
            try
            {
                TcpClient client = new TcpClient(database, 43);
                Stream site = client.GetStream();
                byte[] domain = Encoding.ASCII.GetBytes(website + "\n");
                site.Write(domain, 0, website.Length + 1);
                StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);
                resultLabel.Text = reader.ReadToEnd();
            }
            catch(Exception e)
            {
                resultLabel.Clear();
                MessageBox.Show("An Error has occurred! Either the domain doesn't exist or is denying access.");
            }
        }
    }
}
