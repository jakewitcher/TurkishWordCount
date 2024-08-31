using TurkishWordCount.App.Enums;
using TurkishWordCount.App.Models;
using TurkishWordCount.App.Rules.Interfaces;

namespace TurkishWordCount.App.Rules;

public static class RuleFactory
{
  private readonly static Dictionary<SuffixType, Suffix> _suffixes = new()
  {
    { SuffixType.PastSimple, new Suffix(SuffixType.PresentContinuous,
      [
        "medim", "medin", "medi", "medik", "mediniz", "mediler",
        "madım", "madın", "madı", "madık", "madınız", "madılar",
        "dim", "din", "di", "dik", "diniz", "diler",
        "düm", "dün", "dü", "dük", "dünüz", "düler",
        "dım", "dın", "dı", "dık", "dınız", "dılar",
        "dum", "dun", "du", "duk", "dunuz", "dular",
        "tim", "tin", "ti", "tik", "tiniz", "tiler",
        "tüm", "tün", "tü", "tük", "tünüz", "tüler",
        "tım", "tın", "tı", "tık", "tınız", "tılar",
        "tum", "tun", "tu", "tuk", "tunuz", "tular"
      ]) },
    { SuffixType.PresentContinuous, new Suffix(SuffixType.PresentContinuous,
      [
        "miyorum", "miyorsun", "miyor", "miyoruz", "miyorsunuz", "miyorlar",
        "mıyorum", "mıyorsun", "mıyor", "mıyoruz", "mıyorsunuz", "mıyorlar",
        "iyorum", "iyorsun", "iyor", "iyoruz", "iyorsunuz", "iyorlar",
        "ıyorum", "ıyorsun", "ıyor", "ıyoruz", "ıyorsunuz", "ıyorlar"
      ]) },
    { SuffixType.AblativeCase, new Suffix(SuffixType.AblativeCase, ["dan", "den", "tan", "ten"]) },
    { SuffixType.InstrumentalCase, new Suffix(SuffixType.InstrumentalCase, ["la", "le"]) },
    { SuffixType.LocativeCase, new Suffix(SuffixType.LocativeCase, ["da", "de", "ta", "te"]) },
    { SuffixType.PluralNoun, new Suffix(SuffixType.PluralNoun, ["lar", "ler", "ları", "leri", "ların", "lerin"]) }
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
