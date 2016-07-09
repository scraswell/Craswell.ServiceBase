namespace Craswell.Service
{
    /// <summary>
    /// The program class.
    /// </summary>
    internal class Program
        : ServiceWrapper<Host<Service>, Service>
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void Main(string[] args)
        {
            StartService(args);
        }
    }
}

