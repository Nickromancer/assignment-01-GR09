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
        var pattern = $@"<(?<tag>{tag}).*?>(?<text>.*?)<\/\1>"; 
        foreach (Match m in Regex.Matches(tag, pattern))
        {
            yield return ()
        }
    }
}