using System;

namespace Sorts
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			char[] buffer = {'b','d','c','a','z', 'g', 'f'};

			//QuickSort.Sort(buffer, 0, buffer.Length - 1);

			SelectionSort.Sort(buffer);

			//InsertionSort.Sort(buffer);
			//MergeSort.Sort(buffer, 0, buffer.Length - 1);

			foreach(char letter in buffer){
				Console.Write("{0} ", letter);
			}
		}
	}
}
