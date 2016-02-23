namespace SupportMe.Services.Data.Contracts
{
    using SupportMe.Data.Models;

    public interface ILogService : IBaseService<RequestLog>
    {
        void LogRequest(string userId, string ip, string url, string method);
    }
}