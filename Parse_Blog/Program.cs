using HtmlAgilityPack;

namespace Parse_Blog
{
    /// <summary>
    /// Created: 23.08.22
    /// Author:  Aliyev Orkhan
    /// </summary>
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();

                HtmlDocument doc = await web.LoadFromWebAsync("https://www.wakeupdata.com/blog/news-we-are-now-premium-google-css-partners");

                var blogTitle = doc.DocumentNode.SelectNodes("//div/h1").First().InnerText ?? throw new ArgumentNullException();

                //I'm not sure if it is needed on the assignment, but I also added
                var postDateInfo = doc.DocumentNode.SelectNodes("//div[2]/p").First().InnerText ?? throw new ArgumentNullException();

                var blogAllText = doc.DocumentNode.SelectNodes("//*[@id=\"hs_cos_wrapper_post_body\"]/p").ToList() ?? throw new ArgumentNullException();


                // enables showing the euro symbol in the console
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                var result = HtmlTextCleaner.CleanBlogText(blogAllText);

                result.ForEach(x => Console.WriteLine(x));
                Console.WriteLine(HtmlTextCleaner.CleanSingleLine(postDateInfo));
                Console.WriteLine(HtmlTextCleaner.CleanSingleLine(blogTitle));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}