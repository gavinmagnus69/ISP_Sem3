// See https://aka.ms/new-console-template for more information
using System.IO;

//passangers
Console.WriteLine("Hello, World!");
Console.WriteLine(DriveInfo.GetDrives());
foreach (var i in Directory.GetDirectories("C:\\Games"))
{
    Console.WriteLine(i);
}