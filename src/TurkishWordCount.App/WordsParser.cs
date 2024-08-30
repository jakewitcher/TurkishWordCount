using TurkishWordCount.App.Extensions;
using TurkishWordCount.App.Models;

namespace TurkishWordCount.App;

public static class WordsParser
{
  public static IEnumerable<Word> Parse(string words)
  {
    return words.Clean()
      .Split(' ')
      .Select(w => new Word(w));
  }
}
