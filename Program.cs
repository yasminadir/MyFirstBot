using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MyFirstBot
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main() {
            botClient = new TelegramBotClient("700484047:AAE8DSGBQaMLUO6hYLTqYgJ6Yh0AJwBtcc0");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                /*await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "You said:\n" + e.Message.Text
                );*/

                await botClient.SendStickerAsync(
                    chatId:  e.Message.Chat,
                    sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"
                );

                await botClient.SendVideoAsync(
                    chatId:  e.Message.Chat,
                    video: "https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"
                );
            }
        }
        /*static void Main() {
            var botClient = new TelegramBotClient("700484047:AAE8DSGBQaMLUO6hYLTqYgJ6Yh0AJwBtcc0");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
        }*/
        /*static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }*/
    }
}
