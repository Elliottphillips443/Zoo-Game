using System;
using System.Timers;

namespace Zoo
{
    class Program
    {
        static float[,] animalHp = new float[3, 5];

        static int time = 0;


        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Enter Start to begin simulation");
                Console.WriteLine("Enter Exit to End simulation");
                string line = Console.ReadLine(); // read command
                Console.Clear();

                if (line == "Exit" || line == "exit") // Check string then exit program
                {
                    break;
                }
                else if (line == "Start" || line == "start")
                {
                    


                    while (true)
                    {
                        Timer t = new Timer(20000); // 1 sec = 1000, 60 sec = 60000

                        t.AutoReset = true;

                        t.Elapsed += new System.Timers.ElapsedEventHandler(TimeHasPassed);

                        t.Start();

                        for (int i = 0; i < animalHp.GetLength(0); i++)
                        {
                            for (int j = 0; j < animalHp.GetLength(1); j++)
                            {
                                animalHp[i, j] = 100f;
                            }
                        }



                        for (int i = 0; i < animalHp.GetLength(0); i++)
                        {
                            for (int j = 0; j < animalHp.GetLength(1); j++)
                            {
                                if (i == 0)
                                {
                                    Console.WriteLine("Monkey " + (j + 1) + " " + animalHp[i, j] + " Hp");
                                }
                                else if (i == 1)
                                {
                                    Console.WriteLine("Giraffe " + (j + 1) + " " + animalHp[i, j] + " Hp");
                                }
                                else
                                {
                                    Console.WriteLine("Elephant " + (j + 1) + " " + animalHp[i, j] + " Hp");
                                }
                            }
                        }


                        Console.WriteLine(" ");
                        Console.WriteLine(time + ":00");
                        Console.WriteLine(" ");
                        Console.WriteLine("Enter Feed to Feed Animal");
                        Console.WriteLine("Enter Pass to advance one hour");
                        Console.WriteLine("Enter Exit to End simulation");
                        line = Console.ReadLine(); // read command
                        Console.Clear();

                        if (line == "Exit" || line == "exit") // Check string then exit program
                        {
                            break;
                        }
                        else if (line == "Feed" || line == "feed")
                        {
                            Console.WriteLine("please Enter Animal Type to feed");

                            if (line == "Monkey" || line == "monkey")
                            {
                                for (int j = 0; j < 5; j++)
                                {

                                    Console.WriteLine("Monkey " + (j + 1) + " " + animalHp[0, j] + " Hp");

                                }
                                Console.WriteLine("please which Monkey to feed");

                                line = Console.ReadLine();
                                

                                for (int i = 0; i < animalHp.GetLength(1); i++)
                                {
                                    if (i == StringToInt(line))
                                    {
                                        animalHp[0, i] += RandomNumber(10,25);
                                        if(animalHp[0, i] > 100)
                                        {
                                            animalHp[0, i] = 100f;
                                        }
                                    }
                                }


                                

                            }
                            else if (line == "Giraffe" || line == "giraffe")
                            {
                                for (int j = 0; j < 5; j++)
                                {

                                    Console.WriteLine("Giraffe " + (j + 1) + " " + animalHp[1, j] + " Hp");

                                }
                                Console.WriteLine("please which Giraffe to feed");

                                line = Console.ReadLine();


                                for (int i = 0; i < animalHp.GetLength(1); i++)
                                {
                                    if (i == StringToInt(line))
                                    {
                                        animalHp[1, i] += RandomNumber(10, 25);
                                        if (animalHp[1, i] > 100)
                                        {
                                            animalHp[1, i] = 100f;
                                        }
                                    }
                                }

                            }
                            else if (line == "Elephant" || line == "elephant")
                            {
                                for (int j = 0; j < 5; j++)
                                {

                                    Console.WriteLine("Elephant " + (j + 1) + " " + animalHp[2, j] + " Hp");

                                }
                                Console.WriteLine("please which Elephant to feed");

                                line = Console.ReadLine();


                                for (int i = 0; i < animalHp.GetLength(1); i++)
                                {
                                    if (i == StringToInt(line))
                                    {
                                        animalHp[2, i] += RandomNumber(10, 25);
                                        if (animalHp[2, i] > 100)
                                        {
                                            animalHp[2, i] = 100f;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Error " + line + " unkown Command");
                            }



                        }
                        else if (line == "Pass" || line == "pass")
                        {
                            time++;
                        }
                        else
                        {
                            Console.WriteLine("Error " + line + " unkown Command");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error " + line + " unkown Command");
                }



            }


        }

       static int RandomNumber(int minConstraint, int maxConstraint)
        {
            int generatedNumber = 0;
            Random generatingNumber = new Random();
            generatedNumber = generatingNumber.Next(minConstraint, maxConstraint);

            return generatedNumber;
        }

       static int StringToInt(string convertToInt)
        {
            int convertedInt = 0;
            convertedInt = Convert.ToInt32(convertedInt);

            return convertedInt;
        }

        static void TimeHasPassed(object sender, System.Timers.ElapsedEventArgs e)
        {

            time++;

            if (time > 24)
            {
                time = 0;
            }

            animalHp[RandomNumber(0, animalHp.GetLength(0)), RandomNumber(0, animalHp.GetLength(1))] -= RandomNumber(0, 20);

        }

    }

}
