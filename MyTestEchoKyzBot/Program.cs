using MihaZupan;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MyTestEchoKyzBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
           // var proxy = new HttpToSocks5Proxy("67.205.149", 230);
           // botClient = new TelegramBotClient("827257247:AAEMC3r9jfkSX_UwdLCp87dPgG92o2ippfU", proxy); //{Timeout= TimeSpan.FromSeconds(10)};
            botClient = new TelegramBotClient("827257247:AAEMC3r9jfkSX_UwdLCp87dPgG92o2ippfU");

           var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot id {me.Id}. Bot Name: {me.FirstName}");

            botClient.OnMessage += Bot_OnMessage;
            Console.ReadKey();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)          
                return;
                Console.WriteLine($"resived text message '{text}' in chat '{e.Message.Chat.Id}'");
            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"You said '{text}'"
                ).ConfigureAwait(false);


        }
    }
}
