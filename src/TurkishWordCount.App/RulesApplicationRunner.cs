using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App;

public static class RulesApplicationRunner
{
  public static IEnumerable<Word> Run(IEnumerable<IRule> rules, IEnumerable<Word> words)
  {
    return words.Select(w =>
      rules.Aggregate(w, (acc, ele) => ele.Apply(acc)));
  }
}
