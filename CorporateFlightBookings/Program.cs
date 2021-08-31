using System;

namespace CorporateFlightBookings
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] bookings = new int[3][]
                {
                    new int[3]{1,2,10},
                    new int[3]{2,3,20},
                    new int[3]{2,5,25}
                };

            Console.WriteLine(string.Join(',', CorpFlightBookings(bookings, 5)));
        }

        static int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] nums = new int[n];
            foreach (var booking in bookings)
            {
                nums[booking[0] - 1] += booking[2];
                if(booking[1] < n)
                    nums[booking[1]] -= booking[2];
            }

            for(int i = 1; i < n; i++)
            {
                nums[i] += nums[i - 1];
            }
            return nums;
        }
    }
}
