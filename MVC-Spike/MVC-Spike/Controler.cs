using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
    public abstract class Controler
    {
        public Dictionary<String, String> ResponseSessionData { get; set; }
        public Dictionary<String, String> RequestSessionData { get; set; }

        protected void ReturnToThisControler(String controlerName)
        {
            ResponseSessionData.Add("ReturnControler", controlerName);
        }

        public abstract void Process(IEnumerable<String> splitInput);

        public void View(Type viewType, object model)
        {
            Boolean isGenericIView = viewType.GetInterface(typeof(IView<>).Name) != null;
            IView view = viewType as IView;
            string renderedView;

            if (!isGenericIView && view == null) throw new InvalidDataException("The the view given is not a valid view, it does not implement IView.");

            object concreteView = Activator.CreateInstance(viewType);


            if (!isGenericIView)
            {
                renderedView = ((IView)concreteView).Render();
            }
            else
            {
                MethodInfo magicMethod = viewType.GetMethod("Render");
                renderedView = (String)magicMethod.Invoke(concreteView, new[] { model });
            }

            Console.WriteLine(renderedView);
        }
    }
}
