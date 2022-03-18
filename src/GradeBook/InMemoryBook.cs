namespace GradeBook;
public class InMemoryBook : Book
{
    public InMemoryBook(string name) : base(name)
    {
        Grades = new List<double>();
        Name = name;
    }

    public List<double> Grades { get; set; }

    public override event GradeAddedDelegate? GradeAdded;

    public override void AddGrade(double grade)
    {
        if (grade < 0 || grade > 10)
            throw new ArgumentException($"The {nameof(grade)} {grade} is invalid.");

        Grades.Add(grade);

        if (GradeAdded != null)
        {
            GradeAdded(this, new EventArgs());
        }
    }

    public override Statistics GetStatistics()
    {
        var stats = new Statistics();
        foreach (var grade in Grades)
        {
            stats.Add(grade);
        }

        return stats;
    }
}