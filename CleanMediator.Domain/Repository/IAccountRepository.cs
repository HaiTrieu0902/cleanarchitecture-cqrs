using CleanMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Domain.Repository
{
    public interface IAccountRepository
    {
        Task<List<Account>> SearchAccountsync();
        Task<Account> DetailAccountAsync(string id);
        Task<Account> CreateAccountAsync(Account account);
        Task<string> UpdateAccountAsync(Account account);
        Task<string> DeleteAccountAsync(string id);
    }
}
