using System;

namespace Sorts
{
	/// <summary>
	/// Quick sort secret is the Partition. The Partition works very will with nearly
	/// sorted data.  It is an in-place sort.
	/// 
	/// Three indexes involved in the merge. 
	/// </summary>
	public class QuickSort
	{
		public static int Partition<T>(T[] array, int p, int r) where T : IComparable
		{
			int q = p;
			T temp;

			for (int j = p; j < r; j++) 
			{
				if (array [j].CompareTo(array [r]) <= 0) {
					temp = array [j];
					array [j] = array [q];
					array [q++] = temp;
				}
			}

			temp = array [r];
			array [r] = array [q];
			array [q] = temp;

			return q;
		}

		public static void Sort<T>(T[] array, int p, int r) where T : IComparable
		{
			if (p < r) {
				int q = Partition (array, p, r);

				Sort (array, p, q - 1);
				Sort (array, q + 1, r);
			}
		}
	}
}

