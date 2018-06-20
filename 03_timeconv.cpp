// time conversion /b:
// make an utility or class!: https://www.hackerrank.com/challenges/time-conversion/problem

#include <bits/stdc++.h>

using namespace std;

string timeConversion(string s) {

	string am_pm = s.substr(8, 2);

	int hh = stoi(s.substr(0, 2));

	if (am_pm == "AM")
	{
		if (hh == 12)
			return "00" + s.substr(2, 6);
		else
			return s.substr(0, 8);
	}
	else
    {
        if (hh != 12) hh += 12;
		return std::to_string(hh) + s.substr(2, 6);
    }

}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    string s;
    getline(cin, s);

    string result = timeConversion(s);

    fout << result << "\n";

    fout.close();

    return 0;
}
