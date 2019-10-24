using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ClassLibrary;

namespace TCPBilAfgift
{
    class EchoService
    {
        private TcpClient connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing


            string greeting = "Ønsker de at beregne bilafgift? (y/n)";
            string selectCar = "For almindelig bil tast 1, for elbil tast 2";
            string writePrice = "Indtast pris";
            string selectedCarType;
            string message = "0";

            sw.WriteLine(greeting);

            while (message != "STOP" && message != null && message !="")
            {               
                try
                {
                    GreetClient();
                }
                catch (Exception e)
                {
                    CloseConnection();
                    break;
                }

                Console.WriteLine();
            }

            void GreetClient()
            { 
                Console.WriteLine(greeting);
                message = sr.ReadLine();
                Console.WriteLine("Client: " + message);

                if (message == "y")
                {
                    sw.WriteLine(selectCar);
                    SelectCarType();
                }
                else if (message == "n")
                {
                    sw.WriteLine("For at terminere forbindelse tast: STOP." + greeting);
                    try
                    {
                        GreetClient();
                    }
                    catch (Exception e)
                    {
                       CloseConnection();
                    }
                }
                else
                {
                    sw.WriteLine("Fejl." + greeting);
                    Console.WriteLine("Fejl");
                    GreetClient();
                }
            }

            void SelectCarType()
            {
                message = sr.ReadLine();
                selectedCarType = message;

                if (selectedCarType == "1" || selectedCarType == "2")
                {
                    Console.WriteLine("Client: " + selectedCarType);

                    switch (selectedCarType)
                    {
                        case "1":
                            sw.WriteLine("Valgt almindelig bil. " + writePrice);
                            Console.WriteLine("Valgt almindelig bil. " + writePrice);
                            break;
                        case "2":
                            sw.WriteLine("Valgt elbil. " + writePrice);
                            Console.WriteLine("Valgt elbil. " + writePrice);
                            break;
                    }

                    CalculateLevy();
                }
                else
                {
                    sw.WriteLine("Fejl. " + selectCar);
                    Console.WriteLine("Fejl fra klient.");
                    SelectCarType();
                }
            }

            void CalculateLevy()
            {
                string priceString = sr.ReadLine();
                Console.WriteLine("Client: " + priceString);
                int price = Convert.ToInt32(priceString);

                int levy = 0;
                if (price > 0)
                {
                    switch (selectedCarType)
                    {
                        case "1":
                            levy = Afgift.BilAfgift(price);
                            break;
                        case "2":
                            levy = Afgift.ElbilAfgift(price);
                            break;
                    }

                    int totalPrice = price + levy;
                    string result = $"Beregnet afgift for en importeret bil til {price} DKK er: {levy}DKK. Totalpris: {totalPrice} DKK";
                    sw.WriteLine(result + " " + greeting);
                    Console.WriteLine(result);
                    Console.WriteLine(" Restarting procedure...");
                }
                else
                {
                    sw.WriteLine("Ugyldig pris. " + writePrice);
                    Console.WriteLine("Ugyldig pris.");
                    CalculateLevy();
                }


            }

            void CloseConnection()
            {
                Console.WriteLine("Klienten har afbrudt forbindelsen.");
                ns.Close();
                connectionSocket.Close();
            }
        }
    }
}
