using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Telegram.Bot;
using Telegram;


namespace Innovatec.Class
{
    public static class Telegram
    {
        public static void Waiter(int seconds)
        {
            for (int i = 0; i < seconds * 10; i++)
            {
                Thread.Sleep(100);
            }
        }

        public static async Task Send_Message(string componente, string de)
        {
            try
            {
                //System.Net.WebRequest.DefaultWebProxy = new WebProxy("http://199.19.250.205/", true);
                TelegramBotClient Bot = new TelegramBotClient("5682386281:AAGyTfOdiLK5pTraWiswom3s6S1Qr5DQE9g");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                await Bot.SendTextMessageAsync("-1001676012208", $@"Favor de pedir mas componente tipo {componente} a {de}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

