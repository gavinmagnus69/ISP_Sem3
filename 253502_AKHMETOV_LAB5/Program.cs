﻿// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using System.Net;
using Akhmetov2.Domain;
using SerializerLib;

var hospitals = new List<Hospital>();
var ser = new Serializer<Hospital>();
var hosp = new Hospital("Central");
hosp.add_department(new EmergencyDep("base1"));
hospitals.Add(hosp);
var hosp2 = new Hospital("Central2");
hosp2.add_department(new EmergencyDep("base2"));
hospitals.Add(hosp2);
ser.SerializeXML(hospitals, "C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\SerializerLib\\bruh.xml");
ser.SerializeByLINQ(hospitals, "C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\SerializerLib\\bruh2.xml");
var col = ser.DeSerializeByLINQ("C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\SerializerLib\\bruh2.xml");
foreach (var i in col)
{
    Console.WriteLine("hospital name = {0}", i.hospital_name);
    foreach (var VARIABLE in i.departments)
    {
        Console.WriteLine("department name = {0}", VARIABLE.name);
    }
}