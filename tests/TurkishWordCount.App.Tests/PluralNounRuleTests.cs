using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Tests;

public class PluralNounRuleTests
{
  private readonly IRule _rule;

  public PluralNounRuleTests()
  {
    _rule = RuleFactory.CreateSuffixRule(SuffixType.PluralNoun);
  }

  [Fact]
  public void Apply_RuleIsMatched_RootIsModified()
  {
    var before = new Word("insanlar");

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal("insan", after.Root);
    Assert.Single(after.RulesApplied);
    Assert.Equal($"{SuffixType.PluralNoun}Rule", after.RulesApplied[0]);
  }

  [Fact]
  public void Apply_RulesIsNotMatched_RootIsNotModified()
  {
    var before = new Word("insanını");

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Null(after.Root);
    Assert.Empty(after.RulesApplied);
  }
}
