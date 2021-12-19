using Sample_Proj.Models;
using System.Threading.Tasks;

namespace Sample_Proj.Services
{
    public interface IDataProcessRepository
    {
        Task<ClientSettings> GetClientSettings(string id);
    }
}
