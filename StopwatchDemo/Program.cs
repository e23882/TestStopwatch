using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StopwatchDemo
{
    class Program
    {
        #region Declarations
        Stopwatch st1 = new Stopwatch();
        Stopwatch st2 = new Stopwatch();
        bool st1IsAction = false;
        bool st2IsAction = true;
        long costTime = 0;
        #endregion

        #region Memberfunction
        static void Main(string[] args)
        {
            bool isFirstTime = true;
            bool recordIsAction = false;
            Program pg = new Program();
            //模擬事件發生 0:按下錄動作,5~10:觸發keycode
            while (true)
            {
                Random rd = new Random();
                var rdNum = rd.Next(0, 10);
                if (rdNum == 0)//亂數=0開始計算 第二次遇到結束計算(模擬按按鈕動作)
                {
                    //按下按鈕
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("record btn click");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (!recordIsAction)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Recording...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Stop Recording...");
                        Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    recordIsAction = !recordIsAction;
                }
                else if (rdNum > 5 && recordIsAction)
                {
                    //第一次觸發事件不取時間(沒有第零次到第一次經過的時間)
                    if (isFirstTime)
                    {
                        Console.WriteLine("the first time event hit");
                        pg.calTime();
                        isFirstTime = false;
                    }
                    else
                    {
                        Console.WriteLine("event hit");
                        Console.WriteLine(pg.calTime());
                    }
                }
                Thread.Sleep(300);
            }
        }
        public long calTime()
        {
            if (st1IsAction)
            {
                st1.Stop();
                costTime = st1.ElapsedMilliseconds;
                st1.Reset();
                st2.Start();
                st2IsAction = true;
                st1IsAction = false;
                return costTime;
            }
            if (st2IsAction)
            {
                st2.Stop();
                costTime = st2.ElapsedMilliseconds;
                st2.Reset();
                st1.Start();
                st2IsAction = false;
                st1IsAction = true;
                return costTime;
            }
            return 0;
        }
        #endregion
    }
}
