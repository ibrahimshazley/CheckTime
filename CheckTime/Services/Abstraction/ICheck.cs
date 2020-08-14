using CheckTime.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CheckTime.Services.Abstraction
{
    public interface ICheck 
    {
        Task<bool> checkDateValues(Guid id);
        
    }
}
