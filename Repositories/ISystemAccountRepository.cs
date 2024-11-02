using BusinessObject;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISystemAccountRepository
    {
        Task<SystemAccount?> Login(LoginDTO loginDTO);
        Task<string> GetNameById(short? id);
        Task DeleteAccount(short accountId);
        Task<List<SystemAccount>> GetAllSystemAccount();
        Task CreateAccount(SystemAccount systemAccount);
        Task<short> GenerateAccountID();
        Task<bool> ValidGmail(string email);
        Task<bool> ValidName(string name);
        Task UpdateAccount(SystemAccount systemAccount);
        Task<List<SystemAccount>> SearchAccountByName(string name);
        Task<SystemAccount> GetAccountById(short? accountId);
        Task<bool> CheckName(string name);
        Task<bool> CheckEmail(string email);
    }
}
