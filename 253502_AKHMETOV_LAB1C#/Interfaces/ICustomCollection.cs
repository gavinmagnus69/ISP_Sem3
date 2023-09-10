namespace Akhmetov_253502_Lab1.Interfaces;

public interface ICustomCollection<T> 
{
    T this[int index] { get; set; }

    void Reset();
    void Next();
    T Current();

    int Count();
    void Add(T item);
    void Remove(T item);
    T RemoveCurrent();

}