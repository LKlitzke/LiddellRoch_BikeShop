using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            _db.ApplicationUsers.Update(ApplicationUser);
        }
    }
}
