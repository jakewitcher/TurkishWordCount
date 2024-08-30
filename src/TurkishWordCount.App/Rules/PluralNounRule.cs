using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public class PluralNounRule : IRule
{
  private readonly IEnumerable<string> _suffixes = ["lar", "ler"];

  public Word Apply(Word word)
  {
    if (word.TestRule(IsPlural))
    {
      word.ApplyRule(nameof(PluralNounRule), ToRoot);
    }

    return word;
  }

  private bool IsPlural(string word)
  {
    return _suffixes.Any(word.EndsWith);
  }

  private static string ToRoot(string word)
  {
    return word.Remove(word.Length - 3);
  }
}
