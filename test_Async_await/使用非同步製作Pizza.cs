using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace test_Async_await
{
    internal class 使用非同步製作Pizza : 使用同步製作Pizza
    {
        private static int Pizza總數 = 0;
        private static object tsLock = new object();

        internal void 開始()
        {
            for (int i = 1; i <= 10; i++)
            {
                Pizza總數 = 0;
                var watch = Stopwatch.StartNew();
                Console.WriteLine("\n開始使用非同步製作披薩...");

                List<Task> Tasks = new List<Task>();
                for (int index = 0; index < i; index++)
                {
                    Tasks.Add(Task.Run(async () =>
                    {
                        await 製作一個披薩Async();
                    }));
                }
                Task.WaitAll(Tasks.ToArray());

                watch.Stop();
                Console.WriteLine($"Pizza總數:{Pizza總數} => 共花費:{watch.Elapsed.TotalMilliseconds.ToString("0")} 時間。");
            }
        }

        public async Task 製作一個披薩Async()
        {
            await Task.Run(() =>
            {
                揉麵團();
                發酵();
                桿面皮();
                放上佐料();
                烤披薩();

                lock (tsLock)
                {
                    Pizza總數++;
                }
            });
        }

    }
}