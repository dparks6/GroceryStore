using CombinedAPI.Models;

namespace CombinedAPI.Interfaces
{
  public interface IUserAccessor
  {
      public User GetUserById(int userId);
      bool UpdateUser(int id, User user);
      bool DeleteUser(int id);
      bool CreateUser(User user);
  }
}