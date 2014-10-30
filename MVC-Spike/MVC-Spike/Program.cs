using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
    class Program
    {
        public static bool keepRunningToken = true;
        static void Main(string[] args)
        {

           MVC_Engine engine = new MVC_Engine();
            engine.Start(ref keepRunningToken);
            
        }
    }
}
