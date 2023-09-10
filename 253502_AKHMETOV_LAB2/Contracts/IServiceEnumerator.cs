using System.Collections;

namespace Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Collections;
using Akhmetov_253502_Lab1.Entities;

public class IServiceEnumerator<T> : IEnumerator<T>
{
    private Node<T> _head = null;
    private Node<T> _current = null;

    public IServiceEnumerator(Node<T> tmp)
    {
        //Console.WriteLine("constr");
        _head = tmp;
        //_current = list.return_cursor();
        //Node<T> head = list.return_head();
        //Console.WriteLine(head.obj);
        _current = new Node<T>();
        _current.next = _head;

    }

    

    public T Current
    {

        get
        {
            //Console.WriteLine("get");
            if (_head == null || _current == null)
            {
                throw new Exception("null node or list");
            }

            return _current.obj;
        }
    }

    private object Current1
    {

        get
        {
            //Console.WriteLine("get2");
            return this.Current;
        }
    }

    object IEnumerator.Current
    {

        get;

    }
    
    
    public bool MoveNext()
    {
        //Console.WriteLine("move");

        _current = _current.next;
        
        //_current = list.return_cursor();
        //Console.WriteLine(_current.obj);
        /*try
        {
            _current = list.Current();

        }
        catch (Exception e)
        {
            return false;
        }*/
        
        if(_current == null)
        {
            //Console.WriteLine("case null");
            return false;
        }
        
        return true;
    }
    public void Reset()
    {
        //Console.WriteLine("reset");
        //list.Reset();
        _current = _head;
    }
    private bool disposedValue = false;
    public void Dispose()
    {
        //Console.WriteLine("dispose");
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
            _current = null;
        }

        this.disposedValue = true;
    }

    ~IServiceEnumerator()
    {
        Dispose(disposing: false);
    }
    





}