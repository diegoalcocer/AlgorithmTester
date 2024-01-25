using AlgorithmTester.Console.Algorithms.ArraysStrings;
using System.Security.Cryptography;

while (true)
{
    Console.WriteLine("1: Longest Substring no repeating characters");
    Console.WriteLine("2: String to Integer (atoi)");
    Console.WriteLine("3: Roman to integer");
    Console.WriteLine("4: Three Sum");
    Console.WriteLine("5: Remove Duplicates");
    Console.WriteLine("6: Next Permutation");
    Console.WriteLine("E: Exit");

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
            RomanToInt();
            break;
        case "4":
            ThreeSum();
            break;
        case "5":
            RemoveDuplicates();
            break;
        case "6":
            NextPermutation();
            break;
        case "E":
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
void RomanToInt()
{
    var str = new ArraysStrings();
    Console.WriteLine("Roman Number: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;

    var result = str.RomanToInt(s);
    Console.WriteLine($"Result: {result}"); Console.WriteLine();
}
void ThreeSum()
{
    var str = new ArraysStrings();
    Console.WriteLine("Numbers: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;
    var nums = s.Split(',').Where(n => !string.IsNullOrEmpty(n.Trim())).Select(int.Parse).ToArray();

    var triplets = str.ThreeSum(nums);
    Console.WriteLine($"Triplets found: ");
    foreach (var triplet in triplets)
    {
        Console.WriteLine($"[{string.Join(", ", triplet)}]");
    }
    Console.WriteLine();
}
void RemoveDuplicates()
{
    var str = new ArraysStrings();
    Console.WriteLine("Numbers: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;
    var nums = s.Split(',').Where(n => !string.IsNullOrEmpty(n.Trim())).Select(int.Parse).ToArray();

    var triplets = str.RemoveDuplicates(nums);
    
    Console.WriteLine();
}
void NextPermutation()
{
    var str = new ArraysStrings();
    Console.WriteLine("Numbers: ");
    var s = Console.ReadLine();

    s = string.IsNullOrEmpty(s) ? "" : s;
    var nums = s.Split(',').Where(n => !string.IsNullOrEmpty(n.Trim())).Select(int.Parse).ToArray();

    str.NextPermutation(nums);
    var res = string.Join(",", nums);
    
    Console.WriteLine($"Result: [{res}]");

    Console.WriteLine();
    Console.ReadLine();
}