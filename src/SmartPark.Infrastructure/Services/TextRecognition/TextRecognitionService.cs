using SmartPark.Application.Common.Interfaces;
using System.Reflection;
using Tesseract;

namespace SmartPark.Infrastructure.Services.TextRecognition;
public class TextRecognitionService : ITextRecognitionService
{
    private readonly string _testsdataPath;
    public TextRecognitionService()
	{
        _testsdataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"Services\TextRecognition\tessdata");
    }

	public Task<string> RecognizeFromImageAsync(byte[] fileBytes) 
	{
        string text;
        using (var engine = new TesseractEngine(_testsdataPath, "eng", EngineMode.Default))
        {
            using (var img = Pix.LoadFromMemory(fileBytes))
            {
                using (var page = engine.Process(img))
                {
                    text = page.GetText();
                }
            }
        }
        return Task.FromResult(text);
    }
}