using MyProject.CustomClient;

namespace USTP_ArenaInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            //Here the Custom HttpClient will be instantiated:
            //DO NOT DELETE THIS!
            //
            SimArenaCustomClient_SinglePlayer spApi = new SimArenaCustomClient_SinglePlayer();
            SimArenaCustomClient_MultiPlayer mpApi = new SimArenaCustomClient_MultiPlayer();

            //
            //May put sample GET-method here:
            //
            Console.WriteLine("WELCOME - fill in your first GET-Method out of the ReadMe.");

            //
            //Here YOUR Code begins! Have Fun.
            //
            Console.ReadLine();

        }
    }
}
