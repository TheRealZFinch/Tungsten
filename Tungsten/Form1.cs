using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tungsten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format(@"file:///{0}/homepage.html", curDir));
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(addresBar.Text);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string adr = webBrowser1.Url.ToString();
            addresBar.Text = adr;
            addresBar.ForeColor = Color.Black;
            contextMenuStrip1.Items.Add(adr);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            addresBar.ForeColor = Color.Red;
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            webBrowser1.Navigate(e.ClickedItem.Text);
        }
    }
}
