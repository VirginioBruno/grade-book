using GradeBook;

var book = new DiskBook("Bruno's Grade Book");
book.GradeAdded += OnGradeAdded;

EnterGrades(book);

var statistics = book.GetStatistics();

Console.WriteLine($"The lower grade is {statistics.Lower}");
Console.WriteLine($"The higher grade is {statistics.Higher}");
Console.WriteLine($"The average grade is {statistics.Average}");
Console.WriteLine($"The letter is {statistics.Letter}");

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