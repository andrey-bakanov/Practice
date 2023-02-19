using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Medium
{
    internal class ArrayRotation
    {

        /*
         Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

 

            Example 1:

            Input: nums = [1,2,3,4,5,6,7], k = 3
            Output: [5,6,7,1,2,3,4]
            Explanation:
            rotate 1 steps to the right: [7,1,2,3,4,5,6]
            rotate 2 steps to the right: [6,7,1,2,3,4,5]
            rotate 3 steps to the right: [5,6,7,1,2,3,4]

            Example 2:

            Input: nums = [-1,-100,3,99], k = 2
            Output: [3,99,-1,-100]
            Explanation: 
            rotate 1 steps to the right: [99,-1,-100,3]
            rotate 2 steps to the right: [3,99,-1,-100]


             Example 3:

            Input: nums = [1,2,3,4,5,6,7,8,9], k = 6
            Output: [4,5,6,7,8,9,1,2,3]
     

        Constraints:

        1 <= nums.length <= 105
        -231 <= nums[i] <= 231 - 1
        0 <= k <= 105
 

        Follow up:

        Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
        Could you do it in-place with O(1) extra space?
         */
        public void Execute()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };

             Do(nums, 3);

            ArrayHelper.Dump(nums);

            var nums1 = new int[] { -1, -100, 3, 99 };
            Do(nums1, 2);

            ArrayHelper.Dump(nums1);

            var nums2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Do(nums2, 6);

            ArrayHelper.Dump(nums2);
        }

        private void Do(int[] a, int step)
        {
            if(step == 0)
                return;

            if (a.Length == 0)
                return;

            if (a.Length == 1)
                return;

            if (a.Length == 1)
                return;

            for (int i = 0; i<step; i++)
            {
                int buffer = a[i];
                for(int j=i; j < (a.Length+i); j++)
                {
                    int index = j;
                    int index2 = j + 1;
                    if (index >= a.Length)
                    {
                        index = j - a.Length;
                    }

                    if (index2 >= a.Length)
                    {
                        index2 = index2 - a.Length;
                    }

                    if (index >= a.Length && index2 == step)
                    {
                        break;
                    }

                    var tmp = a[index2];
                    a[index2] = buffer;
                    buffer = tmp;
                }
            }
        }
    }
}
