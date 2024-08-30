using System.Text;
using TurkishWordCount.App.Models;

namespace TurkishWordCount.App;

public static class CsvBuilder
{
  public static string Build(IEnumerable<CountedWord> words)
  {
    var sb = new StringBuilder();
    AppendHeader(sb);

    foreach (var word in words)
    {
      sb.Append(word.ToString());
      sb.Append(Environment.NewLine);
    }

    return sb.ToString();
  }

  private static void AppendHeader(StringBuilder sb)
  {
    sb.Append("Root");
    sb.Append(',');
    sb.Append("Count");
    sb.Append(',');
    sb.Append("Words");
    sb.Append(Environment.NewLine);
  }
}
