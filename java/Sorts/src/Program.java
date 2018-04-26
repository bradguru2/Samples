import java.util.Arrays;

public class Program {

	static void printBuffer(Character[] buffer) {
		for(Character c:buffer) {
			System.out.printf("%c ", c);
		}
		System.out.println();
	}
	
	public static void main(String[] args) {
		Character[] buffer = {'a', 'z', 'e', 'c', 'd', 'g', 'f'};
		Character[] source = Arrays.copyOf(buffer, buffer.length);
		
		//Insertion Sort
		System.out.println("Trying insertion sort on:");
		printBuffer(source);
		InsertionSort.sort(source);
		System.out.println("After sorting:");
		printBuffer(source);
		System.out.println();
		
		//Selection sort
		source = Arrays.copyOf(buffer, buffer.length);
		System.out.println("Trying selection sort on:");
		printBuffer(source);
		SelectionSort.sort(source);
		System.out.println("After sorting:");
		printBuffer(source);
		System.out.println();
		
		//Quick sort
		source = Arrays.copyOf(buffer, buffer.length);
		System.out.println("Trying quick sort on:");
		printBuffer(source);
		QuickSort.sort(source, 0, source.length - 1);
		System.out.println("After sorting:");
		printBuffer(source);
		System.out.println();
		
		//Merge Sort
		source = Arrays.copyOf(buffer, buffer.length);
		System.out.println("Trying merge sort on:");
		printBuffer(source);
		MergeSort.sort(source, 0, source.length - 1);
		System.out.println("After sorting:");
		printBuffer(source);
		System.out.println();
	}

}
