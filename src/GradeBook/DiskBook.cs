namespace GradeBook;

public class DiskBook : Book
{
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate? GradeAdded;

    public override void AddGrade(double grade)
    {   
        using var writer = File.AppendText(Name);
        writer.WriteLine(grade);
    }

    public override Statistics GetStatistics()
    {
        var stats = new Statistics();
        var values = File.ReadLines(Name);

        foreach (var value in values)
        {
            stats.Add(double.Parse(value));
        }

        return stats;
    }
}