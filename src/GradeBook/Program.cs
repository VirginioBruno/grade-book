using GradeBook;

var book = new Book("Bruno's Grade Book");
book.AddGrades(6, 7.5, 4.5, 5);

var statistics = book.GetStatistics();

Console.WriteLine($"The lower grade is {statistics.Lower}");
Console.WriteLine($"The higher grade is {statistics.Higher}");
Console.WriteLine($"The average grade is {statistics.Average}");
