namespace ConsoleApp1.lib
{
    public record Person(
        string FirstName,
        string LastName,
        int Age = 0,
        int Id = 0
    );
}