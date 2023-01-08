using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using SmartPark.Application.Common.Interfaces;
using System.Drawing;
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

    //public byte[] IncreaseQuality(byte[] photoBytes)
    //{
    //    int quality = 99;
    //    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;
    //    Size size = new Size(400, 600);
    //    using (MemoryStream inStream = new MemoryStream(photoBytes))
    //    {
    //        using (MemoryStream outStream = new MemoryStream())
    //        {
    //            using (ImageFactory imageFactory = new ImageFactory())
    //            {
    //                // Load, resize, set the format and quality and save an image.
    //                imageFactory.Load(inStream)
    //                            .Resize(size)
    //                            .Quality(quality)
    //                            .GaussianSharpen(1)
    //                            .Save(outStream);
    //            }

    //            return outStream.ToArray();
    //            // Do something with the stream.
    //        }
    //    }
    //}
}