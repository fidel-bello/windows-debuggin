using debugging.mem;
internal class Program
{
    private static void Main(string[] args)
    {
       Debug debug = new();
       int Found =  debug.FindProccessByName("discord");
       if(Found != -1)
        {
            Console.WriteLine($"Process Id is: {Found}");
        } else
        {
            Console.Error.WriteLine("Not Found");
        }
    }
}