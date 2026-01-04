using System;
using LlmTornado;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
public static class AiManager
{
    static Conversation? chat;
    public static void SetupChat()
    {
        TornadoApi api = new TornadoApi(new Uri("http://localhost:11434"));
        chat = api.Chat.CreateConversation(new ChatModel("llama2"));
    }

    public static async Task<string> Generate(string prompt)
    {
        Console.WriteLine("Big Kloc");

        //TornadoApi api = new TornadoApi(new Uri("http://localhost:11434"));
        //Console.WriteLine("HIJKLMNOP");

        //Conversation chat = api.Chat.CreateConversation(new ChatModel("llama2"));

        try
        {
            string response = await chat.AppendUserInput(prompt).GetResponse();

            return response!;

        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

}