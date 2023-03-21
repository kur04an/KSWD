using HtmlAgilityPack;

namespace KSWD.Utils
{
    public class SteamParser
    {
        HtmlWeb web;
        public SteamParser()
        {
            web = new();
        }
        public string? GetContentByXPath(string link, string xpath)
        {

            var doc = web.Load(link);
            var nodes = doc.DocumentNode.SelectNodes(xpath);

            if (nodes is null) return null;

            foreach (var node in nodes)
            {
                return node.InnerText;
            }

            return null;
        }
        public string? GetAttributeValueByXPath(string link, string xpath)
        {
            var doc = web.Load(link);
            var node = doc.DocumentNode.SelectSingleNode(xpath).GetAttributeValue("href", "");
            if (node == null) return null;
            return node;
        }

    }
}
