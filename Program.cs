using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        Example1();
        Example2();
    }

    static void Example2()
    {
        while (true)
        {
            // Start computation.
            Example();
            // Handle user input.
            string result = Console.ReadLine();
            Console.WriteLine("You typed: " + result);
        }
    }

    static void Example1(){

    
            // Start the HandleFile method.
        Task<int> task = HandleFileAsync();

        // Control returns here before HandleFileAsync returns.
        // ... Prompt the user.
        Console.WriteLine("Please wait patiently " +
            "while I do something important.");

        // Do something at the same time as the file is being read.
        string line = Console.ReadLine();
        Console.WriteLine("You entered (asynchronous logic): " + line);

        // Wait for the HandleFile task to complete.
        // ... Display its results.
        task.Wait();
        var x = task.Result;
        Console.WriteLine("Count: " + x);

        Console.WriteLine("[DONE]");
        Console.ReadLine();
    }
    
    static async Task<int> HandleFileAsync()
    {
        string filePath = @"inputdata.txt";
        if (!File.Exists(filePath)){
            Console.WriteLine($"Error: bad file path: {filePath} Current Directory Path: {Directory.GetCurrentDirectory()}");
        }
        Console.WriteLine($"filePath: {filePath}");
        Console.WriteLine("HandleFile enter");
        int count = 0;

        // Read in the specified file.
        // ... Use async StreamReader method.
        using (StreamReader reader = new StreamReader(filePath))
        {
            string v = await reader.ReadToEndAsync();

            // ... Process the file data somehow.
            count += v.Length;

            // ... A slow-running computation.
            //     Dummy code.
            for (int i = 0; i < 10000; i++)
            {
                int x = v.GetHashCode();
                if (x == 0)
                {
                    count--;
                }
            }
        }
        Console.WriteLine("HandleFile exit");
        return count;
    }

    static async void Example()
    {
        // This method runs asynchronously.
        int t = await Task.Run(() => Allocate());
        Console.WriteLine("Compute: " + t);
    }

    static int Allocate()
    {
        // Compute total count of digits in strings.
        int size = 0;
        for (int z = 0; z < 100; z++)
        {
            for (int i = 0; i < 1000000; i++)
            {
                string value = i.ToString();
                size += value.Length;
            }
        }
        return size;
    }
}