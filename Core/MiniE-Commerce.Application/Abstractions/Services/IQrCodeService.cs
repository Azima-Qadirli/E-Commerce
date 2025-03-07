namespace MiniE_Commerce.Application.Abstractions.Services
{
    public interface IQrCodeService
    {
        byte[] GenerateQrCode(string text);
    }
}
