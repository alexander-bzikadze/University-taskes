#include <iostream>
#include <fstream>
#include <vector>
#include <utility>
#define forn(i, n) for(int i = 0; i < n; ++i)
using namespace std;

const int N = 1e3;
int n;

using lal = vector<vector<pair<int, int>>>;
lal gr;
lal mst;

void mst_go(int mi, int mj, int mr) 
{
    std::vector<int> marked;
    mst.resize(n);
    mst[mi].push_back({mj, mr});
    marked.resize(n);
    marked.push_back(mi);
    marked.push_back(mj);
    for (int i = 1; i < n; ++i)
    {
        int ci, cj;
        int min = 1e9;
        for (auto i : marked)
        {
            for(auto x : gr[i])
            {
                if (x.second != 0 && x.second < min)
                {
                    ci = i;
                    cj = x.first;
                    min = x.second;
                }
            }
        }
        mst[ci].push_back({cj, min});
        marked.push_back(cj);
    }
}

int get_max_mst() {
    int result = 0;
    forn(i, n)
        for(auto x : mst[i])
        {
            result = max(result, x.second);
        }
    return result;
}

int main() {
    ifstream file("avia.in");
    file >> n;
    gr.resize(n);
    int w;
    int mi, mj, mr = 1e9;
    forn(i, n)
        forn(j, n) {
            file >> w;
            if (w < mr)
            {
                mi = i;
                mj = j;
                mr = w;
            }
            gr[i].push_back({j, w});
            //gr[j].push_back({i, w});
        }
    mst_go(mi, mj, mr);
    ofstream fileO("avia.out");
    fileO << get_max_mst();
}