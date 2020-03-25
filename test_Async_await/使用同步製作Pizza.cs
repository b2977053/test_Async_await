using System;
using System.Diagnostics;
using System.Threading;

namespace test_Async_await
{
    internal class 使用同步製作Pizza
    {
        private static int Pizza總數 = 0;
        internal void 開始()
        {
            for (int i = 1; i <= 5; i++)
            {
                Pizza總數 = 0;
                var watch = Stopwatch.StartNew();
                Console.WriteLine("\n開始使用同步製作披薩...");

                for (int index = 0; index < i; index++)
                {
                    製作一個披薩();
                }

                watch.Stop();
                Console.WriteLine($"Pizza總數:{Pizza總數} => 共花費:{watch.Elapsed.TotalMilliseconds.ToString("0")} 時間。");
            }

        }
        public static void 製作一個披薩()
        {
            揉麵團();
            發酵();
            桿面皮();
            放上佐料();
            烤披薩();

            Pizza總數++;
        }
        public static void 揉麵團()
        {
            string status = "揉麵團中...";
            Thread.Sleep(30);
            status = "揉麵團 完成";
        }
        public static void 發酵()
        {
            string status = "發酵中...";
            Thread.Sleep(40);
            status = "發酵 完成";
        }
        public static void 桿面皮()
        {
            string status = "桿面皮中...";
            Thread.Sleep(2);
            status = "桿面皮 完成";
        }
        public static void 放上佐料()
        {
            string status = "放上佐料中...";
            Thread.Sleep(2);
            status = "放上佐料 完成";
        }
        public static void 烤披薩()
        {
            string status = "烤披薩中...";
            Thread.Sleep(20);
            status = "烤披薩 完成";
        }
    }
}