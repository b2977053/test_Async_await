using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace test_Async_await
{
    internal class 非同步ErrorCatch : 使用同步製作Pizza
    {
        private static int Pizza總數 = 0;
        private static object tsLock = new object();

        internal void 開始()
        {
            for (int i = 1; i <= 5; i++)
            {
                Pizza總數 = 0;
                var watch = Stopwatch.StartNew();
                Console.WriteLine("\n開始使用非同步製作披薩...");

                List<Task> Tasks = new List<Task>();
                for (int index = 0; index < i; index++)
                {
                    Tasks.Add(Task.Run(async () =>
                    {
                        await 製作一個披薩Async_has_some_error();
                    }));
                }
                try
                {
                    Task.WaitAll(Tasks.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);

                    foreach (var task in Tasks)
                    {
                        Console.WriteLine($"Status : {task.Status}");
                        switch (task.Status)
                        {
                            case TaskStatus.Created:
                                break;
                            case TaskStatus.WaitingForActivation:  // 逾期
                                break;
                            case TaskStatus.WaitingToRun:
                                break;
                            case TaskStatus.Running:
                                break;
                            case TaskStatus.WaitingForChildrenToComplete:
                                break;
                            case TaskStatus.RanToCompletion:
                                break;
                            case TaskStatus.Canceled:
                                break;
                            case TaskStatus.Faulted: // 工作因未處理的例外狀況而完成。
                                break;
                            default:
                                break;
                        }
                    }
                }

                watch.Stop();
                Console.WriteLine($"Pizza總數:{Pizza總數} => 共花費:{watch.Elapsed.TotalMilliseconds.ToString("0")} 時間。");
            }
        }

        private async Task 製作一個披薩Async_has_some_error()
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
                if (Pizza總數 == 4)
                {
                    throw new InvalidProgramException("發生了一個例外異常");
                }

            });
        }
    }
}