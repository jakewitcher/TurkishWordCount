using TurkishWordCount.App.Models;

namespace TurkishWordCount.App.Rules.Interfaces;

public interface IRule
{
  Word Apply(Word word);
}
