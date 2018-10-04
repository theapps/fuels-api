using System.Linq;
using api.Database;
using api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace api.Services
{
    public class UserServiceFake : IUserService
    {
        private AppDb _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
 
        public UserServiceFake(IHttpContextAccessor httpContextAccessor, AppDb db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public int CurrentUserId
        {
            get
            {
                if (!EnumerableExtensions.Any(_db.Accounts))
                {
                    _db.Add(new Account {Telephone = "911"});
                    _db.SaveChanges();
                }

                return _db.Accounts.First().Id;
            }
        }
    }
}