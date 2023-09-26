namespace _253502_AKHMETOV_LAB4;

public class MyCustomComparer<T> : IComparer<T> where T : Passangers
{
    public int Compare(T? x, T? y)
    {
        if (x.name.Length > y.name.Length)
        {
            return 1;
        }

        if (x.name.Length == y.name.Length)
        {
            return 0;
        }
        return -1;
    }
}