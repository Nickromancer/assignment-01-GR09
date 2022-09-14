using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var pattern = @"(\w)+";
        foreach(string line in lines)
        {
            foreach(Match m in Regex.Matches(line, pattern))
            {
                yield return m.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        var pattern = @"(?'width'[0-9]+)x(?'height'[0-9]+)";
        foreach(Match m in Regex.Matches(resolutions, pattern))
        {
            yield return (Int32.Parse(m.Groups["width"].ToString()), Int32.Parse(m.Groups["height"].ToString()));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) 
    {
        var pattern = $@"<({tag}).*?>(?'inside'.*?)<\/\1>";
        foreach(Match m in Regex.Matches(html, pattern))
        {
            yield return Regex.Replace(m.Groups["inside"].ToString(), @"<\/?.*?>", ""); 
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) 
    {
        var pattern = @"<(a) href=""(?'url'.*?)""( title=""(?'title'.*?)"")?>([\w ]*?)<\/\1>";
        foreach(Match m in Regex.Matches(html, pattern))
        {
            yield return (new Uri(m.Groups["url"].ToString()), m.Groups["title"].ToString());
        }
    }
    public static IEnumerable<string> Urls(string html, string tag) 
    {
        return InnerText(html, tag);
    }
}