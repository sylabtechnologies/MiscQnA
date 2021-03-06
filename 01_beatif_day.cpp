// Beauday.cpp : https://www.hackerrank.com/challenges/beautiful-days-at-the-movies/problem
//

#include "stdafx.h"
#include <iostream>
#include <vector>
#include <iterator>
using namespace std;

#define _R1(x) x.begin(), x.end()
#define _R2(x) auto iter = x.begin(); iter != x.end(); ++iter

int reverse(int i)
{
	vector<int> result;

	while (i > 0)
	{
		result.push_back(i % 10);
		i = i / 10;
	}

	int res = 0;
	int mult = 1;

	for (auto iter = result.begin(); iter != result.end(); ++iter)
	{
		char c = '0' + *iter;
		cout << c;
	}
	cout << endl;

	for (auto iter = result.rbegin(); iter  != result.rend(); ++iter)
	{
		res = res + (*iter)*mult;
		mult *= 10;
	}

	return res;
}

int beautifulDays(int i, int j, int k)
{
	int res = 0;

	for (int jj = i; jj <= j; jj++)
	{
		int diff = abs(jj - reverse(jj));

		if (diff % k == 0) res++;
	}

	return res;
}
int main()
{
	cout << beautifulDays(20, 23, 6) << endl;

    return 0;
}

