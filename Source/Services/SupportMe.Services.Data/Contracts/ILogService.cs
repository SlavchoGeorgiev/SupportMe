namespace SupportMe.Services.Data.Contracts
{
    using System.Collections.Specialized;
    using System.Net;
    using SupportMe.Data.Models;

    public interface ILogService : IBaseService<RequestLog>
    {
        void LogRequest(string userId, string ip, string url, string method);
    }
}