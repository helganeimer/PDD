using System;
using System.Collections.Generic;
using System.Threading;

namespace PDDLibrary
{
    /// <summary>
    /// The 'Subject' interface
    /// </summary>
    public interface ISubject
    {

        // Attach an observer to the subject.
        void Attach(IObserver observer);

        // Detach an observer from the subject.
        void Detach(IObserver observer);

        // Notify all observers about an event.
        void Notify();
    }
    /// <summary>
    /// The 'CarInfo' class about car information
    /// </summary>
    public class CarInfo : ISubject
    {
        private string car_num;
        private string colour;
        private string brand;
        // List of subscribers
        private List<IObserver> observers = new List<IObserver>();
        // Attach an observer to the subject.
        public void Attach(IObserver observer)
        {
            
            this.observers.Add(observer);
            Console.WriteLine("Subject: Attached an observer "+observer.FirstName+" "+observer.LastName+
                " to information about car");
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer "+observer.FirstName+" "+observer.LastName + 
                " to information about car");
        }

        // Notify all observers about an event.
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers about new information about car...");
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
            
        }

        public string CarNum
        {
            get { return car_num; }
            set { car_num = value; }

        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }

        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }

        }
        // Constructor
        public CarInfo(string car_num, string colour, string brand)
        {
            Init(car_num, colour, brand);
        }
        private void Init(string car_num, string colour, string brand)
        {
            CarNum = car_num;
            Colour = colour;
            Brand = brand;
        }

    }
    /// <summary>
    /// The 'PdrInfo' class about traffic violation information
    /// </summary>
    public class PdrInfo : ISubject
    {
        private double fine_amount;
        private double traffic_rule;
        // List of subscribers
        private List<IObserver> observers = new List<IObserver>();
        // Attach an observer to the subject.
        public void Attach(IObserver observer)
        {
            
            this.observers.Add(observer);
            Console.WriteLine("Subject: Attached an observer " + observer.FirstName + 
                " " + observer.LastName + " to information about traffic violation");
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer " + observer.FirstName + 
                " " + observer.LastName + " to information about traffic violation");
        }

        // Notify all observers about an event.
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers about new information abou traffic violation...");
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
            
        }


        public double FineAmount
        {
            get { return fine_amount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value must be more than 0");
                else fine_amount = value;
                
            }
        }
        public double TrafficRule
        {
            get { return traffic_rule; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value must be more than 0");
                else traffic_rule = value;
            }
        }
        // Constructor
        public PdrInfo(double fine_amount, double traffic_rule)
        {
            Init(fine_amount, traffic_rule);
        }
        private void Init(double fine_amount, double traffic_rule)
        {

            FineAmount = fine_amount;
            TrafficRule = traffic_rule;
        }



    }
    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    public abstract class IObserver
    {
        private string first_name;
        private string last_name;
        private string phone;
        private PdrInfo pdrInfo;
        private CarInfo carInfo;
        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }

        }
        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }

        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }

        }
        // Receive update from subject
        public void Update(PdrInfo pdrInfo)
        {

            Console.WriteLine("Notified " + this.FirstName + " " + this.LastName + 
                " of change information in about traffic violation number "+pdrInfo.TrafficRule);

        }
        public void Update(CarInfo carInfo)
        {

            Console.WriteLine("Notified " + this.FirstName + " " + this.LastName + 
                " of change information about car number "+carInfo.CarNum);

        }
        public PdrInfo PdrInfo
        {
            get { return pdrInfo; }
            set { pdrInfo = value; }
        }
        public CarInfo CarInfo
        {
            get { return carInfo; }
            set { carInfo = value; }
        }
    }
    /// <summary>
    /// The 'Criminal' class
    /// </summary>
    public class Criminal : IObserver
    {
        
        private string address;
       
        private string email;
        private string passport_id;
        

        
        public string Address
        {
            get { return address; }
            set { address = value; }

        }
       
        public string Email
        {
            get { return email; }
            set { email = value; }

        }
        public string PassportId
        {
            get { return passport_id; }
            set { passport_id = value; }

        }
        // Constructor
        public Criminal(string first_name, string last_name, string address, 
            string phone, string email, string passport_id)
        {
            FirstName = first_name;
            LastName = last_name;
            Address = address;
            Phone = phone;
            Email = email;
            PassportId = passport_id;


        }
        



    }
    /// <summary>
    /// The 'Police' class
    /// </summary>
    public class Police : IObserver
    {
      
        private string position;
        private string police_license_number;
        
        


        
        public string Position
        {
            get { return position; }
            set { position = value; }

        }
        
        public string PoliceLisenceNumber
        {
            get { return police_license_number; }
            set { police_license_number = value; }

        }
        // Constructor
        public Police(string first_name, string last_name, string position, 
            string police_license_number, string phone)
        {
            FirstName = first_name;
            LastName = last_name;
            Phone = phone;
            Position = position;
            PoliceLisenceNumber = police_license_number;


        }
        

    }
    /// <summary>
    /// The 'Bailiff' class
    /// </summary>
    public class Bailiff : IObserver
    {
       
        private string department_number;
        private string license_number;
       
       


        
        public string DepartmentNumber
        {
            get { return department_number; }
            set { department_number = value; }

        }
       

        public string LisenceNumber
        {
            get { return license_number; }
            set { license_number = value; }

        }
        // Constructor
        public Bailiff(string first_name, string last_name, string department_number, 
            string license_number, string phone)
        {
            FirstName = first_name;
            LastName = last_name;
            Phone = phone;
            DepartmentNumber = department_number;
            LisenceNumber = license_number;


        }
       


    }


}