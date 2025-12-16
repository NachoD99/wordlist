using Wordlist.Domain;

var path = args.Length > 0 ? args[0] : "wordlist.txt";

var source = new FileWordSource(path);
var words = await source.LoadFile();

foreach (var word in words)
{
    Console.WriteLine(word);
}
