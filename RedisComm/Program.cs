using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisComm
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHelper.library = 1;
            RedisHelper.GetHashList("2");
        }
    }
}
