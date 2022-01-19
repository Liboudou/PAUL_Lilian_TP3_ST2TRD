using System;  
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using Timer = System.Timers.Timer;

namespace Paul_Lilian_TP3_ST2TRD
{
    public class Exercise_2
    {
        private static Mutex mutex = new Mutex();
        private const int numThreads = 3;  
        private static void ThreadProcess()
        {
            var timer = DateTime.Now;
            

            while (true)    
            {  
                Mutexx();
                gotosleep();
                var timer2 = DateTime.Now;
                var a = timer2 - timer;
                stopthread(a);
            }

        }

        private static void print1()
        {
           
            
            if (Thread.CurrentThread.Name == "Thread1")
            {
                Console.Write(" ");
                
            }
            else if (Thread.CurrentThread.Name == "Thread2")
            {
                Console.Write("*");
            }
            else if (Thread.CurrentThread.Name == "Thread3")
            {
                Console.Write("°");
            }
                
        }

        private static void stopthread(TimeSpan a)
        {
            
            if (a.TotalSeconds >= 9)
            {
                if (Thread.CurrentThread.Name == "Thread3")
                {
                    Thread.CurrentThread.Abort();
                }
            }
            if (a.TotalSeconds >= 10)
            {
                if (Thread.CurrentThread.Name == "Thread1")
                {
                    Thread.CurrentThread.Abort();
                }
            }
            if (a.TotalSeconds >= 11)
            {
                if (Thread.CurrentThread.Name == "Thread2")
                {
                    Environment.Exit(0);
                }
            }
            
        }
        private static void gotosleep()
        {
            if (Thread.CurrentThread.Name == "Thread1")
            {
                Thread.Sleep(50);
                
            }
            else if (Thread.CurrentThread.Name == "Thread2")
            {
                Thread.Sleep(40);
            }
            else if (Thread.CurrentThread.Name == "Thread3")
            {
                Thread.Sleep(20);
            }
        }
        private static void Mutexx()  
        {  
            mutex.WaitOne();
            print1();
            
            mutex.ReleaseMutex();
            
            
        }  
        public void Test()  
        {  
            for (int i = 0; i < numThreads; i++)
            {
                
                Thread mycorner = new Thread(new ThreadStart(ThreadProcess));  
                mycorner.Name = String.Format("Thread{0}", i + 1);  
                mycorner.Start();
                
                
            }
            
            
            Console.Read();

            Environment.Exit(0);
        }  
    }


}