using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                IList<int> result = new List<int>();

                // Step 1: Mark visited indices by negating the value at the index
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;  // get the index corresponding to the value
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];  // mark the index by negating the value
                    }
                }

                // Step 2: Collect all indices that are still positive
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1);  // Add 1 to the index to get the missing number
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            int[] result = new int[nums.Length];
            int start = 0, end = nums.Length - 1;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    result[start++] = num;  // Place even numbers at the beginning
                }
                else
                {
                    result[end--] = num;  // Place odd numbers at the end
                }
            }

            return result;
        }


        //// Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    // If we find the complement in the dictionary, return the indices
                    return new int[] { map[complement], i };
                }
                // Otherwise, add the current number with its index to the dictionary
                map[nums[i]] = i;
            }

            return new int[0]; // Return empty array if no solution
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // Sort the array first
            Array.Sort(nums);

            int n = nums.Length;

            // Maximum product can be from:

            return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
        }


        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 2);  // Converts the decimal number to a binary string
        }


        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            // Perform binary search
            while (left < right)
            {
                int mid = (left + right) / 2;

                // If the mid element is greater than the right element, the minimum is on the right side
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                // Otherwise, the minimum is on the left side or at mid
                else
                {
                    right = mid;
                }
            }

            // After the loop, left will point to the minimum element
            return nums[left];
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Negative numbers are not palindromes
            if (x < 0)
            {
                return false;
            }

            int original = x;
            int reversed = 0;

            // Reverse the number
            while (x > 0)
            {
                int lastDigit = x % 10;  // Get the last digit
                reversed = reversed * 10 + lastDigit;  // Append the last digit to the reversed number
                x /= 10;  // Remove the last digit from x
            }

            // Check if the reversed number is equal to the original
            return original == reversed;
        }


        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int a = 0, b = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;  // Compute the next Fibonacci number
                a = b;  // Move 'b' to 'a'
                b = temp;  // Move the computed Fibonacci number to 'b'f
            }

            return b;
        }

    }
}