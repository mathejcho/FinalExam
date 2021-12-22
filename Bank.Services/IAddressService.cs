using Bank.Models.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
   public interface IAddressService
    {
        

        Task<AddressExtended> GetAddressById(int id);

        Task<IEnumerable<AddressModelBase>> Get();

        Task<IEnumerable<AddressExtended>> GetByUserId(int id);

        Task<AddressModelBase> Insert(AddressCreatedModel model);

        Task<AddressModelBase> Update(AddressUpdateModel model);

        Task<bool> Delete(int id);
    }
}

