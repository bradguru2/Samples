#include <iostream>
#include <vector>
#include <algorithm>
#include <functional>
using namespace std;

void wiggleSort(vector<int> &nums)
{
	int m = nums.size();

	//point to median index ("auto" because different based on CPU arch)
	auto mptr = nums.begin() + (m - 1) / 2; //Pointer arithmetic is happening here

	nth_element(nums.begin(), mptr, nums.end()); //out-of-the-box median partitioning

	int median = *mptr; //dereference the int at this address

	//Use a two pointer/index approach
	int i = 1;							   // position for the larger values: start with first odd index
	int j = ((m - 1) & 1) ? m - 2 : m - 1; // position for the smaller values: start with last even index

	for (int l = 0; l < m; ++l)
	{
		if (nums[l] > median)
		{ // fill the large element
			if (l <= i && (l & 1))
				continue; // skip the elements which are already checked: 1, 3, 5, ..., i
			swap(nums[l--], nums[i]);
			i += 2;
		}
		else if (nums[l] < median)
		{ // fill the smaller element
			if (l >= j && (l & 1) == 0)
				continue; // skip the elements whcih are checked: j, j + 2, ..., lastEvenIndex
			swap(nums[l--], nums[j]);
			j -= 2;
		}
	}
}

int main()
{
    std::vector<int> v{5, 6, 4, 3, 2, 6, 7, 9, 3};
 
    wiggleSort(v);

	cout << "The vector modified is" << endl;

	for(int i=0; i < v.size(); i++){
		cout << v[i] << " ";
	}

	cout << endl;
	
	return 0;
}