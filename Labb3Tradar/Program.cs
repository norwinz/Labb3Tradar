using System;
using System.Collections.Generic;
using System.Threading;

namespace Labb3Tradar
{
    public class Program
    {
        static void Main(string[] args)
        {

            Car CarA = new Car("Anas");
            Car CarB = new Car("Tobias");
            List<Car> AllCars = new List<Car>();
            AllCars.Add(CarA);
            AllCars.Add(CarB);
            
            
                
                Thread CarAThread = new Thread(new ThreadStart(CarA.race));
                Thread CarBThread = new Thread(new ThreadStart(CarB.race));
                Thread WinnerThread = new Thread(new ThreadStart(delegate()
                {
                bool WeHaveAWinner = false;
                while (!WeHaveAWinner)
                {
                    foreach (Car item in AllCars)
                    {
                        if (item.winner == true)
                        {
                            Console.WriteLine("{0} won the race!", item.Name);
                            WeHaveAWinner = true;
                        }
                    }
                }
            }));
            while (true)
            { 
                Console.WriteLine(
                "1.Start the race!\n" +
                "2. Change Racer 1 name ({0})\n" +
                "3. Change Racer 2 name ({1})\n" +
                "4. Change Car Speed ({2} km/h)\n" +
                "5. Change Race Distance ({3} km)", CarA.Name, CarB.Name, CarA.Speed, CarA.raceLength/1000);

                string menuOption = Console.ReadLine();
                 switch (menuOption)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Race starts in 3:");
                            Thread.Sleep(1000);
                            Console.WriteLine("2");
                            Thread.Sleep(1000);
                            Console.WriteLine("1");
                            Thread.Sleep(1000);
                            Console.WriteLine("GO!");                            
                            CarAThread.Start();
                            CarBThread.Start();
                            WinnerThread.Start();
                            Console.WriteLine("Press enter to show race details");
                            foreach (Car item in AllCars)
                            {
                                while (item.Distance <= item.raceLength)
                                {
                                    Console.ReadKey();
                                    raceStatus(AllCars);
                                    Console.WriteLine();
                                }
                            }
                            Console.Clear();
                            continue;
                        }
                    case "2":
                        {
                            CarA.changeName();
                            Console.Clear();
                            continue;
                        }
                    case "3":
                        {
                            CarB.changeName();
                            Console.Clear();
                            continue;
                        }
                    case "4":
                        {
                            bool correctspeed = false;
                            double newspeed=120;
                            while (!correctspeed)
                            {
                                Console.WriteLine("Change speed of the cars: (km/h)");
                                try
                                {
                                    newspeed = Convert.ToDouble(Console.ReadLine());
                                    correctspeed = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Need to be a number");
                                    correctspeed = false;
                                }
                                
                            }
                            CarA.Speed = newspeed;
                            CarB.Speed = newspeed;
                            Console.Clear();
                            continue;
                        }
                    case "5":
                        {
                            bool correctRaceLength = false;
                            double newRaceLength = 10000;
                            while (!correctRaceLength)
                            {
                                Console.WriteLine("Change the distance of the race: (km)");
                                try
                                {
                                    newRaceLength = Convert.ToDouble(Console.ReadLine());
                                    correctRaceLength = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Need to be a number");
                                    correctRaceLength = false;
                                }

                            }
                            newRaceLength = newRaceLength * 1000;
                            CarA.raceLength = newRaceLength;
                            CarB.raceLength = newRaceLength;
                            Console.Clear();
                            continue;
                        }
                    default:
                        {                            
                            Console.WriteLine("Incorrect.\nWrite a number from the menu.\n");
                            continue;
                        }
                }
            }                    
        }
        static void raceStatus(List<Car> allcars)
        {
            foreach (Car item in allcars)
            {
                if (item.Distance >= item.raceLength)
                {
                    Console.WriteLine("{0} have finished the race!", item.Name);
                }
                else
                {
                    Console.WriteLine("{0} have raced {1:0.###} km. Current speed is: {2} km/h", item.Name, item.Distance / 1000, item.Speed * item.carStop);
                }
            }
        }
    
    }
}
