using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;
using System;

namespace AlgorithmTester.Console.Algorithms.ArraysStrings
{
    public class ArraysStrings
    {

        /// <summary>
        /// Given a string s, find the length of the longest substring without repeating characters.
        /// Example 1:
        /// Input: s = "abcabcbb"
        /// Output: 3
        /// Explanation: The answer is "abc", with the length of 3.
        /// Example 2:
        /// Input: s = "bbbbb"
        /// Output: 1
        /// Explanation: The answer is "b", with the length of 1.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public (int, string) LengthOfLongestSubstring(string s)
        {
            int n = s.Length, res = 0;
            var dict = new Dictionary<char, int>();
            var startIndex = 0;
            for (int i = 0, j = 0; j < n; j++)
            {
                if (dict.ContainsKey(s[j]))
                {
                    i = Math.Max(i, dict[s[j]] + 1);
                }
                //"abcda"=> 3-0 = 3 + 1= 4 => abcd

                if (res < (j - i + 1))
                {
                    startIndex = i;
                }

                res = Math.Max(res, j - i + 1);
                dict[s[j]] = j;
            }
            var longestSubstring = s.Substring(startIndex, res);

            return (res, longestSubstring);
        }


        /// <summary>
        /// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
        /// The algorithm for myAtoi(string s) is as follows:
        /// Read in and ignore any leading whitespace.
        /// Check if the next character(if not already at the end of the string) is '-' or '+'. 
        /// Read this character in if it is either.This determines if the final result is negative or positive respectively. 
        /// Assume the result is positive if neither is present.
        /// Read in next the characters until the next non-digit character or the end of the input is reached.The rest of the string is ignored.
        /// Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
        /// If the integer is out of the 32-bit signed integer range[-231, 231 - 1], then clamp the integer so that it remains in the range.Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
        /// Return the integer as the final result.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            var index = 0;
            var sign = 1;
            var n = s.Length;
            int res = 0;

            //'     -1234'
            while (s[index] == ' ') {
                index++;
            }

            if (s[index] == '-')
            {
                sign = -1;
                index++;
            }

            while (index<n && char.IsDigit(s[index])){
                var digit = s[index] - '0';

                if (res > int.MaxValue / 10 || (res == int.MaxValue/10 && digit > int.MaxValue % 10))
                {
                    return sign == -1 ? int.MinValue : int.MaxValue;
                }

                res = res * 10 + digit;

                index++;
            }
            return res*sign;
        }

    }
}
