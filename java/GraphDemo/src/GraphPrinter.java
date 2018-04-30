/**
 * This will iterating through a graph and printing its vertexes and edges.
 * @author bradley
 *
 */
public class GraphPrinter {
	
	private static void printGraphWithSum(int[][] graph, int startRow, int sum) {
		int n = graph[startRow].length;
				
		for(int i=0; i < n; i++) {
			if(graph[startRow][i] != 0) {
				System.out.printf("%c->%c:%d\n", 'A' + startRow, 'A' + i, 
						sum + graph[startRow][i]);
				printGraphWithSum(graph, i, sum + graph[startRow][i]);
			}
		}
	}
	
	private static void printGraph(int[][] graph, int startRow) {
		int n = graph[startRow].length;
		
		for(int i=0; i < n; i++) {
			if(graph[startRow][i] != 0) {
				System.out.printf("%c->%c:%d\n", 'A' + startRow, 'A' + i, 
						graph[startRow][i]);
				printGraph(graph, i);
			}
		}
	}
	
	/**
	 *                       A 
	 *                    /  /  \
	 *                 2 / 1 \ 3 \
	 *                  B     C    D ---\----\
	 *               4 /   3 / 7 / 8 \ 9 \ 10 \
	 *                E     F   G     H   I    J
	 * @param args
	 */
	public static void main(String[] args) {
		int[][] matrix = { 
 			  // A	B  C  D  E  F  G  H  I  J
				{0, 2, 1, 3, 0, 0, 0, 0, 0, 0},// A
				{0, 0, 0, 0, 4, 0, 0, 0, 0, 0},// B
				{0, 0, 0, 0, 0, 3, 0, 0, 0, 0},// C
				{0, 0, 0, 0, 0, 0, 7, 8, 9,10},// D
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},// E
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},// F
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},// G
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},// H
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},// I
				{0, 0, 0, 0, 0, 0, 0, 0, 0, 0} // J
		};
		
		System.out.println("print out graph");
		printGraph(matrix, 0);
		
		System.out.println();
		System.out.println("print out graph with running sum");
		printGraphWithSum(matrix, 0, 0);

	}
}
