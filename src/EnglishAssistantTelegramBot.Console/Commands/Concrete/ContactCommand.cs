using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    public class ContactCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public ContactCommand(ITelegramClient telegramClient)
        {
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            string messageContent = $"🇬🇧: Hi {message.From.FirstName ?? message.From.Username} 👋\n" +
                                    $"I am Katya. I created this bot to make your work easier while you are studying English. I am here if you want to request a new feature, support or say hi. 🤗🌺\n\n" +

                                    $"🇷🇺: Привет {message.From.FirstName ?? message.From.Username} 👋\n" +
                                    $"Я Катя. Я создала этого бота, чтобы облегчить вам работу во время изучения английского языка. Я здесь, если вы хотите запросить новую функцию, поддержать или поздороваться. 🤗🌺";

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, messageContent);
        }
    }
}
