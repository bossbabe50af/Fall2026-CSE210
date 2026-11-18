public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verse;
    private readonly int _endVerse;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        string reference = $"{_book} {_chapter}:{_verse}";
        return _endVerse == _verse ? reference : $"{reference}-{_endVerse}";
    }
}
