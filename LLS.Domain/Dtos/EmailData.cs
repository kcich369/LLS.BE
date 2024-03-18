namespace LLS.Domain.Dtos;

public class EmailData
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string HtmlMessage { get; set; }
    public IEnumerable<string> Bccs { get; set; } = new List<string>();
}