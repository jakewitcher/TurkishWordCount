namespace TurkishWordCount.App.Models;

public record Word
{
  public string Original { get; }
  public string? Root { get; private set; }
  public IList<string> RulesApplied { get; }

  public Word(string original)
  {
    Original = original;
    RulesApplied = [];
  }

  public Word(string original, string modified, IList<string> rulesApplied)
  {
    if (rulesApplied.Count is 0)
      throw new ArgumentException($"{nameof(rulesApplied)} cannot be empty");

    Original = original;
    Root = modified;
    RulesApplied = rulesApplied;
  }

  public bool TestRule(Func<string, bool> condition)
  {
    return Root is not null
      ? condition(Root)
      : condition(Original);
  }

  public void ApplyRule(string ruleName, Func<string, string> toRoot)
  {
    Root = Root is not null
      ? toRoot(Root)
      : toRoot(Original);

    RulesApplied.Add(ruleName);
  }

  public bool HasRulesApplied()
  {
    return Root is not null && RulesApplied.Count is not 0;
  }
}
