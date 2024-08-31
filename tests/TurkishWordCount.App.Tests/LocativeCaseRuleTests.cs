using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;
using TurkishWordCount.App.Tests.Models;

namespace TurkishWordCount.App.Tests;

public class LocativeCaseRuleTests
{
  public static List<object[]> BackVowelTestCases =>
[
  [new RuleTestCase("okulda", "okul", $"{SuffixType.LocativeCase}Rule")],
    [new RuleTestCase("okuldan", null, new List<string>())]
];

  public static List<object[]> FrontVowelTestCases =>
  [
    [new RuleTestCase("kilisede", "kilise", $"{SuffixType.LocativeCase}Rule")],
    [new RuleTestCase("kiliseden", null, new List<string>())]
  ];

  private readonly IRule _rule;

  public LocativeCaseRuleTests()
  {
    _rule = RuleFactory.CreateSuffixRule(SuffixType.LocativeCase);
  }

  [Theory, MemberData(nameof(BackVowelTestCases))]
  public void Apply_BackVowelSuffix(RuleTestCase testCase)
  {
    var before = new Word(testCase.Original);

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal(testCase.Root, after.Root);
    Assert.Equal(testCase.RulesApplied, after.RulesApplied);
  }

  [Theory, MemberData(nameof(FrontVowelTestCases))]
  public void Apply_FrontVowelSuffix(RuleTestCase testCase)
  {
    var before = new Word(testCase.Original);

    var after = _rule.Apply(before);

    Assert.Equal(before.Original, after.Original);
    Assert.Equal(testCase.Root, after.Root);
    Assert.Equal(testCase.RulesApplied, after.RulesApplied);
  }
}
