using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Tests;

public class LocativeCaseRuleTests
{
  private readonly IRule _rule;

  public LocativeCaseRuleTests()
  {
    _rule = new LocativeCaseRule();
  }

  [Fact]
  public void Apply_RuleIsMatched_RootIsModified()
  {
    var before = new Word("okulda");

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal("okul", after.Root);
    Assert.Single(after.RulesApplied);
    Assert.Equal(nameof(LocativeCaseRule), after.RulesApplied[0]);
  }

  [Fact]
  public void Apply_RulesIsNotMatched_RootIsNotModified()
  {
    var before = new Word("okuldan");

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Null(after.Root);
    Assert.Empty(after.RulesApplied);
  }
}
