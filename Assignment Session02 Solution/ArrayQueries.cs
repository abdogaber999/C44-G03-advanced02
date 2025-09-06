using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session02_Solution
{
    internal class ArrayQueries
    {
        private int[] numbers;

        public ArrayQueries(int[] arr)
        {
            numbers = arr;
        }

        public int CountGreaterThan(int x)
        {
            int count = 0;
            foreach (var num in numbers)
            { 
                if (num > x) count++;
            }
            return count;
        }

    }
}
