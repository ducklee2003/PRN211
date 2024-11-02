using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SystemAccountDTO
    {
        public short AccountId { get; set; }

        public string? AccountName { get; set; }

        public string? AccountEmail { get; set; }

        public int? AccountRole { get; set; }

        public string? AccountPassword { get; set; }

        public SystemAccountDTO(short accountId, string? accountName, string? accountEmail, int? accountRole, string? accountPassword)
        {
            AccountId = accountId;
            AccountName = accountName;
            AccountEmail = accountEmail;
            AccountRole = accountRole;
            AccountPassword = accountPassword;
        }
    }
}
