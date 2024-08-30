using TurkishWordCount.App.Models;

namespace TurkishWordCount.App;

public static class WordsCounter
{
  public static IEnumerable<CountedWord> Count(IEnumerable<Word> words)
  {
    var countDict = new Dictionary<string, CountedWord>();

    foreach (var word in words)
    {
      if (word.Root is null) continue;

      if (!countDict.ContainsKey(word.Root))
      {
        var newCountedWord = new CountedWord(word.Root);
        countDict.Add(word.Root, newCountedWord);
      }

      var countedWord = countDict[word.Root];
      countedWord.Add(word.Original);
    }

    return countDict.Values.OrderByDescending(w => w.Count);
  }
}
