using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace MyFirstWebScraper
{
    public class Scraper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public void ScrapeData(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var gfxcards = doc.DocumentNode.SelectNodes("//div[@class = 'grid-item js-listing-product']");



            foreach (var gfxcard in gfxcards)
            {
                EntryModel em = new EntryModel();
                em.GFXName =
                    HttpUtility.HtmlDecode(gfxcard.SelectSingleNode(".//h3[@class = 'grid-item__title']").InnerText);
                em.Price =
                    HttpUtility.HtmlDecode(gfxcard.SelectSingleNode(".//p[@class = 'price']").InnerText);
                _entries.Add(em);
            }
        }
    }
}
