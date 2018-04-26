import java.util.ArrayList;
import java.util.List;
import java.util.function.Function;

/**
 * The idea behind bucket sort resembles hashing a lot.  I want to call it hash
 * sort, but the order of the buckets do matter.
 * Create N buckets.
 * Sub-divide the data into N buckets
 * Sort the data in the buckets
 * Copy the data from the buckets back into the source array
 * @author bradley
 *
 */
class BucketSort {
	static <T extends Comparable<T>> void sort(T[] source, int numberOfBuckets, Function<T, Integer> hasher) {
		Object[] buckets = new Object[numberOfBuckets];
		int n = source.length, i;
		
		for(i = 0; i < n; i++) {
			int hashKey = hasher.apply(source[i]); 
			
			if(buckets[hashKey] == null) {
				buckets[hashKey] = new ArrayList<T>();
			}
			
			@SuppressWarnings("unchecked")
			List<T> bucket = (List<T>)buckets[hashKey];
			bucket.add(source[i]);
		}
		
		i = 0;
		for(Object bucketElem:buckets) {
			@SuppressWarnings("unchecked")
			List<T> bucket = (List<T>)bucketElem;
			
			bucket.sort((x, y) -> x.compareTo(y));//Sort the data in the bucket
			
			for(T elem: bucket) {
				source[i++] = elem;//Copy it back into the source array
			}
		}
	}
}
