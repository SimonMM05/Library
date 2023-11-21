public class Page
{
    public string Content { get; }

    public Page(string content)
    {
        Content = content;
    }

    public int GetWordCount()
    {
        // This is a simple way to count words, you may need to enhance it based on your specific requirements
        char[] delimiters = new[] { ' ', '\r', '\n' };
        return Content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}