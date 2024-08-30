using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public class SuffixRule : IRule
{
  private readonly string _ruleName;
  private readonly List<string> _suffixes;
  private readonly int _endingLength;

  public SuffixRule(string ruleName, List<string> suffixes)
  {
    if (suffixes.Count is 0) throw new ArgumentException($"{nameof(suffixes)} cannot be empty");

    _ruleName = ruleName;
    _suffixes = suffixes;
    _endingLength = _suffixes[0].Length;
  }

  public Word Apply(Word word)
  {
    if (word.TestRule(EndsWithSuffix))
    {
      word.ApplyRule(_ruleName, ToRoot);
    }

    return word;
  }

  private bool EndsWithSuffix(string word)
  {
    return _suffixes.Any(word.EndsWith);
  }

  private string ToRoot(string word)
  {
    return word.Remove(word.Length - _endingLength);
  }
}
