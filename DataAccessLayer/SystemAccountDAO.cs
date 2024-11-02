using BusinessObject;
using DataAccess;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SystemAccountDAO : SingletonBase<SystemAccountDAO>
    {
        public async Task<SystemAccount?> Login(string email, string password)
        {
            var account = await _context.SystemAccounts.SingleOrDefaultAsync(x => x.AccountEmail == email && x.AccountPassword == password);
            if (account == null) return null;
            return account;
        }

        public async Task<string> GetNameById(short? accountId)
        {
            var account = await _context.SystemAccounts.SingleOrDefaultAsync(x => x.AccountId == accountId);
            if (account != null) return account.AccountName;
            return null;
        }

        public async Task<SystemAccount> GetAccountById(short? accountId)
        {
            return await _context.SystemAccounts.Where(x => x.AccountId == accountId).FirstOrDefaultAsync();
        }

        public async Task<List<SystemAccount>> SearchAccountByName(string name)
        {
            return await _context.SystemAccounts.Where(x => x.AccountName.Contains(name)).ToListAsync();
        }

        public async Task UpdateAccount(SystemAccount systemAccount)
        {
            
            var existItem = await GetAccountById(systemAccount.AccountId);
            if (existItem != null)
                _context.Entry(existItem).CurrentValues.SetValues(systemAccount);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SystemAccount>> GetAllSystemAccount()
        {
            return await _context.SystemAccounts.ToListAsync();
        }

        public async Task DeleteAccount(short accountId)
        {
            var account = await GetAccountById(accountId);
            _context.SystemAccounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAccount(SystemAccount systemAccount)
        {
            _context.SystemAccounts.Add(systemAccount);
            await _context.SaveChangesAsync();
        }

        public async Task<short> GenerateAccountID()
        {
            var id = await _context.SystemAccounts.OrderByDescending(x => x.AccountId).Select(x => x.AccountId).FirstOrDefaultAsync();
            return (short)(id + 1);
        }

        public async Task<bool> ValidGmail(string email)
        {
            string gmailPattern = @"^[^@\s]+@FUNewsManagement\.org$";
            return Regex.IsMatch(email, gmailPattern);
        }
        public async Task<bool> ValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> CheckName(string name)
        {
            var account = _context.SystemAccounts.FirstOrDefault(x => x.AccountName == name);
            if (account != null) return true;
            return false;
        }
        public async Task<bool> CheckEmail(string email)
        {
            var account = _context.SystemAccounts.FirstOrDefault(x => x.AccountEmail == email);
            if (account != null) return true;
            return false;
        }
    }
}
