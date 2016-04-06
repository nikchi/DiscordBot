using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordSharp;
using System.Threading;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            String email = "enchoibots@gmail.com";
            String passw = "nickchoi1";

            /*
            //user input
            Console.WriteLine("Bot's Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Bot's Password: ");
            passw = Console.ReadLine();
            Console.Clear();
            */
            //client creation
            DiscordClient client = new DiscordClient();
            client.ClientPrivateInformation.Email = email;
            client.ClientPrivateInformation.Password = passw;

            //interactions
            client.MessageReceived += (sender, e) => // Channel message has been received
            {
                if (e.message.Content == "help")
                {
                    Console.WriteLine("help detected");
                    e.Channel.SendMessage("This is a public message!");
                    // Because this is a public message, 
                    // the bot should send a message to the channel the message was received.
                }
                Console.WriteLine(e.message.Content);
            };


            //connect
            try
            {
                client.SendLoginRequest();
                Thread t = new Thread(client.Connect);
                t.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            



            //keep open
            Console.ReadKey();


        }
    }
}
