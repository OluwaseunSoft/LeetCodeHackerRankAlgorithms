using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHackerRankAlgorithms.SlidingWindow
{
    internal class SlidingWindow
    {
        /**
         * # Given a string s, find the length of the longest  substring without repeating characters. 

            # Example 1:
            # Input: s = "abcabcbb"
            # Output: 3

            # Explanation: The answer is "abc", with the length of 3.

            # Example 2:
            # Input: s = "bbbbb"
            # Output: 1

            # Explanation: The answer is "b", with the length of 1.

            # Example 3:
            # Input: s = "pwwkew"
            # Output: 3

            # Explanation: The answer is "wke", with the length of 3.

            # Notice that the answer must be a substring, "pwke" is a subsequence and not a substring. 
         */
        public int LongestSubString(string s)
        {
            try
            {
                int leftWindow = 0;
                int longestSubsting = 0;

                HashSet<char> chars = new HashSet<char>();

                for (int rightWindow = 0; rightWindow < s.Length; rightWindow++)
                {
                    while (chars.Contains(s[rightWindow]))
                    {
                        chars.Remove(s[leftWindow]);
                        leftWindow++;
                    }
                    chars.Add(s[rightWindow]);

                    longestSubsting = Math.Max(longestSubsting, rightWindow - leftWindow + 1);
                }
                return longestSubsting;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
