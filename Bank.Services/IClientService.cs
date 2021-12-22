using Bank.Models.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public interface IClientService
    {
        Task<ClientExtended> GetById(int id);

        Task<IEnumerable<ClientModelBase>> Get();

        Task<IEnumerable<ClientExtended>> GetByUserId(int id);

        Task<ClientModelBase> Insert(ClientCreatedModel model);

        Task<ClientModelBase> Update(ClientUbdateModel model);

        Task<bool> Delete(int id);
    }
}
