namespace TurkishWordCount.App.Models;

public record CountedWord
{
  public int Count { get; private set; }
  private readonly string _root;
  private readonly List<string> _words;

  public CountedWord(string root)
  {
    Count = 0;
    _root = root;
    _words = [];
  }

  public void Add(string word)
  {
    _words.Add(word);
    Count++;
  }

  public override string ToString()
  {
    return $"{_root},{Count},\"{string.Join(',', _words.Distinct())}\"";
  }
}
