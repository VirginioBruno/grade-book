namespace GradeBook;

public class Statistics
{
    public double Lower { get; set; }
    public double Higher { get; set; }
    public double Total { get; set; }
    public int Count { get; set; }
    public double Average => Total / Count;
    public char Letter
    {
        get
        {
            switch (Average)
            {
                case var d when d >= 9:
                    return 'A';
                case var d when d >= 8:
                    return 'B';
                case var d when d >= 7:
                    return 'C';
                case var d when d >= 6:
                    return 'D';
                case var d when d >= 4:
                    return 'E';
                default:
                    return 'F';
            }
        }
    }

    public void Add(double grade) 
    {
        Lower = Math.Min(Lower, grade);
        Higher = Math.Max(Higher, grade);
        Total += grade;
        Count += 1;
    }

    public Statistics()
    {
        Lower = double.MaxValue;
        Higher = double.MinValue;
        Total = 0.0;
    }
}