using BusinessObject;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly SystemAccountDAO _systemAccountDAO;

        public SystemAccountRepository() 
        {
            _systemAccountDAO = SystemAccountDAO.instance;
        }
        public  async Task<SystemAccount?> Login(LoginDTO loginDTO)
        {
            SystemAccount? systemAccount = new SystemAccount();
            systemAccount = await _systemAccountDAO.Login(loginDTO.AccountEmail, loginDTO.AccountPassword);
            return systemAccount;
        }

        public async Task<string> GetNameById(short? id)
        {
            return await _systemAccountDAO.GetNameById(id);
        }

        public async Task DeleteAccount(short accountId)
        {
            await _systemAccountDAO.DeleteAccount(accountId);
        }

        public async Task<List<SystemAccount>> GetAllSystemAccount()
        {
            return await _systemAccountDAO.GetAllSystemAccount();
        }

        public async Task CreateAccount(SystemAccount systemAccount)
        {
            await _systemAccountDAO.CreateAccount(systemAccount);
        }

        public async Task<short> GenerateAccountID()
        {
            return await _systemAccountDAO.GenerateAccountID();
        }

        public Task<bool> ValidGmail(string email)
        {
            return _systemAccountDAO.ValidGmail(email);
        }
        public Task<bool> ValidName(string name)
        {
            return _systemAccountDAO.ValidName(name);
        }

        public async Task UpdateAccount(SystemAccount systemAccount)
        {
            await _systemAccountDAO.UpdateAccount(systemAccount);
        }

        public async Task<List<SystemAccount>> SearchAccountByName(string name)
        {
            return await _systemAccountDAO.SearchAccountByName(name);
        }

        public async Task<SystemAccount> GetAccountById(short? accountId)
        {
            return await _systemAccountDAO.GetAccountById(accountId);
        }
        public async Task<bool> CheckName(string name)
        {
            return await _systemAccountDAO.CheckName(name);
        }
        public async Task<bool> CheckEmail(string email)
        {
            return await _systemAccountDAO.CheckEmail(email);
        }
    }
}
