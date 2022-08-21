using Desfran.Models.Entities;

namespace Desfran.Services.Interfaces
{
    public interface IAccountInterface
    {
        Account Register(Account account);
        Account? ExistAccount(string email);
        Account? Login(Account account);
    }
}
