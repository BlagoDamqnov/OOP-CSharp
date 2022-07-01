using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
       public string RandomString(List<string> s)
        {
            Random random = new Random();

            var num = random.Next(0,s.Count);

            s.Remove(s[num]);
            return s[num];
        }
    }
}
