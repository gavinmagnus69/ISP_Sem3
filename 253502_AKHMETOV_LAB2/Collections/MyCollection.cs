using System.Collections;
using System.Diagnostics.Metrics;

namespace Akhmetov_253502_Lab1.Collections;

using Akhmetov_253502_Lab1.Interfaces;
using Akhmetov_253502_Lab1.Contracts;

public class Node<T>
{
    public T obj;
    public Node<T> next = null;
    public Node<T> prev = null;
    public Node(T tmp)
    {
        obj = tmp;
    }

    public Node(Node<T> t)
    {
        obj = t.obj;
    }

    public Node()
    {
    }

}


public class MyList<T> : /*ICustomCollection<T>*/ IEnumerable<T>
{
    private Node<T> head = null;
    private Node<T> tail = null;
    private int counter = 0;
    private Node<T> cursor = null;

    public Node<T> return_head()
    {
        return head;
    }

    public void Add(T obj)
    {
        Node<T> to_add = new Node<T>(obj);
        if (head == tail && head != null)
        {
            tail.next = to_add;
            to_add.prev = tail;
            tail = to_add;
            head.next = tail;
            //ail.next = null;
            ++counter;
            //cursor = head;
            return;
        }

        if (head == null)
        {
            head = to_add;
            tail = head;
            head.next = null;
            tail.next = null;
            ++counter;
            cursor = head;
            return;
        }

        tail.next = to_add;
        to_add.prev = tail;
        tail = to_add;
        //tail.next = null;
        ++counter;
        //cursor = head;
        return;
    }

    public void show()
    {
        Node<T> ptr = new Node<T>();
        ptr = head;
        while (ptr != null)
        {
            Console.WriteLine(ptr.obj);
            ptr = ptr.next;
        }
    }

    public void Reset()
    {
        if (head != null)
        {
            cursor = head;

        }
        else
        {
            cursor = null;

        }
        
    }

    public void MoveNext()
    {
        /*if (cursor.next != null)
        {
            cursor = cursor.next;
            return;
        }
        else
        {
            cursor = null;
            throw new Exception("we are here");
        }*/
        if (cursor.Equals(null))
        {
            Reset();
        }

        cursor = cursor.next;
    }

    public T Current()
    {

        if (cursor != null)
        {
            return cursor.obj;
        }
        else
        {
            throw new Exception("Cursor is equal to null");
        }
    }

    public ref Node<T> return_cursor()
    {
        return ref cursor;
    }

    public int Count() => counter;

    private Node<T> indexing(int index)
    {
        if (index > counter || index < 0)
        {
           
            throw new IndexOutOfRangeException();
        }

        int cnt = 0;
        Node<T> ptr = head;
        while (cnt != index)
        {
            ptr = ptr.next;
            ++cnt;
        }


        return ptr;


    }


    public T this[int index]
    {
        get
        {
            return indexing(index).obj;

        }
        set
        {
            Node<T> ptr = indexing(index);
            ptr.obj = value;
        }
    }

    public T RemoveCurrent()
    {
        if (counter == 0)
        {
            throw new Exception("no elements to delete");
        }
        Node<T> ptr = cursor;
        Node<T> prev = cursor.prev;
        prev.next = ptr.next;
        ptr.next.prev = prev;
        cursor = prev;
        --counter;
        return ptr.obj;
    }

    public void Remove(T tmp)
    {

        if (tmp == null)
        {
            throw new Exception("null object exception");
        }

        bool flag = false;

        if (counter != 0)
        {

            for (int i = 0; i < counter; ++i)
            {
                //Console.WriteLine("case def");

                Node<T> ptr = indexing(i);

                if (ptr.obj.Equals(tmp))
                {
                    //Console.WriteLine(ptr.obj);
                    if (ptr.Equals(head))
                    {
                       // Console.WriteLine("case1");
                        head = null;
                        head = ptr.next;
                        //Console.WriteLine("e1");
                        //head.prev = null;
                        //Console.WriteLine("e2");
                        --counter;
                        flag = true;
                        break;
                    }

                    if (ptr.Equals(tail))
                    {
                        //Console.WriteLine("case2");
                        tail = ptr.prev;
                        tail.next = null;
                        --counter;
                        flag = true;
                        break;
                    }
                    //Console.WriteLine("case3");
                    //Console.WriteLine("case mid");
                    Node<T> pr = ptr.prev;
                    Node<T> nt = ptr.next;
                    pr.next = nt;
                    nt.prev = pr;
                    ptr.next = null;
                    ptr.prev = null;
                    --counter;
                    flag = true;
                    break;
                }

            }

            if (flag == false)
            {
                throw new Exception("no element was found");
            }




        }
        else
        {
            throw new Exception("no elements to delete");
        }




    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new IServiceEnumerator<T>(return_head());
    }

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
    

}