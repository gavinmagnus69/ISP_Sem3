// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.IO;
using System.Net;
using _253502_AKHMETOV_LAB4;

//passangers
List<Passangers> v = new List<Passangers>();
v.Add(new Passangers("Roma", 18, false));
v.Add(new Passangers("Nikita", 18, false));
v.Add(new Passangers("Vadim", 18, false));
v.Add(new Passangers("Bogdan", 55, true));
v.Add(new Passangers("Vitaly", 31, false));



var dir = new DirectoryInfo("C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/Akhemtov_Lab4");
if (!dir.Exists)
{
    dir.Create();
}

for (int i = 0; i < 10; ++i)
{
    string p = "C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/Akhemtov_Lab4/" + Path.GetRandomFileName();
    File.Create(p);
}

var files = dir.GetFiles();
foreach (var i in files)
{
    Console.WriteLine("Файл: {0}, имеет расширение {1}", i.Name, i.Extension);
}




FileService<Passangers> fs = new FileService<Passangers>();
string path = "C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/aboba.bin";
fs.SaveData(v, path);
string new_path = "C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/" + "amogus.bin";
File.Move(path,  new_path);
List<Passangers> list = new List<Passangers>();
foreach (var i in fs.ReadFile(new_path))
{
    list.Add(i);
    Console.WriteLine("amogus {0}, {1}, {2}", i.name, i.age, i.married);
}

MyCustomComparer<Passangers> comparer = new MyCustomComparer<Passangers>();
foreach (var i in list.OrderBy(_ => _, comparer))
{
    Console.WriteLine(i.name);    
}

var new_col = list.OrderBy((x) => x.age);
foreach (var i in new_col)
{
    Console.WriteLine("name = {0}, age = {1}", i.name, i.age);
}






