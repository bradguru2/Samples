#include <bits/stdc++.h>
using namespace std;
 
// Returns number of bins required using next fit 
// online algorithm
int nextFit(int weight[], int n, int c)
{
   // Initialize result (Count of bins) and remaining
   // capacity in current bin.
   int res = n > 0 ? 1 : 0, bin_rem = c;
 
   // Place items one by one
   for (int i=0; i<n; i++)
   {
       // If this item can't fit in current bin
       if (weight[i] > bin_rem)
       {
          res++;  // Use a new bin
          bin_rem = c - weight[i];
       }
       else
         bin_rem -= weight[i];
   }

   return res;
}

// Returns number of bins required using first fit 
// online algorithm
int firstFit(int weight[], int n, int c)
{
    // Initialize result (Count of bins)
    int res = 0;
 
    // Create an array to store remaining space in bins
    // there can be at most n bins
    int bin_rem[n];
 
    // Place items one by one
    for (int i=0; i<n; i++)
    {
        // Find the first bin that can accommodate
        // weight[i]
        int j;
        for (j=0; j<res; j++)
        {
            if (bin_rem[j] >= weight[i])
            {
                bin_rem[j] = bin_rem[j] - weight[i];
                break;//means don't increment j and exit loop
            }
        }
 
        // If no bin could accommodate weight[i]
        if (j==res)
        {
            bin_rem[res] = c - weight[i];
            res++;
        }
    }
    return res;
}

// Returns number of bins required using best fit
// online algorithm
int bestFit(int weight[], int n, int c)
{
    // Initialize result (Count of bins)
    int res = 0;
 
    // Create an array to store remaining space in bins
    // there can be at most n bins
    int bin_rem[n];
 
    // Place items one by one
    for (int i=0; i<n; i++)
    {
        // Find the best bin that can accomodate
        // weight[i]
        int j;
 
        // Initialize minimum space left and index
        // of best bin
        int min = c+1, bi = 0;
 
        for (j=0; j<res; j++)
        {
            if (bin_rem[j] >= weight[i] &&
                    bin_rem[j] - weight[i] < min)
            {
                bi = j;
                min = bin_rem[j] - weight[i];
            }
        }
 
        // If no bin could accommodate weight[i],
        // create a new bin
        if (min==c+1)
        {
            bin_rem[res] = c - weight[i];
            res++;
        }
        else // Assign the item to best bin
            bin_rem[bi] -= weight[i];
    }
    
	return res;
}

// Returns number of bins required using first fit 
// decreasing offline algorithm
int firstFitDec(int weight[], int n, int c)
{
    // First sort all weights in decreasing order
	// int* + int is pointer arithmetic (not integer)
    sort(weight, weight + n, std::greater<int>());
 
    // Now call first fit for sorted items
    return firstFit(weight, n, c);
}

int main()
{
    int weight[] = {2, 5, 4, 7, 1, 3, 8};
    int c = 10;
    int n = sizeof(weight) / sizeof(weight[0]);
    
	cout << "Number of bins required in Next Fit : "
         << nextFit(weight, n, c) << endl << endl;

	cout << "Number of bins required in First Fit : "
         << firstFit(weight, n, c) << endl << endl;

	cout << "Number of bins required in Best Fit : "
         << bestFit(weight, n, c) << endl << endl;

	cout << "Number of bins required in First Fit Decreasing : " 
		 << firstFitDec(weight, n, c) << endl << endl;

    return 0;
}