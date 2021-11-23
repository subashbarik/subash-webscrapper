using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml;

namespace WebScrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void getHTMLAsync()
        {
            //string url = "https://www.flipkart.com/mobiles/~iphone-8-plus-64gb-and-256gb/pr?sid=tyy%2C4io&otracker=clp_banner_1_7.bannerX3.BANNER_apple-products-store_W8OZI07LNL&fm=neo%2Fmerchandising&iid=M_2763664d-4784-45ab-ac94-877d156bb162_7.W8OZI07LNL&ppt=clp&ppn=apple-products-store&ssid=r2ity58tww0000001571980915464";
            //string url = "https://www.amazon.in/b/ref=cepc_elec_JupW3_rec1_lap?node=17492328031&pf_rd_p=d00fc980-f015-428c-a507-7773445b1343&pf_rd_r=KB5HJF69Z13A57AF8CGX";

            string url = "https://www.ebay.com/b/iPhone-7-Plus/9355/bn_36834266";
            string products = "";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var productHTML = htmlDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("s-item__info clearfix"));
            foreach (var productDetail in productHTML)
            {
                var productName = productDetail.Descendants("a").Where(node => node.GetAttributeValue("class", "").Equals("s-item__link"));
                //productName.de
                //products = products + productName.ToString() + "\n";
            }
            //richTextBox1.Text = products;
        }

        private void btnGetHTML_Click(object sender, EventArgs e)
        {
            getHTMLAsync();
        }
    }
}
