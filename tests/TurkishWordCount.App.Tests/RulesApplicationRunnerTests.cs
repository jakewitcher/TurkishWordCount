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
      new Word("okulda", "okul", [$"{SuffixType.LocativeCaseNoun}Rule"]),
      new Word("dağlarda", "dağ", [$"{SuffixType.LocativeCaseNoun}Rule", $"{SuffixType.PluralNoun}Rule"]),
      new Word("evden", "ev", [$"{SuffixType.AblativeCaseNoun}Rule"]),
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

  [Fact]
  public void Run_WordsFromIgnoreList_OnlyDefaultRuleIsApplied()
  {
    List<Word> words =
    [
      new("de"),
      new("da"),
      new("neden"),
      new("birden")
    ];

    List<IRule> rules = RuleFactory.CreateAll();

    var actual = RulesApplicationRunner.Run(rules, words).ToList();

    List<Word> expected =
    [
      new Word("de", "de", ["DefaultRule"]),
      new Word("da", "da", ["DefaultRule"]),
      new Word("neden", "neden", ["DefaultRule"]),
      new Word("birden", "birden", ["DefaultRule"]),
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
