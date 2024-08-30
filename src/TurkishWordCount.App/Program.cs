using TurkishWordCount.App;
using TurkishWordCount.App.Rules;

var dataPath = Path.Combine("src", "TurkishWordCount.App", "Data");
var inputFile = "chapter1.txt";
var outputFile = "chapter1.csv";

var input = File.ReadAllText(Path.Combine(dataPath, inputFile));

var words = WordsParser.Parse(input);
var rules = RuleFactory.CreateAll();

var results = RulesApplicationRunner.Run(rules, words);
var counted = WordsCounter.Count(results);
var csv = CsvBuilder.Build(counted);

File.WriteAllText(Path.Combine(dataPath, outputFile), csv);