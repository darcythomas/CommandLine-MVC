using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Spike
{
    class Router
    {
       readonly List<Type> _controlers = new List<Type>();
       private Dictionary<String, String> SessionDataHold { get; set; }
        public Router()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            _controlers = types.Where(type => type.IsSubclassOf(typeof (Controler))).ToList();
        }

        public void RouteToControler(String input)
        {
            String controlerName = GetControlerName(input);

            Controler controler = GetControler(controlerName);

            controler.Process(input.Split(' '));

            SessionDataHold = controler.ResponseSessionData;
        }

        private string GetControlerName(string input)
        {
            String returnControler;
            SessionDataHold.TryGetValue("ReturnControler", out returnControler);

            String firstPartOfInput = input.Split(' ').FirstOrDefault();

            String controlerName = returnControler ?? firstPartOfInput;
            return controlerName;
        }

        private Controler GetControler(String controlerName)
        {
            //If the controller name string is null or empty, set a default  
            controlerName = String.IsNullOrWhiteSpace(controlerName) ? "Default": controlerName; 

            //Controllers by convention should end with controller
            controlerName += "Controller";

            //Find the first controller Type (or default which will be null) that equals the given controller name
            Type controlerType =_controlers.First(c => c.Name.Equals(controlerName, StringComparison.OrdinalIgnoreCase));

            //Ok we have the type, now create an instance of it . Kinda like calling `new <controlername>() `
            Controler controller = (Controler) Activator.CreateInstance(controlerType);
            controller.RequestSessionData = SessionDataHold;

            return controller;
        }
    }
}
