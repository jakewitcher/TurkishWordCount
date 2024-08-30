using TurkishWordCount.App.Enums;

namespace TurkishWordCount.App.Models;

public record Suffix
{
  public SuffixType Type { get; set; }
  public List<string> Endings { get; set; }

  public Suffix(SuffixType type, List<string> endings)
  {
    Type = type;
    Endings = endings;
  }
}
