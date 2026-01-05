using System;
using System.Runtime.Serialization;
using LlmTornado;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using RPG;
public static class AiManager
{
    static Conversation? chat;
    public static bool isGenerating = false;
    public static void SetupChat()
    {
        TornadoApi api = new TornadoApi(new Uri("http://localhost:11434"));
        chat = api.Chat.CreateConversation(new ChatModel("llama3.1:8b"));
    }

    public static async Task<string> Generate(string prompt)
    {
        if (chat == null)
        {
            SetupChat();
        }

        //Console.WriteLine("Big Kloc");

        //TornadoApi api = new TornadoApi(new Uri("http://localhost:11434"));
        //Console.WriteLine("HIJKLMNOP");

        //Conversation chat = api.Chat.CreateConversation(new ChatModel("llama2"));

        try
        {
            isGenerating = true;
            _ = Utils.GeneratingLoadingAsync();
            string response = await chat.AppendUserInput(prompt).GetResponse();
            isGenerating = false;

            return response!;

        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

}