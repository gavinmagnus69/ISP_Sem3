// See https://aka.ms/new-console-template for more information


using Lab8Lib;

var ss = new StreamService<Passanger>();
var stream = new FileStream("C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\Lab8Lib\\stream.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
var pas = new List<Passanger>();
for (int i = 0; i < 1000; ++i)
{
    pas.Add(new Passanger());
}

await ss.WriteToStreamAsync(stream, pas, new Progress<string>((s) =>
{
    Console.WriteLine(s);
}) );
//await Task.Delay(3000);
await ss.CopyFromStreamAsync(stream, "C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\Lab8Lib\\pas.txt", new Progress<string>(
    (s) =>
    {
        Console.WriteLine(s);
    }));
//await Task.Delay(3000);
await ss.GetStatisticsAsync("C:\\romanfiles\\253502_AKHMETOV_LAB1C#\\Lab8Lib\\pas.txt",
    (passanger) =>
    {
        return passanger.luggage == true ? true : false;
    });


