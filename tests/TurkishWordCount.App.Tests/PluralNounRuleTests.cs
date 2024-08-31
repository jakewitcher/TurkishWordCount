using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;
using TurkishWordCount.App.Tests.Models;

namespace TurkishWordCount.App.Tests;

public class PluralNounRuleTests
{
  public static List<object[]> BackVowelTestCases =>
  [
    [new RuleTestCase("insanlar", "insan", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("insanları", "insan", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("insanların", "insan", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("insanı", null, new List<string>())]
  ];

  public static List<object[]> FrontVowelTestCases =>
  [
    [new RuleTestCase("köpekler", "köpek", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("köpekleri", "köpek", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("köpeklerin", "köpek", $"{SuffixType.PluralNoun}Rule")],
    [new RuleTestCase("köpeği", null, new List<string>())]
  ];

  private readonly IRule _rule;

  public PluralNounRuleTests()
  {
    _rule = RuleFactory.CreateSuffixRule(SuffixType.PluralNoun);
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
