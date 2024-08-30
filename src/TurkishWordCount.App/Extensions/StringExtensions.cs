using System.Text;

namespace TurkishWordCount.App.Extensions;

public static class StringExtensions
{
  private static readonly char[] _whitespace = ['\n', '\r', '\t'];
  private static readonly char _space = ' ';

  public static string Clean(this string s)
  {
    var sb = new StringBuilder();
    var spaces = 0;

    foreach (var c in s)
    {
      if (_whitespace.Contains(c) || char.IsPunctuation(c)) continue;

      spaces = c.Equals(_space) ? spaces += 1 : 0;
      if (spaces > 1) continue;

      sb.Append(char.ToLower(c));
    }

    return sb.ToString();
  }
}
