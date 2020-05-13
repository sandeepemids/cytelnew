using EngineWrapper.Utils;
using System.Threading;

namespace EngineWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationConstant.ReadConfiguration();
            EngineWrapper engineWrapper = new EngineWrapper();
            while (true)
            {
                engineWrapper.WrapperOperations();
                Thread.Sleep(ConfigurationConstant.IntervalTime);
            }
        }

        

    }
}
