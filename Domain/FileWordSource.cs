namespace Wordlist.Domain;

public sealed class FileWordSource
{
    private readonly string _path;

    public FileWordSource(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path not found", nameof(path));
        _path = path;
    }

    public async Task<IReadOnlyCollection<string>> LoadFile()
    {
        if (!File.Exists(_path))
            throw new FileNotFoundException($"Word list file not found: '{_path}'", _path);

        var lines = await File.ReadAllLinesAsync(_path);

        var words = lines
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => l.ToLowerInvariant())
            .ToArray();

        return words;
    }
}
