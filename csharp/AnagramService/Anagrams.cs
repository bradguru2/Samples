using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AnagramService
{
    /// <summary>
    /// Anagram helper class
    /// </summary>
    public static class Anagrams
    {
        private static readonly string[] anagrams;
        private static readonly int[] primeMap;

        static Anagrams()
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream("AnagramService.words.txt");
            
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                anagrams = reader.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries);
            }

            primeMap = GeneratePrimes();
        }

        //Primes are generated using a variation of Eratosthenes Sieve
        private static int[] GeneratePrimes(){
            const int n = 5000;
            const int m = 255;
            int i, j;
            int[] sieve = new int[n];
            int[] primes = new int[m];

            sieve[2] = primes[0] = 2;
            
            for(i = 3;i < n; i+=2){
                sieve[i] = i;
            }

            i = 3;
            for(int i2 = i * i; i2 < n ; i += 2, i2 = i * i){
                if(sieve[i] != 0){
                    for(j = i2; j < n; j += i << 2){
                        sieve[j] = 0;
                    }
                }
            }

            j = 1; i = 3;
            //Give me first 255 primes from sieve
            while(j < 255){
                if(sieve[i] != 0){
                    primes[j++] = sieve[i];
                }
                i += 2;
            }

            return primes;
        }

        private static long AnagramHash(string str)
        {
            long hash = 1;

            foreach(char c in str){
                hash *= primeMap[(c - ' ')];//multiplication is commutative
            }

            return hash;
        }

        /// <summary>
        /// Forces the static constructor to be called, if it hasn't been 
        /// called, yet.
        /// </summary>
        public static  void Init()
        {
            int n = anagrams.Length;

            //Let's make sure our anagrams are clean
            for(int i = 0; i < n; i++){
                anagrams[i] = anagrams[i].Trim().ToLower();
            }

            Console.WriteLine("The number of words is {0} with last word of {1}", 
                n, anagrams[n - 1]);
        }

        /// <summary>
        /// C# extension method for string that gets anagrams per instance
        /// </summary>
        /// <param name="str">The input string for matching anagrams</param>
        /// <returns>A list of matched anagrams for the given string</returns>
        public static IList<string> GetAnagrams(this string str)
        {
            IList<string> matches = new List<string>();
            bool isExist = false;
            int n = str.Length;

            str = str.ToLower();
            
            if(n > 1 && n < 30) {//longest word: floccinaucinihilipilification
                long match = AnagramHash(str);

                foreach(string against in anagrams){
                    if(against.Length == str.Length){
                        if(str != against){
                            if(match == AnagramHash(against)){
                                matches.Add(against);
                            }
                        }
                        else{
                            isExist = true;
                        }
                    }
                }
            }

            if(!isExist){
                matches.Clear();//Word being searched must also exist
            }

            return matches;
        }
    }
}