namespace GenL.Presentation.ViewComponents.Time.Models;

public class TimeModel
{
    public DateTime Date { get; private set; }

    public TimeModel(bool isUtc)
    {
        Date = isUtc ? DateTime.UtcNow : DateTime.Now;
    }
}