namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Resolution_given_input_of_1920x1080_returns_1920_1080() {
        // Arrange
        var resolution = new List<string>(){"1920x1080"};
        IEnumerable<(int width, int height)> list;
        var res1 = new List<Tuple<int, int>>
        {
            Tuple.Create(1920, 1080)
        };
        // Act
        list = RegExpr.Resolution(resolution);
        // Assert
        list.Should().BeEquivalentTo<Tuple<int, int>>(res1);
    }

    [Fact]
    public void Resolution_given_input_of_resolutions_with_newline_and_comma_return_output_of_resolutions() {
        // Arrange
        var resolution = new List<string>(){"1920x1080\n720x1000, 100x100"};
        IEnumerable<(int width, int height)> list;
        var res1 = new List<Tuple<int, int>>
        {
            Tuple.Create(1920, 1080),
            Tuple.Create(720, 1000),
            Tuple.Create(100, 100)

        };
        // Act
        list = RegExpr.Resolution(resolution);
        // Assert
        list.Should().BeEquivalentTo<Tuple<int, int>>(res1);
    }

    [Fact]
    public void Resolution_given_multiple_strings()
    {
        // Arrange
        var resolution = new List<string>(){"1920x1080", "720x1000", "100x100"};
        IEnumerable<(int width, int height)> list;
        var res1 = new List<Tuple<int, int>>
        {
            Tuple.Create(1920, 1080),
            Tuple.Create(720, 1000),
            Tuple.Create(100, 100)

        };
        // Act
        list = RegExpr.Resolution(resolution);
        // Assert
        list.Should().BeEquivalentTo<Tuple<int, int>>(res1);
    }

    [Fact]
    public void Splitline()
    {
        // Arrange
        List<string> list = new List<string> {"Hello world", "Lorem Ipsum", "Hi there Bob", "Bob is 9 years old"};

        // Act
        var result = RegExpr.SplitLine(list);

        // Assert
        var expected = new List<string> {"Hello", "world", "Lorem", "Ipsum", "Hi", "there", "Bob", "Bob", "is", "9", "years", "old"};
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void InnerText_given_HTML_code_and_tag_return_stream_of_titles()
    {
        // Arrange
        var tag = "a";
        var html = "<div>\n <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";
        var titles = new List<string> {
            "theoretical computer science",
            "formal language",
            "characters",
            "pattern",
            "string searching algorithms",
            "strings"
        };

        // Act
        var result = RegExpr.InnerText(html, tag);
        // Assert
        result.Should().BeEquivalentTo(titles);
    }
    
    [Fact]
    public void InnerText_nested_tags()
    {
        // Arrange
        var tag = "p";
        var html = "<div>\n\t<p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>\n</div>";
        var titles = new List<string> {
            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."
        };

        // Act
        var result = RegExpr.InnerText(html, tag);

        // Assert
        result.Should().BeEquivalentTo(titles);
    }
    [Fact]
    public void given_HTML_return_tuples_of_urls_and_titles()
    {
        // Arrange
        var html = "<div>\n <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> </p>\n</div>";
        var urlsAndTitles = new List<Tuple<Uri, string>> {
            Tuple.Create(new Uri ("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
            Tuple.Create(new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
            Tuple.Create(new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)")
        };

        // Act
        var result = RegExpr.Urls(html);

        // Assert
        result.Should().BeEquivalentTo(urlsAndTitles);
    }

    [Fact]
    public void given_HTML_return_tuples_of_urls_and_some_titles()
    {
        // Arrange
        var html = "<div>\n <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> </p>\n</div>";
        var urlsAndTitles = new List<Tuple<Uri, string>> {
            Tuple.Create(new Uri ("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
            Tuple.Create(new Uri("https://en.wikipedia.org/wiki/Formal_language"), ""),
            Tuple.Create(new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)")
        };

        // Act
        var result = RegExpr.Urls(html);

        // Assert
        result.Should().BeEquivalentTo(urlsAndTitles);
    }
    
}