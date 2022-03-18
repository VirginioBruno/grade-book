namespace GradeBook;

public interface IBook 
{
    void AddGrade(double grade);
    public string Name { get; }
    public event GradeAddedDelegate? GradeAdded;
    Statistics GetStatistics();
}
