using TurkishWordCount.App.Extensions;

namespace TurkishWordCount.App.Tests;

public class StringExtensionsTests
{
    [Fact]
    public void Clean_IncludesPunctuation_IsStripped()
    {
        var input = "Merhaba, dünya! Nasılsın? Ben iyiyim. İstanbul'daki erkek kardeşim dedi ki \"Selam; Merhaba; Hey\".";

        var actual = input.Clean();
        var expected = "merhaba dünya nasılsın ben iyiyim istanbuldaki erkek kardeşim dedi ki selam merhaba hey";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clean_IncludesNewlines_IsStripped()
    {
        var input = "Merhaba\ndünya\r\n";

        var actual = input.Clean();
        var expected = "merhaba dünya ";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clean_IncludesNumbers_IsStripped()
    {
        var input = "6Merha45ba1";

        var actual = input.Clean();
        var expected = "merhaba";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clean_IncludesTabs_IsStripped()
    {
        var input = "\tMerhaba dünya";

        var actual = input.Clean();
        var expected = " merhaba dünya";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clean_IncludesConsecutiveSpaces_IsStripped()
    {
        var input = "merhaba   dünya                 nasılsınız";

        var actual = input.Clean();
        var expected = "merhaba dünya nasılsınız";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clean_IncludesAllInvalidCharTypes_IsStripped()
    {
        var input = "Merhaba, dünya!\n Nasılsın? Ben iyiyim.\r\n İstanbul'daki erkek kardeşim dedi ki \t\"Selam;    Merhaba;         Hey\".";

        var actual = input.Clean();
        var expected = "merhaba dünya nasılsın ben iyiyim istanbuldaki erkek kardeşim dedi ki selam merhaba hey";

        Assert.Equal(expected, actual);
    }
}
