namespace GradeBook;

public abstract class NamedObject 
{
    public string Name { get; set; }
    
    public NamedObject(string name)
    {
        Name = name;
    }
}