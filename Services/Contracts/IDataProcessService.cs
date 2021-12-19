using Sample_Proj.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample_Proj.Services
{
    public interface IDataProcessService
    {
        Task<HashSet<Tuple<string, string, string>>> GetAllFileName(ClientSettings clientSettings);
    }
}
