using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Parse_Blog
{
    public static class HtmlTextCleaner
    {
        /// <summary>
        /// Clean html chracters whitespace and new line from text
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>Reverse list of all text</returns>
        public static List<string> CleanBlogText(List<HtmlNode> nodes)
        {
            var cleanText = new List<string>();
            foreach (var item in nodes)
            {
                var text = Regex.Replace(item.InnerText, @"( |\t|\r?\n)\1+", "$1").Replace("&nbsp;", "");
                if (!String.IsNullOrEmpty(text))
                {
                    cleanText.Add(text);
                }

            }
            cleanText.Reverse();
            return cleanText;
        }

        /// <summary>
        /// Clean html string
        /// </summary>
        /// <param name="str">inner text</param>
        /// <returns>string</returns>
        public static string CleanSingleLine(string text)
        {
            string cleanText = Regex.Replace(text, @"\t|\n|\r", "").Replace("&nbsp;", "").Trim();
            cleanText = String.Join(' ', cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            return cleanText;
        }

    }
}
