using System;
using System.Collections.Generic;

namespace Sorts
{
	/// <summary>
	/// Merge sort works by copying the source array into two different arrays/vectors/lists,
	/// then merging those back into the source array in ordered fashion.
	/// First the call stack is setup so that Merge works on the smallest pieces first, then
	/// larger.O(NLogN) 
	/// </summary>
	public class MergeSort
	{
		private static void Merge<T>(T[] array, int p, int q, int r) where T : IComparable
		{
			int k = p, i, j;
			List<T> lowerHalf = new List<T> ();
			List<T> upperHalf = new List<T> ();

			for (i=p; i <= q; i++) {
				lowerHalf.Add (array [i]);
			}
			for (i=q+1; i <= r; i++) {
				upperHalf.Add (array [i]);
			}

			i = 0; j = 0;

			while (i < lowerHalf.Count && j < upperHalf.Count) {
				if (lowerHalf [i].CompareTo (upperHalf [j]) <= 0) {
					array [k++] = lowerHalf [i++];
				} else {
					array [k++] = upperHalf [j++];
				}
			}

			while (i < lowerHalf.Count) {
				array [k++] = lowerHalf [i++];
			}

			while (j < upperHalf.Count) {
				array [k++] = upperHalf [j++];
			}
		}

		public static void Sort<T>(T[] array, int p, int r) where T : IComparable
		{
			if (p < r) {
				int q = (p + r) / 2;
				Sort (array, p, q);
				Sort (array, q + 1, r);
				Merge (array, p, q, r);
			}
		}
	}
}

