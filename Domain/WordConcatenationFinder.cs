namespace Wordlist.Domain;

public sealed class ConcatenationMatch
{
    public string LeftPart { get; }
    public string RightPart { get; }
    public string WholeWord { get; }

    public ConcatenationMatch(string leftPart, string rightPart, string wholeWord)
    {
        LeftPart = leftPart;
        RightPart = rightPart;
        WholeWord = wholeWord;
    }
}

public sealed class WordConcatenationFinder
{
    public IReadOnlyCollection<ConcatenationMatch> FindConcatenations(IReadOnlyCollection<string> words, int targetLength = 6)
    {
        if (words is null)
            throw new ArgumentNullException(nameof(words));

        var results = new List<ConcatenationMatch>();

        if (targetLength <= 1)
            return results;

        var set = new HashSet<string>(words);

        foreach (var wholeWord in words)
        {
            if (wholeWord.Length != targetLength)
                continue;

            for (int i = 1; i < wholeWord.Length; i++)
            {
                var leftPart = wholeWord.Substring(0, i);
                var rightPart = wholeWord.Substring(i);

                if (set.Contains(leftPart) && set.Contains(rightPart))
                {
                    results.Add(new ConcatenationMatch(leftPart, rightPart, wholeWord));
                    break;
                }
            }
        }
        return results;
    }
}
