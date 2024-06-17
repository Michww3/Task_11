class Program
{
    static void Main(string[] args)
    {
        object locker = new();
        string path1 = "TestText1.txt";
        string path2 = "TestText2.txt";
        Thread thread1 = new Thread(ReadnWrite1);
        Thread thread2 = new Thread(ReadnWrite2);
        thread1.Start();
        thread2.Start();

        void ReadnWrite1()
        {
            string text1 = File.ReadAllText(path1);
            Write(text1, path1);
        }
        void ReadnWrite2()
        {
            string text2 = File.ReadAllText(path2);
            Write(text2, path2);
        }
        void Write(string text, string path)
        {
            lock (locker)
            {
                File.AppendAllText("TextCombine.txt", text);
            }
        }
    }
}