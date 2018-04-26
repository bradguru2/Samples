/**
 * Iterate from 0 to n-1 inserting elements in their proper position by
 * comparing ith element to ith+1 element using a greater than comparison.
 * Worst case O(N^2)
 * @author bradley
 *
 */
class InsertionSort {
	private static <T extends Comparable<T>> void insert(T[] source, int rightIndex) 
	{
		T value = source[rightIndex + 1];
		
		while(rightIndex >= 0 && source[rightIndex].compareTo(value) > 0) {
			source[rightIndex + 1] = source[rightIndex--];
		}
		
		source[rightIndex + 1] = value;
	}
	
	static <T extends Comparable<T>> void sort(T[] source) 
	{
		int nMinusOne = source.length - 1;
		
		for(int i=0; i < nMinusOne; i++) {
			insert(source, i);
		}
	}
}
