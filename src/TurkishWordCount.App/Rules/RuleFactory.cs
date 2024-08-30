using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public static class RuleFactory
{
  private readonly static Dictionary<SuffixType, Suffix> _suffixes = new()
  {
    { SuffixType.AblativeCase, new Suffix(SuffixType.AblativeCase, ["dan", "den"])},
    { SuffixType.LocativeCase, new Suffix(SuffixType.LocativeCase, ["da", "de"])},
    { SuffixType.PluralNoun, new Suffix(SuffixType.PluralNoun, ["lar", "ler"])}
  };

  public static List<IRule> CreateAll()
  {
    return _suffixes.Values
      .Select(CreateRuleFrom)
      .Append(CreateDefaultRule())
      .ToList();
  }

  public static IRule CreateSuffixRule(SuffixType type)
  {
    if (!_suffixes.TryGetValue(type, out Suffix? s))
      throw new ArgumentException($"{nameof(type)} is not a valid suffix type");

    return CreateRuleFrom(s);
  }

  public static IRule CreateDefaultRule()
  {
    return new DefaultRule();
  }

  private static IRule CreateRuleFrom(Suffix s)
  {
    return new SuffixRule(RuleNameFrom(s.Type), s.Endings);
  }

  private static string RuleNameFrom(SuffixType type) => $"{type}Rule";
}
