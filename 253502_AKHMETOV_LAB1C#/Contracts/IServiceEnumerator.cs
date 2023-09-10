using System.Collections;

namespace Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Collections;
using Akhmetov_253502_Lab1.Entities;

public class IServiceEnumerator<T> : IEnumerator<T>
{
    private MyList<T> list;
    private T _current;

    public IServiceEnumerator(MyList<T> tmp)
    {
        list = tmp;
        _current = list.Current();

    }

    

    public T Current
    {

        get
        {
            if (list == null || _current == null)
            {
                throw new InvalidOperationException();
            }

            return _current;
        }
    }

    /*private object Current1
    {

        get { return this.Current; }
    }*/

    object IEnumerator.Current
    {
        get;
    }
    
    
    public bool MoveNext()
    {
        list.Next();
        if (_current == null)
            return false;
        return true;
    }
    public void Reset()
    {
        list.Reset();
    }
    private bool disposedValue = false;
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                // Dispose of managed resources.
            }
            _current = default;
        }

        this.disposedValue = true;
    }

    ~IServiceEnumerator()
    {
        Dispose(disposing: false);
    }
    





}