using Wordlist.Domain;

var path = args.Length > 0 ? args[0] : "wordlist.txt";
var targetLength = 6;

var source = new FileWordSource(path);
var words = await source.LoadFile();

var finder = new WordConcatenationFinder();
var matches = finder.FindConcatenations(words, targetLength);

foreach (var match in matches)
{
    Console.WriteLine($"{match.LeftPart} + {match.RightPart} => {match.WholeWord}");
}
