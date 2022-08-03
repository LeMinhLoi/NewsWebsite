using NewsWebsite.Data.EF;
using NewsWebsite.ViewModel.Role;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsWebsite.Application.Role
{
    public class RoleService : IRoleService
    {
        private readonly WebsiteDBContext _context;
        public RoleService(WebsiteDBContext context)
        {
            _context = context;
        }
        public async Task<List<WebRoleVM>> GetAll()
        {
            var query = from r in _context.WebRoles
                        select new WebRoleVM
                        {Id = r.Id, Name = r.Name, Description = r.Description };
            return await query.ToListAsync();
        }

        public async Task<WebRoleVM> GetRoleById(Guid Id)
        {
            var webRole = await _context.WebRoles.FindAsync(Id);
            if(webRole == null)
            {
                return null;
            }
            var webRoleVM = new WebRoleVM()
            {
                Id = webRole.Id,
                Name = webRole.Name,
                Description = webRole.Description
            };
            return webRoleVM;
        }
    }
}
