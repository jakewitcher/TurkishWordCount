using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Tests;

public class RulesApplicationRunnerTests
{
  [Fact]
  public void Run_MultipleRules_AllRulesAppliedCorrectly()
  {
    List<Word> words =
    [
      new("insanlar"),
      new("okulda"),
      new("dağlarda"),
      new("evden"),
      new("evet")
    ];

    List<IRule> rules = RuleFactory.CreateAll();

    var actual = RulesApplicationRunner.Run(rules, words).ToList();

    List<Word> expected =
    [
      new Word("insanlar", "insan", [$"{SuffixType.PluralNoun}Rule"]),
      new Word("okulda", "okul", [$"{SuffixType.LocativeCase}Rule"]),
      new Word("dağlarda", "dağ", [$"{SuffixType.LocativeCase}Rule", $"{SuffixType.PluralNoun}Rule"]),
      new Word("evden", "ev", [$"{SuffixType.AblativeCase}Rule"]),
      new Word("evet", "evet", ["DefaultRule"])
    ];

    Assert.Equal(words.Count, actual.Count);
    for (var i = 0; i < expected.Count; i++)
    {
      Assert.Equal(expected[i].Original, actual[i].Original);
      Assert.Equal(expected[i].Root, actual[i].Root);
      Assert.Equal(expected[i].RulesApplied, actual[i].RulesApplied);
    }
  }
}
