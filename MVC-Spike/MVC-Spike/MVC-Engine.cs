using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
    public class MVC_Engine
    {
        
        

        public void Start(ref Boolean keepRunningToken)
        {
            Router router = new Router();
            while (keepRunningToken)
            {
                String input = Console.ReadLine();
                router.RouteToControler(input);

            }
        }
    }
}
