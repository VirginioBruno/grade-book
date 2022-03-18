using GradeBook;

IBook book = CreateBook();
EnterGrades(book);

var statistics = book.GetStatistics();

DisplayStats(statistics);

static void OnGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Grade added to the book");
}

static void EnterGrades(IBook book)
{
    while (true)
    {
        Console.WriteLine("Enter a grade or 'q' to exit");
        var input = Console.ReadLine();

        if (input == "q")
            break;

        try
        {
            var grade = 0.0;
            if (double.TryParse(input, out grade))
                book.AddGrade(grade);
            else
                throw new ArgumentException("The input must be a number between 0 and 10");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

static IBook CreateBook()
{
    var name = GetBookName();
    var type = GetBookType();

    IBook book;

    if (type == (int)BookType.Disk)
        book = new DiskBook(name);
    else
        book = new InMemoryBook(name);

    book.GradeAdded += OnGradeAdded;
    return book;
}

static void DisplayStats(Statistics statistics)
{
    Console.WriteLine($"The lower grade is {statistics.Lower}");
    Console.WriteLine($"The higher grade is {statistics.Higher}");
    Console.WriteLine($"The average grade is {statistics.Average}");
    Console.WriteLine($"The letter is {statistics.Letter}");
}

static int GetBookType()
{
    Console.WriteLine($"Enter the book type, disk(0) inmemory(1)");
    var inputBookType = Console.ReadLine();

    var type = 0;
    var parseFailed = !int.TryParse(inputBookType, out type);

    if (parseFailed)
    {
        Console.WriteLine($"Book type set to {nameof(BookType.InMemory)}");
    }

    return type;
}

static string GetBookName()
{
    Console.WriteLine($"Enter the name of the book");
    var name = Console.ReadLine();

    if (string.IsNullOrEmpty(name))
    {
        var genericName = "Book Name";
        Console.WriteLine($"Book name set to {genericName}");
        name = genericName;
    }

    return name;
}