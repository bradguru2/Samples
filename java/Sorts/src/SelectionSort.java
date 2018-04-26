 /**
  * Selection sort works by finding the minimum element at each iteration of i..n
  * and putting it in its proper place as the array is iterated one element at a time
  * starting 0th index and ending (n-1)th index. 
  * @author bradley
  *
  */
class SelectionSort {

	private static <T extends Comparable<T>> int minIndex(T[] source, int start) {
		int minIndex = start, n = source.length;
		
		for(int i=start + 1; i < n; i++) {
			if(source[i].compareTo(source[minIndex]) < 0) {
				minIndex = i;
			}
		}
		
		return minIndex;
	}
	
	static <T extends Comparable<T>>void sort(T[] source) {
		int nMinusOne = source.length - 1;
		
		for(int i = 0; i < nMinusOne; i++) {
			int min = minIndex(source, i);
			
			T temp = source[i];
			source[i] = source[min];
			source[min] = temp;
		}
		
	}

	

}
