using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.Legacy;
using Discord.Audio;
using Discord.Modules;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DiscordClient().UsingAudio(x => x.Bitrate = AudioServiceConfig.MaxBitrate);
            
            //Display all log messages in the console
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");

            //Echo back any message received, provided it didn't come from the bot itself
            client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                    await e.Channel.SendMessage(e.Message.Text);
                if (e.Message.Text == "!test")
                    if (e.User.VoiceChannel != null)
                    {
                        await e.User.VoiceChannel.JoinAudio();
                        //do sound

                        await Task.Delay(1000);
                        await e.User.VoiceChannel.LeaveAudio();
                    }
            };



            //Convert our sync method to an async one and block the Main function until the bot disconnects
            client.ExecuteAndWait(async () =>
            {
                //Connect to the Discord server using our email and password
                await client.Connect("enchoibots@gmail.com", "nickchoi1");
            });
           
            
        }
    }
}
