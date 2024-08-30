using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public class LocativeCaseRule : IRule
{
  private readonly IEnumerable<string> _suffixes = ["da", "de"];

  public Word Apply(Word word)
  {
    if (word.TestRule(IsLocativeCase))
    {
      word.ApplyRule(nameof(LocativeCaseRule), ToRoot);
    }

    return word;
  }

  private bool IsLocativeCase(string word)
  {
    return _suffixes.Any(word.EndsWith);
  }

  private static string ToRoot(string word)
  {
    return word.Remove(word.Length - 2);
  }
}
