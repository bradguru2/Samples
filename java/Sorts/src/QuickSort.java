
/**
 * Quick sort secret is the Partition. It is an in-place sort. The Partition 
 * works very will with nearly sorted data and returns the pivot point.   
 * The pivot point will be sorted correctly in l..r.
 * 
 * Partition, then sort
 * @author bradley
 *
 */
class QuickSort {
	private static <T extends Comparable<T>> int partition(T[] source, int left, int right) {
		T temp;
		int q = left;
		
		for(int i=left; i < right; i++) {
			if(source[i].compareTo(source[right]) < 0) {
				temp = source[i];
				source[i] = source[q];
				source[q++] = temp;
			}
		}
		
		temp = source[right];
		source[right] = source[q];
		source[q] = temp;
		
		return q;
	}
	
	static <T extends Comparable<T>> void sort(T[] source, int left, int right){
		if(left < right) {
			int q = partition(source, left, right);
			//sort about the pivot point
			sort(source, left, q - 1);
			sort(source, q + 1, right);
		}
	}
}
