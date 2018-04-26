using System;

namespace Sorts
{
	/// <summary>
	/// Iterate from 0 to n-1 inserting elements in their proper position by
	/// comparing ith element to ith+1 element using a greater than comparison.
	/// Worst case O(N^2)
	/// </summary>
	public class InsertionSort
	{
		private static void Insert<T>(T[] array, int rightIndex) where T : IComparable
		{
			T value = array [rightIndex + 1];

			while (rightIndex >= 0 && array[rightIndex].CompareTo(value) > 0) {
				array [rightIndex + 1] = array [rightIndex--];
			}

			array[rightIndex + 1] = value;
		}

		public static void Sort<T>(T[] array) where T : IComparable
		{
			int nMinusOne = array.Length - 1;
			for (int i = 0; i < nMinusOne; i++) {
				Insert (array, i);
			}
		}
	}
}

