using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_Async_await
{
    class Program
    {
        // + 非同步 Error Catch
        static void Main(string[] args)
        {
            使用同步製作Pizza 示範一 = new 使用同步製作Pizza();
            //示範一.開始(); // 993 時間

            使用非同步製作Pizza 示範二 = new 使用非同步製作Pizza();
            //示範二.開始(); // 120 時間

            非同步ErrorCatch 示範三 = new 非同步ErrorCatch();
            示範三.開始();



        }
    }
}
