using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session02_Solution
{
    internal class ArrayPalindrome
    {
        private int[] arr;

        public ArrayPalindrome(int[] array)
        {
            arr = array;
        }

        public bool IsPalindrome()
        {
            int n = arr.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (arr[i] != arr[n - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
