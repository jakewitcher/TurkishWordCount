using TurkishWordCount.App;
using TurkishWordCount.App.Rules;
using TurkishWordCount.App.Rules.Interfaces;

var dataPath = Path.Combine("src", "TurkishWordCount.App", "Data");
var inputFile = "chapter1.txt";
var outputFile = "chapter1.csv";

var input = File.ReadAllText(Path.Combine(dataPath, inputFile));

var words = WordsParser.Parse(input);
var rules = new List<IRule>()
{
  new LocativeCaseRule(),
  new PluralNounRule(),
  new DefaultRule()
};

var results = RulesApplicationRunner.Run(rules, words);
var counted = WordsCounter.Count(results);
var csv = CsvBuilder.Build(counted);

File.WriteAllText(Path.Combine(dataPath, outputFile), csv);