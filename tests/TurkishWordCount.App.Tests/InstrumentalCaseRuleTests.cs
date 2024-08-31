using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;
using TurkishWordCount.App.Tests.Models;

namespace TurkishWordCount.App.Tests;

public class InstrumentalCaseRuleTests
{
  public static List<object[]> BackVowelTestCases =>
  [
    [new RuleTestCase("arkadaşımla", "arkadaşım", $"{SuffixType.InstrumentalCase}Rule")],
    [new RuleTestCase("arkadaşımlar", null, new List<string>())]
  ];

  public static List<object[]> FrontVowelTestCases =>
  [
    [new RuleTestCase("öğretmenle", "öğretmen", $"{SuffixType.InstrumentalCase}Rule")],
    [new RuleTestCase("öğretmenler", null, new List<string>())]
  ];

  private readonly IRule _rule;

  public InstrumentalCaseRuleTests()
  {
    _rule = RuleFactory.CreateSuffixRule(SuffixType.InstrumentalCase);
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
