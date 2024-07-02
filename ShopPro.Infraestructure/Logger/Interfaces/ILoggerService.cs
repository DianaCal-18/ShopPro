

namespace ShopPro.Infraestructure.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message);
    }
}
