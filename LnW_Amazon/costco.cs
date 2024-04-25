using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon
{
    internal class costco
    {
        public void findoccurence()
        {
            string str = "aman";
            //output = a2m1n1

            int count = 1;
            Dictionary<char,int> dic = new Dictionary<char,int>();

            for(int i = 0;i<str.Length;i++)
            {
                if (dic.ContainsKey(str[i]))
                {
                    count++;
                    dic[str[i]] = count;
                }
                else
                {
                    dic.Add(str[i], count);
                }
            }

            foreach(KeyValuePair<char,int> kvp in dic)
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
