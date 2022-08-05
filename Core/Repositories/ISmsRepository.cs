using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISmsRepository
    {
        Task<IEnumerable<Sms>> GetSentSmssAsync();
        Task<IEnumerable<Sms>> GetSentSmssByDateAsync(DateTime dateFrom,DateTime dateTo);
        Task<Sms> CreateSmsAsync(Sms smsToSend);
    }
}
