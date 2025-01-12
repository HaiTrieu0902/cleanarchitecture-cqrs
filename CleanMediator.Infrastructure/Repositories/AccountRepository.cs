using CleanMediator.Domain.Entities;
using CleanMediator.Domain.Repository;
using CleanMediator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TenantDbContext _tenantDbContext;

        public AccountRepository(TenantDbContext accountDbContext)
        {
            _tenantDbContext = accountDbContext;
        }


        public async Task<List<Account>> SearchAccountsync()
        {
            return await _tenantDbContext.Accounts.ToListAsync();
        }


        public async Task<Account> DetailAccountAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }

            return await _tenantDbContext.Accounts.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            await _tenantDbContext.Accounts.AddAsync(account);
            await _tenantDbContext.SaveChangesAsync();
            return account;
        }

        public async Task<string> UpdateAccountAsync(Account account)
        {
            if (account == null || string.IsNullOrEmpty(account.Id))
            {
                return "Invalid input.";
            }

            var affectedRows = await _tenantDbContext.Accounts
                .Where(model => model.Id == account.Id) 
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Name, account.Name)
                    .SetProperty(m => m.Password, account.Password)
                    .SetProperty(m => m.PhoneNumber, account.PhoneNumber)
                    .SetProperty(m => m.Email, account.Email)
                );

            return affectedRows > 0
                ? "Update successful."
                : "No record updated.";
        }

        public async Task<string> DeleteAccountAsync(string id)
        {
            var affectedRows = await _tenantDbContext.Accounts
            .Where(model => model.Id == id)
            .ExecuteDeleteAsync();
            return affectedRows > 0 ? "Success" : "Failed";
        }

    }
}
