using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC_Spike
{
    public interface IView<T>
    {
        String Render(T model);
    }

    public interface IView
    {
        String Render();
    }
}
