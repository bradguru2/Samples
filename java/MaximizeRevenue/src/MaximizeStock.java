/**
 * Given an array of integers representing whole dollar sells of stocks, give
 * the maximum sell by combining two of the elements.
 * 1. The left element is a buy and the right element is a sell
 * 2. Assume non-negative integers
 * @author bradley
 *
 */
public class MaximizeStock {

	public static void main(String[] args) {
		int[] stockSells = { 1, 2, 3, 4, 5, 6, 4, 3, 2, 7 };
		int left = 0, maxSell = 0, right = 1, n = stockSells.length;
		
		while(right < n) {
			int sell = stockSells[right] - stockSells[left];
			
			if(sell > maxSell) {
				maxSell = sell;
			}
			
			if(stockSells[right] < stockSells[left]) {
				left = right;
			}
			
			++right;
		}
		
		System.out.printf("The most that was sold was %d\n", maxSell);
	}

}
