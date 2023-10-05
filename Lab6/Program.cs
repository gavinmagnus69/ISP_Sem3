// See https://aka.ms/new-console-template for more information

using System.Dynamic;
using System.Diagnostics;
using System.Runtime.Loader;
using System.Reflection;
using Lab6;

List<Employee> workers = new List<Employee>();
workers.Add(new Employee(true, 18, "Bogdan"));
workers.Add(new Employee(false, 18, "Nikita"));
workers.Add(new Employee(false, 18, "Vadim"));
workers.Add(new Employee(false, 18, "Roma"));
workers.Add(new Employee(false, 18, "Ilya"));
Assembly asm = Assembly.LoadFrom("C:/romanfiles/253502_AKHMETOV_LAB1C#/Lab6Lib/bin/Debug/net7.0/Lab6Lib.dll");
Type FileService = asm.GetType("Lab6Lib.FileService`1").MakeGenericType(typeof(Employee));
MethodInfo? SaveDataToFile = FileService.GetMethod("SaveData");
MethodInfo? LoadDataFromFile = FileService.GetMethod("ReadFile");

SaveDataToFile?.Invoke(Activator.CreateInstance(FileService), new object[] { workers, "C:/romanfiles/253502_AKHMETOV_LAB1C#/Lab6/Employee.json" });
var listOfEmployeeFromFile = LoadDataFromFile.Invoke(Activator.CreateInstance(FileService), new object[] {"C:/romanfiles/253502_AKHMETOV_LAB1C#/Lab6/Employee.json" });

foreach (var item in (IEnumerable<Employee>)listOfEmployeeFromFile)
{
    Console.WriteLine($"name = {item.name}, age = {item.age}, status = {item.married}");
}
