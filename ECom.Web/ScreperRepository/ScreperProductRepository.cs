using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ECom.Web.ScreperRepository
{
    public class ScreperProductRepository
    {
        public void GetScreperProduct(string NaMe,string url)
        {
            //string url = "https://www.daraz.com.bd/products/wrm30-leather-analog-watch-for-men-brown-i2375556-s62394937.html?spm=a2a0e.searchlistcategory.list.33.50a2a711kGJKu6&search=1";
            //string url = "https://www.daraz.com.bd/products/light-sky-blue-cotton-formal-shirt-for-men-i726704-s2772720.html?spm=a2a0e.searchlistcategory.list.31.576a6e1fut9JTU&search=1";

            HtmlWeb website = new HtmlWeb();

            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;

            if (!string.IsNullOrEmpty(url))
            {
                HtmlDocument htmlDocument = website.Load(url);
                if (!string.IsNullOrEmpty(NaMe))
                {
                    switch (NaMe)
                    {
                        case "Daraz":
                            var product1 = htmlDocument.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("container")).First();

                            var ImgURL = product1.Descendants("img").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("pdp-mod-common-image gallery-preview-panel__image")).First().GetAttributeValue("src", "");
                            var ProductName = product1.Descendants("span").Where(x => x.GetAttributeValue("class", "").Equals("pdp-mod-product-badge-title"));
                            var Price = product1.Descendants("span").Where(x => x.GetAttributeValue("class", "").Equals(" pdp-price pdp-price_type_normal pdp-price_color_orange pdp-price_size_xl")).FirstOrDefault().InnerText.Replace("à§³ ", "৳ ");// $ , ৳->à§³
                            var description1 = product1.Descendants("div").Where(x => x.GetAttributeValue("class", "").Equals("html-content detail-content"));

                            name = Convert.ToString(ProductName.First().InnerText);
                            description = Convert.ToString(description1.First().InnerText);
                            price = Convert.ToString(Price);
                            imageURl = Convert.ToString(ImgURL);
                            break;
                        case "ebay":
                            var product2 = htmlDocument.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("Body")).First();

                            var ImgURL2 = product2.Descendants("img").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("icImg")).First().GetAttributeValue("src", "");//Descendants("img").FirstOrDefault().GetAttributeValue("src", "");//.Trim('\r', '\n', '\t');
                            var ProductName2 = product2.Descendants("h1").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("itemTitle")).FirstOrDefault().InnerText.Replace("Details about  &nbsp;", "");//Descendants("img").FirstOrDefault().GetAttributeValue("src", "");//.Trim('\r', '\n', '\t');
                            var Price2 = product2.Descendants("span").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("prcIsum")).FirstOrDefault().InnerText;//.Replace("US $", "");//Descendants("img").FirstOrDefault().GetAttributeValue("src", "");//.Trim('\r', '\n', '\t');
                            var descriptions = product2.Descendants("div").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("viTabs_0_is")).FirstOrDefault().InnerText;// "This"  = firstName + " " + lastName + " is " + age + " years old.";
                                    
                            name = Convert.ToString(ProductName2);
                            description = Convert.ToString(descriptions);
                            price = Convert.ToString(Price2);
                            imageURl = Convert.ToString(ImgURL2);
                            break;
                        default:
                            //products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                    }
                }              
            }           
        }
        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        //public decimal price { get; private set; }
        public string price { get; private set; }
        public string imageURl { get; private set; }
    }
}