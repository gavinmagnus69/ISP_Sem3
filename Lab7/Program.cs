// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information

using Lab7Lib;
Mutex mutexObj = new();
int pos = 7;
var sol = new Integral();
sol.ShowResult += (ts, ans) =>
{
    Console.SetCursorPosition(0, pos);
    Console.WriteLine($"Thread {Thread.CurrentThread.Name}: completed with result: {ans}, by {ts}");
    ++pos;
};
sol.ShowProgress += pr =>
{
    mutexObj.WaitOne();
    Console.SetCursorPosition(0, Convert.ToInt32(Thread.CurrentThread.Name) - 1);
    Console.Write($"Thread {Thread.CurrentThread.Name}:[");
    for (int i = 0; i < (pr * 20 / 100); ++i)
    {
        Console.Write("=");
    }

    Console.Write(">");
    for (int i = 0; i < 20 - (pr * 20 / 100); ++i)
    {
        Console.Write(" ");
    }

    Console.Write($"] {pr}%");
    Console.WriteLine();
    mutexObj.ReleaseMutex();

};
double l = 0.1;
double r = 0.5;
double dx = 0.00001;
var thr = new Thread(( ) => sol.Solve(l, r, dx));
thr.Name = "1";
var thr2 = new Thread(( ) => sol.Solve(l, r, dx));
thr2.Name = "2";
var thr3 = new Thread(( ) => sol.Solve(l, r, dx));
thr3.Name = "3";
var thr4 = new Thread(( ) => sol.Solve(l, r, dx));
thr4.Name = "4";
var thr5 = new Thread(( ) => sol.Solve(l, r, dx));
thr5.Name = "5";
thr.Priority = ThreadPriority.Highest;
thr2.Priority = ThreadPriority.Lowest;
thr.Start();
thr2.Start();
thr3.Start();
thr4.Start();
thr5.Start();
