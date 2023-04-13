using debugging.DebugClass;
internal class Program
{
    private static int Main(string[] args)
    {
       Debug debug = new();
       int Found =  debug.FindProccessByName("discord");
        bool DidFindModule = debug.OpenProcess(Found);
       if(Found != -1)
        {

            Console.WriteLine($"Process Id is: {Found}");
            if( DidFindModule != false)
            {
                Console.WriteLine("Working and getting main module");
            } else
            {
                Console.WriteLine("Still needs Some work");
            }
        } else
        {
            Console.Error.WriteLine("Not Found");
        }

        return 0;
    }
}