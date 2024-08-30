using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public class DefaultRule : IRule
{
  public Word Apply(Word word)
  {
    if (word.HasRulesApplied()) return word;

    word.ApplyRule(nameof(DefaultRule), ToRoot);

    return word;
  }

  private static string ToRoot(string word)
  {
    return word;
  }
}
