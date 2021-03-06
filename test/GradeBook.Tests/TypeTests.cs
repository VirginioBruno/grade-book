using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{
    public delegate string WriteLogDelegate(string log);

    private int counter = 0;

    [Fact]
    public void WriteLogUsingDelegate() 
    {
        WriteLogDelegate writeLog = ReturnMessage;
        writeLog += ReturnMessage;
        writeLog += IncrementCounter;

        var result = writeLog("Hello!");

        Assert.Equal("hello!", result);
    }

    [Fact]
    public void ValueTypesAlsoPassByValue() 
    {
        var x = GetInt();
        SetInt(out x);

        Assert.Equal(42, x);
    }

    [Fact]
    public void StringsBehaveLikeValueTypes() 
    {
        var name = "Bruno";
        var upper = MakeUpperCase(name);

        Assert.Equal("BRUNO", upper);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects() 
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject() 
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
    }

    [Fact]
    public void CanSetNameFromReference() 
    {
        var book = GetBook("Book");
        SetName(book, "New Name");

        Assert.Equal("New Name", book.Name);
    }

    [Fact]
    public void CSharpCanPassByReference() 
    {
        var book = GetBook("Book");
        GetBookSetName(out book, "New Name");

        Assert.Equal("New Name", book.Name);
    }

    [Fact]
    public void CSharpIsPassByValue() 
    {
        var book = GetBook("Book");
        GetBookSetName(book, "New Name");

        Assert.Equal("Book", book.Name);
    }

    InMemoryBook GetBook(string name) 
    {
        return new InMemoryBook(name);
    }

    string ReturnMessage(string message) 
    {
        counter++;
        return message;
    }

    string IncrementCounter(string message) 
    {
        counter++;
        return message.ToLower();
    }

    void SetName(InMemoryBook book, string name)
    {
        book.Name = name;
    }

    void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }

    void GetBookSetName(out InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }

    void SetInt(out int x) 
    {
        x = 42;
    }

    int GetInt() 
    {
        return 3;
    }

    string MakeUpperCase(string parameter) 
    {
        return parameter.ToUpper();
    }
}