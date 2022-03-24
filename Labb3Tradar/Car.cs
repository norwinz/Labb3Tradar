using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labb3Tradar
{
   public class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public double raceLength { get; set; }
        public bool winner { get; set; }
        public int carStop { get; set; }
        public Car(string _Name)
        {
            Name = _Name;
            Speed = 120; //in km/h
            Distance = 0; //in meters
            raceLength = 10000; //in meters
            winner = false;
            carStop = 1; //Value will be set to 0 if the car is forced to stop
        }

        public void race()
        { 
            Thread problemThread = new Thread(new ThreadStart(problem));
            problemThread.Start();
            while(Distance < raceLength)
            {
                Thread.Sleep(1000);
                Distance += (Speed*0.27777778) * carStop;  //Km/h --> m/s conversion. Carstop will be set to 0 if car stops.
            }
            winner = true;        
            Console.WriteLine("{0} finish!", Name);
        }
        public void problem()
        {                  
                while (true)
                {
                    Thread.Sleep(30000);
                    Random rnd = new Random();
                    int problemRnd = rnd.Next(1, 51);
                    if (Distance > raceLength)
                    {
                    //Stop Problems to show if race is finished
                    }
                    else
                    {                    
                    if (problemRnd == 1)
                    {
                        Thread refuelThread = new Thread(new ThreadStart(problemRefuel));
                        refuelThread.Start();
                    }
                    if (problemRnd == 2 || problemRnd == 3)
                    {
                        Thread flatThread = new Thread(new ThreadStart(problemFlat));
                        flatThread.Start();
                    }
                    if (problemRnd >= 4 && problemRnd <= 8)
                    {
                        Thread birdThread = new Thread(new ThreadStart(problemBird));
                        birdThread.Start();
                    }
                    if (problemRnd >= 9 && problemRnd <= 18) 
                    {
                        problemEngine();
                    }
                    if (problemRnd >= 19)
                    {
                        Console.WriteLine("{0} keeps racing. Go Go Go!", Name);
                    }
                }
            }
            
        }
        public void problemRefuel()
        {
            Console.WriteLine("{0} needs to refuel, it will take 30 seconds!", Name);
            carStop = 0;
            Thread.Sleep(30000);
            Console.WriteLine("Refueling done! {0} continues the race", Name);
            carStop = 1;

        }
        public void problemFlat()
        {
            Console.WriteLine("Oh no! {0} has a flat tire, it will take 20 seconds to change to a new one!", Name);
            carStop = 0;
            Thread.Sleep(20000);
            Console.WriteLine("Tire change is done! {0} continues the race", Name);
            carStop = 1;
        }
        public void problemBird()
        {
            Console.WriteLine("BIRD STRIKE! A bird have hit the windshield. {0} need to stop and clean it, it will take 10 seconds!", Name);
            carStop = 0;
            Thread.Sleep(10000);
            Console.WriteLine("Windshield is cleaned! {0} continues the race", Name);
            carStop = 1;
        }
        public void problemEngine()
        {
            Speed -= 1;
            Console.WriteLine("The engine have lost power! {0} will drive slower for the rest of the race. Current speed is: {1} km/h", Name, Speed);           
            
        }
        public void changeName()
        {
            Console.WriteLine("New name: ");
            Name = Console.ReadLine();
        }
    }
}
