using NewsWebsite.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.Role

{
    public interface IRoleService
    {
        Task<List<WebRoleVM>> GetAll();
        Task<WebRoleVM> GetRoleById(Guid Id);
    }
}
