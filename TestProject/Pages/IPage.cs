namespace TestProject.Pages;

public interface IPage
{
    /// <summary>
    /// String of characters used to uniquely identify a location
    /// </summary>
    /// <example> /wiki/path.html </example>
    public string Path { get; }
}