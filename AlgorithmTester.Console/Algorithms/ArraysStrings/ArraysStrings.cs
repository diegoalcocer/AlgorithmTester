using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;
using System;
using System.Security.Cryptography;

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

        public int RomanToInt(string s)
        {
            var n = s.Length;
            var dict = new Dictionary<char, int> {
                { 'I',1 },
                {'V', 5 },
                {'X', 10 },
                { 'L', 50},
                { 'C', 100},
                { 'D', 500},
                { 'M', 1000}
            };
            
            var result = 0;

            for (int i = 0; i < n; i++)
            {
                var digit = dict[s[i]];
                var nextDigit = i<n-1? dict[s[i+1]]: 0;
                
                if (nextDigit>digit)
                {
                    result += nextDigit - digit;
                    i++;
                }
                else
                {
                    result += digit;
                }                
            }

            // this line helps free memory
            GC.Collect();
            return result;
        }

        /// <summary>
        /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
        /// such that i != j, i != k, and j != k, 
        /// and nums[i] + nums[j] + nums[k] == 0.
        /// Notice that the solution set must not contain duplicate triplets.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            // a+b+c=0
            // a = -(b+c)
            // b+c = -a
            // nums = [-2, -1, 0, 1, 2, 3]
            //nums = [-8,-1,0,1,2,3,4,5,7]

            Array.Sort(nums);
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var start = i + 1;
                var end = nums.Length - 1;

                while (start < end)
                {
                    var sum = nums[end] + nums[start];

                    if (sum < -nums[i])
                    {
                        start++;
                    }
                    else if (sum > -nums[i])
                    {
                        end--;
                    }
                    else
                    {
                        result.Add(new List<int> { nums[i], nums[start], nums[end] });
                        start++;
                        end--;

                        while (start < end && nums[start] == nums[start - 1]) start++;
                        while (start < end && nums[end] == nums[end + 1]) end--;
                    }
                }
            }

            return result;
        }
    }
}
