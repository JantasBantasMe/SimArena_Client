namespace USTP_ArenaInterfaceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            //Here the Custom HttpClient will be instantiated:
            //
            SimArenaCustomClient API = new SimArenaCustomClient();

            //
            //Sample GET-Method:
            //
            string isApiAlive = API.GetAlive();
            Console.WriteLine(isApiAlive);

            //
            //Here YOUR Code begin! Have Fun.
            //

        }
    }
}
