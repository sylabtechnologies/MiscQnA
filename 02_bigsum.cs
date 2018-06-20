// big_sum.cpp : https://www.hackerrank.com/challenges/a-very-big-sum/problem
// - do quick mod of #1

#include <bits/stdc++.h>

using namespace std;
typedef vector<int> Myvec;

#define _R1(x) x.begin(), x.end()
#define _R2(x) auto iter = x.begin(); iter != x.end(); ++iter
#define _R2R(x) auto iter = x.rbegin(); iter != x.rend(); ++iter
#define MAX(a,b) (a > b ? a : b)
#define MIN(a,b) (b > a ? a : b)

vector<string> split_string(string);

void vectorize(long i, Myvec& result)
{
	result.clear();

	while (i > 0)
	{
		result.push_back(i % 10);
		i = i / 10;
	}

}

string vec2str(Myvec& vec)
{
	string result;

	for (_R2R(vec))
		result.push_back('0' + *iter);

	return result;

}

void carry_vec(Myvec& addto, int index)
{
	if (index > addto.size()) exit(1);	// internal error

	if (index == addto.size())
	{
		addto.push_back(1);
		return;
	}

	if (addto[index] == 9)
	{
		addto[index] = 0;
		carry_vec( addto, index + 1);
		return;
	}

	addto[index] += 1;
}

void add_vec(Myvec& addto, Myvec& addthis)
{
	// work w/ longest vector
	if (addto.size() < addthis.size())
		addto.swap(addthis);

	for (size_t i = 0; i < addto.size(); i++)
	{
		int newres = addto[i];

		if (i >= addthis.size())
			break;
		else
			newres += addthis[i];

		if (newres >= 10)
		{
			carry_vec(addto, i + 1);
			newres -= 10;
		}

		addto[i] = newres;
	}

}

string bigsum(vector<long> arr)
{
	Myvec result;

	if (arr.size() == 0) return std::string();

	vectorize(arr[0], result);

	for (size_t i = 1; i < arr.size(); i++)
	{	
		vector<int> add_it;
		vectorize(arr[i], add_it);
		add_vec(result, add_it);
	}

	return vec2str(result);
}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    int ar_count;
    cin >> ar_count;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    string ar_temp_temp;
    getline(cin, ar_temp_temp);

    vector<string> ar_temp = split_string(ar_temp_temp);

    vector<long> ar(ar_count);

    for (int i = 0; i < ar_count; i++) {
        long ar_item = stol(ar_temp[i]);

        ar[i] = ar_item;
    }

    fout << bigsum(ar) << "\n";

    fout.close();

    return 0;
}

vector<string> split_string(string input_string) {
    string::iterator new_end = unique(input_string.begin(), input_string.end(), [] (const char &x, const char &y) {
        return x == y and x == ' ';
    });

    input_string.erase(new_end, input_string.end());

    while (input_string[input_string.length() - 1] == ' ') {
        input_string.pop_back();
    }

    vector<string> splits;
    char delimiter = ' ';

    size_t i = 0;
    size_t pos = input_string.find(delimiter);

    while (pos != string::npos) {
        splits.push_back(input_string.substr(i, pos - i));

        i = pos + 1;
        pos = input_string.find(delimiter, i);
    }

    splits.push_back(input_string.substr(i, min(pos, input_string.length()) - i + 1));

    return splits;
}
