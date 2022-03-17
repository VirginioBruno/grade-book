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

    public event GradeAddedDelegate GradeAdded;

    public void AddGrade(char grade)
    {
        var number = 0.0;
        switch (grade)
        {
            case 'A':
                number = 9;
                break;
            case 'B':
                number = 8;
                break;
            case 'C':
                number = 7;
                break;
            case 'D':
                number = 4;
                break;
            default:
                number = 0;
                break;
        } 
        
        AddGrade(number);
    }

    public void AddGrade(double grade)
    {
        if (grade < 0 || grade > 10)
            throw new ArgumentException($"The {nameof(grade)} {grade} is invalid.");

        Grades.Add(grade);

        if (GradeAdded != null)
        {
            GradeAdded(this, new EventArgs());
        }
    }

    public Statistics GetStatistics()
    {
        var lowerGrade = double.MaxValue;
        var higherGrade = double.MinValue;
        char letter = default;
        var total = 0.0;

        foreach (var grade in Grades)
        {
            lowerGrade = Math.Min(lowerGrade, grade);
            higherGrade = Math.Max(higherGrade, grade);
            total += grade;
        }

        var averageGrade = total / Grades.Count;

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