using System;

namespace Sorts
{
	/// <summary>
	/// Selection sort works by finding the minimum element at each iteration of i..n
	/// and putting it in its proper place as the array is iterated one element at a time
	/// starting 0th index and ending (n-1)th index.
	/// </summary>
	public class SelectionSort
	{
		static int MinIndex<T>(T[] array, int start) where T : IComparable
		{
			int minIndex = start;

			for (int i = minIndex + 1; i < array.Length; i++) {
				if (array [i].CompareTo (array [minIndex]) < 0) {
					minIndex = i;
				}
			}

			return minIndex;
		}

		public static void Sort<T>(T[] array) where T : IComparable
		{
			for (int i=0; i < array.Length - 1; i++) {
				int minIndex = MinIndex<T> (array, i);
				T temp = array [i];
				array [i] = array [minIndex];
				array [minIndex] = temp;
			}
		}
	}
}

