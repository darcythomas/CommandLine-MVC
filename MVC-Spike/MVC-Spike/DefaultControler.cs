using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
    class DefaultControler: Controler
    {
        public override void Process(IEnumerable<string> input)
        {
            

            String model = String.Join(" ", input);
            View(typeof(DefaultView), model);
        }

    }
}
