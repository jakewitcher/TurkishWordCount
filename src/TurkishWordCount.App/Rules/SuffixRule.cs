using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public class SuffixRule : IRule
{
  private readonly string _ruleName;
  private readonly List<string> _suffixes;

  public SuffixRule(string ruleName, List<string> suffixes)
  {
    if (suffixes.Count is 0) throw new ArgumentException($"{nameof(suffixes)} cannot be empty");

    _ruleName = ruleName;
    _suffixes = suffixes;
  }

  public Word Apply(Word word)
  {
    foreach (var suffix in _suffixes)
    {
      if (word.TestRule(EndsWithSuffix(suffix)))
      {
        word.ApplyRule(_ruleName, ToRoot(suffix));
        return word;
      }
    }

    return word;
  }

  private static Func<string, bool> EndsWithSuffix(string suffix)
  {
    return w => w.EndsWith(suffix);
  }

  private static Func<string, string> ToRoot(string suffix)
  {
    return w => w.Remove(w.Length - suffix.Length);
  }
}
