using AlgorithmTester.Console.Algorithms.ArraysStrings;

    while (true)
    {
        Console.WriteLine("1: Longest Substring no repeating characters");
        Console.WriteLine("2: String to Integer (atoi)");
        Console.WriteLine("3: Exit");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LongestSubstring();
                break;
            case "2":
            Atoi();
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

void LongestSubstring()
{
    var str = new ArraysStrings();
    Console.WriteLine("Given a string s, find the length of the longest substring without repeating characters: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;

    var result = str.LengthOfLongestSubstring(s);
    Console.WriteLine($"Result: {result}"); Console.WriteLine();
}
void Atoi()
{
    var str = new ArraysStrings();
    Console.WriteLine("Input string: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;

    var result = str.MyAtoi(s);
    Console.WriteLine($"Result: {result}"); Console.WriteLine();
}