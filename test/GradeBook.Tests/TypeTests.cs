using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{

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

    Book GetBook(string name) 
    {
        return new Book(name);
    }

    void SetName(Book book, string name)
    {
        book.Name = name;
    }

    void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
    }

    void GetBookSetName(out Book book, string name)
    {
        book = new Book(name);
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