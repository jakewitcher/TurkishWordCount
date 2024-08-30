using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App;

public static class RulesApplicationRunner
{
  private static readonly IRule _defaultRule = RuleFactory.CreateDefaultRule();
  private static readonly HashSet<string> _ignoreList =
  [
    "birden",
    "de",
    "da",
    "ile",
    "neden",
  ];

  public static IEnumerable<Word> Run(IEnumerable<IRule> rules, IEnumerable<Word> words)
  {
    return words.Select(word =>
      _ignoreList.Contains(word.Original)
        ? _defaultRule.Apply(word)
        : rules.Aggregate(word, (w, rule) => rule.Apply(w)));
  }
}
