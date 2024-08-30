using TurkishWordCount.App.Models;

namespace TurkishWordCount.App.Tests;

public class WordsParserTests
{
  [Fact]
  public void Parse_Paragraph_ListOfWords()
  {
    var input = "Merhaba, dünya! Nasılsın? Ben iyiyim. İstanbul'daki erkek kardeşim dedi ki \"Selam; Merhaba; Hey\".";

    var actual = WordsParser.Parse(input).ToList();

    var expected = new List<Word>()
    {
      new("merhaba"),
      new("dünya"),
      new("nasılsın"),
      new("ben"),
      new("iyiyim"),
      new("istanbuldaki"),
      new("erkek"),
      new("kardeşim"),
      new("dedi"),
      new("ki"),
      new("selam"),
      new("merhaba"),
      new("hey")
    };

    Assert.Equal(expected.Count, actual.Count);

    for (var i = 0; i < expected.Count; i++)
    {
      Assert.Equal(expected[i].Original, actual[i].Original);
      Assert.Equal(expected[i].Root, actual[i].Root);
      Assert.Equal(expected[i].RulesApplied, actual[i].RulesApplied);
    }
  }
}
