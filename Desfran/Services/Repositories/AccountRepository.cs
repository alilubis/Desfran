using Desfran.Models.DBContext;
using Desfran.Models.Entities;
using Desfran.Models.Helpers;
using Desfran.Services.Interfaces;

namespace Desfran.Services.Repositories
{
    public class AccountRepository : IAccountInterface
    {
        private readonly DesfranContext _db;

        public AccountRepository(DesfranContext db)
        {
            _db = db;
        }
        public Account? Login(Account account)
        { 
            account.Password = HashEncryptedHelper.HashPassword(account.Password);

            var obj = _db.Accounts.Where(u => u.Email.Equals(account.Email) && u.Password.Equals(account.Password)).FirstOrDefault();
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        public Account? ExistAccount(string email)
        {
            var obj = _db.Accounts.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        public Account Register(Account user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.Password = HashEncryptedHelper.HashPassword(user.Password);

            _db.Accounts.Add(user);
            _db.SaveChanges();

            return user;
        }
    }
}
