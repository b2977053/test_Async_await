using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_Async_await
{
    class Program
    {
        // +使用同步/非同步 製作Pizza
        static void Main(string[] args)
        {
            使用同步製作Pizza 示範一 = new 使用同步製作Pizza();
            示範一.開始(); // 993 時間

            使用非同步製作Pizza 示範二 = new 使用非同步製作Pizza();
            //示範二.開始(); // 120 時間
        }
    }
}
