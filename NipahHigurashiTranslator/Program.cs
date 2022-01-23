using GoogleTranslateFreeApi;
using System;
using System.Threading.Tasks;

namespace NipahHigurashiTranslator
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var translator = new GoogleTranslator();

            Language from = Language.English;
            Language to = Language.Portuguese;

            Console.WriteLine("Hello, how are you?");

            var result = await translator.TranslateLiteAsync("Hello, how are you?", from, to);

            Console.WriteLine(result.TranslatedTextTranscription);

            Console.ReadKey(true);
        }
    }
}
