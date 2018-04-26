import java.util.ArrayList;
import java.util.List;

/**
 * Merge sort works by copying the source array into two different arrays/vectors/lists,
 * then merging those back into the source array in ordered fashion.
 * First the call stack is setup so that Merge works on the smallest pieces first, then
 * larger.O(NLogN) 
 * @author bradley
 *
 */
class MergeSort {

	private static <T extends Comparable<T>> void merge(T[] source, int left, int mid, int right){
		int i, j, k=left;
		List<T> lower = new ArrayList<>();
		List<T> upper = new ArrayList<>();
		
		for(i=left; i <= mid; i++) {
			lower.add(source[i]);
		}
		
		for(i=mid + 1; i <= right; i++) {
			upper.add(source[i]);
		}
		
		int n = lower.size(), m = upper.size();
		
		i=0; j=0;
		while(i < n && j < m) {
			T lowerElem = lower.get(i);
			T upperElem = upper.get(j);
			
			if(lowerElem.compareTo(upperElem) <= 0) {
				source[k++] = lowerElem;
				i++;
			}
			else {
				source[k++] = upperElem;
				j++;
			}
		}
		
		while(i < n) {
			source[k++] = lower.get(i++); 
		}
		
		while(j < m) {
			source[k++] = upper.get(j++); 
		}
		
	}
	
	static <T extends Comparable<T>> void sort(T[] source, int left, int right) {
		if(left < right) {
			int mid = (left + right) / 2;
			sort(source, left, mid);
			sort(source, mid + 1, right);
			merge(source, left, mid, right);
		}
	}
}
