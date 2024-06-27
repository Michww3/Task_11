using System.Threading;
class Program
{
    static object locker = new object();
    static string path = "TextCombine.txt";

    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(ReadnWrite1);
        ThreadPool.QueueUserWorkItem(ReadnWrite2);
        //Thread.Sleep(1000);
    }

    static void ReadnWrite1(object state)
    {
        string path1 = "TestText1.txt";
        string text1 = File.ReadAllText(path1);
        Write(path, text1);
    }
    static void ReadnWrite2(object state)
    {
        string path2 = "TestText2.txt";
        string text2 = File.ReadAllText(path2);
        Write(path, text2);
    }
    static void Write(string path, string text)
    {
        Console.WriteLine(text);
        lock (locker)
        {
            File.AppendAllText(path, text);
        }
    }

}