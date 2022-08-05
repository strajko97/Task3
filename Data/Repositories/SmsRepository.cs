using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SmsRepository:ISmsRepository
    {
        private MyDbContext myDbContext;

        public SmsRepository(MyDbContext context)
        {
           myDbContext = context;
        }

        public async Task<Sms> CreateSmsAsync(Sms smsToSend)
        {
             await myDbContext.Smss.AddAsync(smsToSend);
           await myDbContext.SaveChangesAsync();
            return smsToSend;
        }

        public async Task<IEnumerable<Sms>> GetSentSmssAsync()
        {
            return await myDbContext.Smss.Where(s => s.Status == 1).Include(s => s.Country).ToListAsync();
        }

        public async Task<IEnumerable<Sms>> GetSentSmssByDateAsync(DateTime dateFrom, DateTime dateTo)
        {
           
            return await myDbContext.Smss.Where(s => s.Status == 1 && s.SendTime>=dateFrom && s.SendTime<=dateTo).Include(s => s.Country).ToListAsync();
        }
    }
}
