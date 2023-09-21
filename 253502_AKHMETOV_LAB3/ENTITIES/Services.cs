namespace Akhmetov_253502_Lab1.Entities;
using Akhmetov_253502_Lab1.Contracts;
using System.Numerics;

public class Services : IAdditionOperators<Services, Services, int>
{
    public int obj = 0;
    public string name = "";
    public Services() { }
    public Services(string t, int tmp) { 
        name = t;
        obj = tmp;
    }
    public Services(Services tmp) {
        name = tmp.name;
        obj = tmp.obj;
    }
    public static int operator + (Services left, Services right) {
        if (left == null || right == null) {
            throw new ArgumentException();
        }
        return left.obj + right.obj;
    }
   





}