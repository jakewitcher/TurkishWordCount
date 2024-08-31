namespace TurkishWordCount.App.Tests.Models;

public record class RuleTestCase
{
  public string Original { get; }
  public string? Root { get; }
  public List<string> RulesApplied { get; }

  public RuleTestCase(string original, string? root, string ruleApplied)
  {
    Original = original;
    Root = root;
    RulesApplied = [ruleApplied];
  }

  public RuleTestCase(string original, string? root, List<string> rulesApplied)
  {
    Original = original;
    Root = root;
    RulesApplied = rulesApplied;
  }
}
