using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Tests;

public class DefaultRuleTests
{
  private readonly IRule _rule;

  public DefaultRuleTests()
  {
    _rule = RuleFactory.CreateDefaultRule();
  }

  [Fact]
  public void Apply_WordHasNoRulesApplied_DefaultRuleIsApplied()
  {
    var before = new Word("insan");

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal(after.Original, after.Root);
    Assert.Single(after.RulesApplied);
    Assert.Equal(nameof(DefaultRule), after.RulesApplied[0]);
  }

  [Fact]
  public void Apply_WordHasRulesApplied_DefaultRulesIsNotApplied()
  {
    var before = new Word("insanlar", "insan", [$"{SuffixType.PluralNoun}Rule"]);

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal(before.Root, after.Root);
    Assert.Single(after.RulesApplied);
    Assert.Equal($"{SuffixType.PluralNoun}Rule", after.RulesApplied[0]);
  }
}
