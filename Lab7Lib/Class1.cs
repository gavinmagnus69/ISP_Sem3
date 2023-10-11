using System.Diagnostics;

namespace Lab7Lib;

public class Integral
{
    public delegate void Result(TimeSpan ts, double ans);
    public event Result ShowResult;

    public delegate void Progress(int progress);

    public event Progress ShowProgress; 
    private Semaphore semaphore = new(2, 2);

    public void Solve(double  lB = 0, double rB = 1, double d = 0.00000001)
    {
        
        Stopwatch sp = new();
        semaphore.WaitOne();
        sp.Start();
        double lBorder = (double)lB;
        double rBorder = (double)rB;
        double dx = (double)d;
        
        if (lBorder < 0 || lBorder > 1 || rBorder < 0 || rBorder > 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (lBorder > rBorder)
        {
            (lBorder, rBorder) = (rBorder, lBorder);
        }

        double sum = 0;
        for (double i = lBorder; i <= rBorder; i += dx)
        {
            sum += dx * Math.Sin(i);
            for (int j = 0; j < 100; ++j)
            {
                int b = 13 + j;
            }
            ShowProgress?.Invoke((int)( (i - lBorder) / (rBorder - lBorder) * 100));
        }
        sp.Stop();
        ShowResult?.Invoke(sp.Elapsed, sum);
        semaphore.Release();
        //Console.WriteLine($"ended, answer : {sum}, time = {sp.Elapsed}");
    }
}