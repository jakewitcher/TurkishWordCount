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
      new("evet")
    ];

    List<IRule> rules =
    [
      new LocativeCaseRule(),
      new PluralNounRule(),
      new DefaultRule()
    ];

    var actual = RulesApplicationRunner.Run(rules, words).ToList();

    List<Word> expected =
    [
      new Word("insanlar", "insan", [nameof(PluralNounRule)]),
      new Word("okulda", "okul", [nameof(LocativeCaseRule)]),
      new Word("dağlarda", "dağ", [nameof(LocativeCaseRule), nameof(PluralNounRule)]),
      new Word("evet", "evet", [nameof(DefaultRule)])
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
