using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
   public class DefaultView: IView
    {
       public string Render()
       {

           return "Invalid input"; 
          
       }

    }
}
