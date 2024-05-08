using System;
using System.Collections.Generic;
using System.Linq;

HashSet<(long n, long m, long a)> set = [(0, 0, 0)];
HashSet<(long n, long m, long a)> phiSet = [];

while (true)
{
    foreach (var el in set)
    {
        long n = pow3(el.n);
        long m = 2 * pow2(el.m);
        if (el.a % 2 == 0)
        {
            if (n > m)
                phiSet.Add((el.n, el.m + 1, collatz(el.a)));
            
            if (3 * n > m)
                phiSet.Add((el.n + 1, el.m + 1, collatz(el.a + pow3(el.n))));
        }
        else
        {
            if (3 * n > m)
                phiSet.Add((el.n + 1, el.m + 1, collatz(el.a)));
            
            if (n > m)
                phiSet.Add((el.n, el.m + 1, collatz(el.a + pow3(el.n))));
        }
    }
    set = phiSet;
    phiSet = [];

    Console.WriteLine(set.Count);
}

long pow2(long n)
{
    long result = 1;
    while (n > 5) {
        n -= 5;
        result *= 32;
    }
    while (n > 0) {
        n--;
        result *= 2;
    }
    return result;
}

long pow3(long n)
{
    long result = 1;
    while (n > 5) {
        n -= 5;
        result *= 243;
    }
    while (n > 0) {
        n--;
        result *= 3;
    }
    return result;
}

long collatz(long n)
    => n % 2 == 0 ? n / 2 : (3 * n + 1) / 2;