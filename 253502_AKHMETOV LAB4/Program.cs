// See https://aka.ms/new-console-template for more information
using System.IO;
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




/*FileService<Passangers> fs = new FileService<Passangers>();
fs.SaveData(v, "C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/aboba.bin");


foreach (var i in fs.ReadFile("C:/romanfiles/253502_AKHMETOV_LAB1C#/253502_AKHMETOV LAB4/aboba.bin"))
{
    Console.WriteLine("amogus {0}, {1}, {2}", i.name, i.age, i.married);
}*/
