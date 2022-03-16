namespace GradeBook;
public class Book
{
    public Book(string name)
    {
        Grades = new List<double>();
        Name = name;
    }

    public List<double> Grades { get; set; }

    public string Name { get; set; }

    public void AddGrades(params double[] grades) 
    {
        Grades.AddRange(grades);
    }

    public Statistics GetStatistics()
    {
        var lowerGrade = double.MaxValue;
        var higherGrade = double.MinValue;
        var total = 0.0;

        foreach (var grade in Grades)
        {
            lowerGrade = Math.Min(lowerGrade, grade);
            higherGrade = Math.Max(higherGrade, grade);
            total += grade;
        }

        var averageGrade = total / Grades.Count;

        return new() {
            Lower = lowerGrade,
            Higher = higherGrade,
            Average = averageGrade
        };
    }
 }