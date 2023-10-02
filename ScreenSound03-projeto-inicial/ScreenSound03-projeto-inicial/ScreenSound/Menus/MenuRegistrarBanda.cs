using OpenAI_API;
using ScreenSound.Modelos;


namespace ScreenSound.Menus;
internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    { 
    base.Executar(bandasRegistradas);
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda banda = new Banda(nomeDaBanda);
    bandasRegistradas.Add(nomeDaBanda, banda);

        var client = new OpenAIAPI("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");

        var chat = client.Chat.CreateConversation();

        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em um parágrafo. Adote um estilo informal");

        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.Resumo = resposta;

        Console.WriteLine(resposta);

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(4000);
    Console.Clear();
}
}
