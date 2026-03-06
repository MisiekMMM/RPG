using System;
using System.Runtime.Serialization;
using LlmTornado;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Code;
using RPG;
using Terminal.Gui;
public static class AiManager
{
    static Conversation? chat;
    public static bool isGenerating = false;
    public static void SetupChat()
    {
        TornadoApi api = new TornadoApi(new Uri("http://localhost:11434"));
        chat = api.Chat.CreateConversation(new ChatModel("nemotron-3-nano:30b"));
        chat.AppendSystemMessage(ReadPrompt());
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/1.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/2.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/3.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/4.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/5.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/6.json"));
        chat.AppendExampleChatbotOutput(File.ReadAllText(@"AiExamples/7.json"));
    }

    static string ReadPrompt()
    {
        return File.ReadAllText(@"nowy_prompt.txt");
    }

    public static async Task<string> Generate(string prompt)
    {
        if (chat == null)
        {
            SetupChat();
        }

        try
        {
            isGenerating = true;
            Manager.nextButton!.Visible = false;

            _ = Utils.GeneratingLoadingAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string response = await chat.AppendUserInput(prompt).GetResponse();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            isGenerating = false;

            File.AppendAllText(@"response.txt", response + "\n\n====================================================\n\n");

            return response!;

        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

}