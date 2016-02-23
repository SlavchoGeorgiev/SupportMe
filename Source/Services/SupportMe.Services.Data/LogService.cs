namespace SupportMe.Services.Data
{
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class LogService : BaseService<RequestLog>, ILogService
    {
        public LogService(IDbRepository<RequestLog> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }

        public void LogRequest(string userId, string ip, string url, string method)
        {
            var log = new RequestLog()
            {
                Ip = ip,
                UserId = userId,
                Url = url,
                Method = method
            };

            this.BaseRepository.Add(log);
            this.BaseRepository.SaveChanges();
        }
    }
}
