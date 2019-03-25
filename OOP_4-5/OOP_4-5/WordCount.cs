using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4_5
{
    static class WordCount
    {
        public static int countWords(string str)
        {
            int count = 0;

            char[] symbols = { ' ', ',', '.', '!', ':', '?', '-' };

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (str[i] == symbols[j])
                    {
                        for (int k = 0; k < symbols.Length; k++)
                        {
                            if (str[i - 1] == symbols[k])
                                count--;
                        }
                        count++;
                        break;
                    }
                }
            }

            return count;
        }
    }
}
