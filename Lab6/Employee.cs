﻿namespace Lab6;

public class Employee
{
    public bool married = false;
    public int age = 0;
    public string name = "";

    public Employee(bool m, int a, string name)
    {
        married = m;
        age = a;
        this.name = name;
    }

    public Employee()
    {
    }


}