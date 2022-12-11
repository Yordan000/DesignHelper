using DesignHelper.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Contracts.Admin
{
    public interface IUserService
    {
        string UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();
    }
}
