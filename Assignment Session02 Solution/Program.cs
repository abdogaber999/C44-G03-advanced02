using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Assignment_Session02_Solution
{
    internal class Program
    {
        #region Q4- IsBalanced
        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
        #endregion

        #region Q5- RemoveDuplicates
        static int[] RemoveDuplicates(int[] arr)
        {
            HashSet<int> set = new HashSet<int>(arr);
            int[] result = new int[set.Count];
            set.CopyTo(result);
            return result;
        }
        #endregion

        #region Q6- RemoveOddNumbers
        static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int num = (int)list[i];
                if (num % 2 != 0)  // odd number
                {
                    list.RemoveAt(i);
                }
            }
        }
        #endregion

        #region Q8- SearchInteger
        static Stack<int> PushSeries(int[] numbers)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int num in numbers)
            {
                stack.Push(num);
            }
            return stack;
        }

        static void SearchTarget(Stack<int> stack, int target)
        {
            int count = 0;
            bool found = false;

            foreach (int item in stack)
            {
                count++;
                if (item == target)
                {
                    Console.WriteLine($"Target was found successfully and the count = {count}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Target was not found");
            }
        }
        #endregion

        #region Q9- InstructsArray
        static List<int> IntersectArrays(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            List<int> result = new List<int>();

            // Count frequency of elements in arr1
            foreach (int num in arr1)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }

            // Check arr2 against the frequency dictionary
            foreach (int num in arr2)
            {
                if (freq.ContainsKey(num) && freq[num] > 0)
                {
                    result.Add(num);
                    freq[num]--; // decrease count
                }
            }

            return result;
        }
        #endregion

        #region Q10- FindingSubList
        static void FindSubList(ArrayList list, int target)
        {
            int start = 0;
            int currentSum = 0;

            for (int end = 0; end < list.Count; end++)
            {
                currentSum += (int)list[end];

                while (currentSum > target && start <= end)
                {
                    currentSum -= (int)list[start];
                    start++;
                }

                if (currentSum == target)
                {
                    Console.Write("contiguous sub list : [");
                    for (int i = start; i <= end; i++)
                    {
                        Console.Write(list[i]);
                        if (i < end) Console.Write(", ");
                    }
                    Console.WriteLine("]");
                    return;
                }
            }

            Console.WriteLine("No sub list found with the given sum");
        }
        #endregion

        #region Q11- ReverseFirstK
        static void ReverseFirstK(Queue<int> queue, int k)
        {
            if (k <= 0 || k > queue.Count)
            {
                Console.WriteLine("Invalid value of K");
                return;
            }

            Stack<int> stack = new Stack<int>();

            // Step 1: Dequeue first K elements into stack
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            // Step 2: Push them back into queue 
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            // Step 3: Move the returns elements to the back
            int size = queue.Count;
            for (int i = 0; i < size - k; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
        #endregion

        static void Main(string[] args)
        {
            #region Q1- Given an array  consists of  numbers with size N and number of queries, in each query you will be given an integer X, and you should print how many numbers in array that is greater than  X.

            Console.Write("Size Of Array : ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("No. Of Queries : ");
            int q = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter Array Elements:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            ArrayQueries queryHandler = new ArrayQueries(arr);

            int[] queries = new int[q];
            for (int i = 0; i < q; i++)
            {
                Console.Write($"Query {i + 1} : ");
                queries[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nOutput:");
            for (int i = 0; i < q; i++)
            {
                int result = queryHandler.CountGreaterThan(queries[i]);
                Console.WriteLine($"  Query {i + 1} : {result}");
            }


            #endregion

            #region Q2- Given a number N and an array of N numbers. Determine if it's palindrome or not.

            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            ArrayPalindrome palindromeChecker = new ArrayPalindrome(arr);

            if (palindromeChecker.IsPalindrome())
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

            #endregion

            #region Q3- Given a Queue, implement a function to reverse the elements of a queue using a stack.

            Queue<int> myQueue = new Queue<int>();

            Console.Write("Enter number of elements in Queue: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                myQueue.Enqueue(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("\nQueue before reversing:");
            foreach (var item in myQueue)
                Console.Write(item + " ");

            QueueReverser.ReverseQueue(myQueue);

            Console.WriteLine("\n\nQueue after reversing:");
            foreach (var item in myQueue)
                Console.Write(item + " ");


            #endregion

            #region Q4- Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.

            Console.Write("Enter parentheses string: ");
            string input = Console.ReadLine();

            if (IsBalanced(input))
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("Not Balanced");

            #endregion

            #region Q5- Given an array, implement a function to remove duplicate elements from an array.

            Console.Write("Enter numbers separated by space: ");
            string[] input = Console.ReadLine().Split();
            int[] arr = Array.ConvertAll(input, int.Parse);

            int[] uniqueArr = RemoveDuplicates(arr);

            Console.WriteLine("Array without duplicates: " + string.Join(" ", uniqueArr));

            #endregion

            #region Q6- Given an array list , implement a function to remove all odd numbers from it.

            ArrayList numbers = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8 };

            Console.WriteLine("Before: " + string.Join(" ", numbers.ToArray()));

            RemoveOddNumbers(numbers);

            Console.WriteLine("After: " + string.Join(" ", numbers.ToArray()));

            #endregion

            #region Q7- Implement a queue that can hold different data types. And insert the following data:  1-queue.Enqueue(1) 2-queue.Enqueue(“Apple”) 3-queue.Enqueue(5.28)

            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue("Apple");
            queue.Enqueue(5.28);

            Console.WriteLine("Items in queue:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Q8- Create a function that pushes a series of integers onto a stack. Then, search for a target integer in the stack. If the target is found, print a message indicating that the target was found and how many elements were checked before finding the target (“Target was found successfully and the count = 5”). If the target is not found, print a message indicating that the target was not found(“Target was not found”).

            int[] numbers = { 10, 20, 30, 40, 50 };
            Stack<int> stack = PushSeries(numbers);

            Console.WriteLine("Numbers in stack:");
            foreach (int num in stack)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("\nEnter target to search: ");
            int target = int.Parse(Console.ReadLine());

            SearchTarget(stack, target);

            #endregion

            #region Q9- Given two arrays, find their intersection. Each element in the result should appear as many times as it shows in both arrays.

            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };

            List<int> intersection = IntersectArrays(arr1, arr2);

            Console.WriteLine("[" + string.Join(", ", intersection) + "]");

            #endregion

            #region Q10- Given an ArrayList of integers and a target sum, find if there is a contiguous sub list that sums up to the target.

            ArrayList list = new ArrayList() { 1, 2, 3, 7, 5 };
            int target = 12;

            Console.WriteLine("ArrayList: [1, 2, 3, 7, 5]");
            Console.WriteLine("Target sum: 12");

            FindSubList(list, target);

            #endregion

            #region Q11- Given a queue reverse first K elements of a queue, keeping the remaining elements in the same order

            Queue<int> queue = new Queue<int>(new int[] { 1, 2, 3, 4, 5 });

            int K = 3;

            Console.WriteLine("Original Queue: " + string.Join(", ", queue));

            ReverseFirstK(queue, K);

            Console.WriteLine("Result: " + string.Join(", ", queue));

            #endregion
        }
    }
}
