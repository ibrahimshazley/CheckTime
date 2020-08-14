using CheckTime.Context;
using CheckTime.Models;
using CheckTime.Repositories.Abstraction;
using CheckTime.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CheckTime.Services.Implementations
{
    public class Check : ICheck
    {
        private readonly IRepository _repo;
        private readonly CheckTimeContext _context;


        public Check(CheckTimeContext context, IRepository repo) 
        {
            _context = context;
            _repo = repo;
        }

        public async Task<bool> checkDateValues(Guid id)
        {
           var Value = await _context.TimeCheck.FirstOrDefaultAsync(x => x.id == id);
            if (Value.ToDate > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
