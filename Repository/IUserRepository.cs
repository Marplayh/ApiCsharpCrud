using mySQLAPI.Model;

namespace mySQLAPI.Repository;

public interface IUserRepository
{
    IEnumerable<User>GetAll();
    User Get(int id);
    int insertUser(User user);
    int deleteUser(int id);
    int updateUser(int id, string name);
}
