namespace GradeBook;

public class DiskBook : Book
{
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate? GradeAdded;

    public override void AddGrade(double grade)
    {
        File.Delete(Name);
        
        using var writer = File.AppendText(Name);
        writer.WriteLine(grade);
    }

    public override Statistics GetStatistics()
    {
        var values = File.ReadLines(Name);

        var lowerGrade = double.MaxValue;
        var higherGrade = double.MinValue;
        char letter = default;
        var total = 0.0;

        foreach (var value in values)
        {
            var grade = double.Parse(value);
            lowerGrade = Math.Min(lowerGrade, grade);
            higherGrade = Math.Max(higherGrade, grade);
            total += grade;
        }

        var averageGrade = total / values.Count();

        switch (averageGrade)
        {
            case var d when d >= 9:
                letter = 'A';
                break;
            case var d when d >= 8:
                letter = 'B';
                break;
            case var d when d >= 7:
                letter = 'C';
                break;
            case var d when d >= 6:
                letter = 'D';
                break;
            case var d when d >= 4:
                letter = 'E';
                break;
            default:
                letter = 'F';
                break;
        }

        return new() {
            Lower = lowerGrade,
            Higher = higherGrade,
            Average = averageGrade,
            Letter = letter
        };
    }
}