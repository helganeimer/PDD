using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PDDLibrary;

namespace PDD
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Create PderInfo, CarInfo subjects and attach observers
            PdrInfo pdrInfo1 = new PdrInfo(140.00, 45.8);
            CarInfo carInfo1 = new CarInfo("AB2346", "red", "BMW");
            Criminal criminal1 = new Criminal("Oleg", "Ivanov", "Dnipro,Partizanska,130", 
                "+380675643322", "oleg.ivanov@gmail.com", "234512");
            Police police1 = new Police("Viktor", "Kovalchuk", "traffic inspector",
                "ao-2341", "+380991236754");
            Bailiff bailiff1 = new Bailiff("Alina", "Petrenko", "241", 
                "ps-2121", "+380687577322");
            pdrInfo1.Attach(criminal1);
            carInfo1.Attach(criminal1);
            pdrInfo1.Attach(police1);
            carInfo1.Attach(police1);
            pdrInfo1.Attach(bailiff1);
            carInfo1.Attach(bailiff1);
            //Notifying observers about changes
            pdrInfo1.FineAmount =142.10;
            pdrInfo1.Notify();
            carInfo1.Colour = "pink";
            carInfo1.Notify();
            
            // Wait for user
            Console.ReadKey();

        }


    }

}
