using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordSharp;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            String email = "";
            String passw = "";

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
  
            //connect
            try
            {
                client.SendLoginRequest();
                client.Connect();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            client.Connected += (sender, e) =>
            {
                Console.WriteLine("Connected User: " + e.user.Username);
                client.UpdateCurrentGame("Big Brother");
            };
            client.MessageReceived += (sender, e) => // Channel message has been received
            {
                if (e.message_text == "help")
                {
                    e.Channel.SendMessage("This is a public message!");
                    // Because this is a public message, 
                    // the bot should send a message to the channel the message was received.
                }
            };



            //keep open
            Console.ReadKey();


        }
    }
}
