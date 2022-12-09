namespace SmartPark.Application.Common.Interfaces;
public interface ITextRecognitionService
{
    Task<string> RecognizeFromImageAsync(byte[] fileBytes);
}