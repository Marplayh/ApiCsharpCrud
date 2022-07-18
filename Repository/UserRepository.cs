using Dapper;
using mySQLAPI.Model;
using MySqlConnector;

namespace mySQLAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString){
        _connectionString = connectionString;
    }
    public IEnumerable<User>GetAll()
    {
        var sql = "SELECT * FROM User";

        using (MySqlConnection connection = new MySqlConnection(_connectionString)){
            return connection.Query<User>(sql);
        }
    }

    public User Get(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString)){
            var user = connection.QuerySingleOrDefault<User>($"SELECT * FROM User WHERE id = {id};");
            return user;
        }
    }
    public int insertUser(User newUser)
    {
        var sql = "INSERT INTO User VALUES(@Id, @Name, @Age);";

        User user = new User(){
            Id    = newUser.Id,
            Name  = newUser.Name,
            Age   = newUser.Age
        };

        using (MySqlConnection connection = new MySqlConnection(_connectionString)){
            return connection.Execute(sql, user);
        }
    }

     public int updateUser(int id, string name)
    {
        var sql = "UPDATE User SET Name = @name WHERE Id = @id;";

        using (MySqlConnection connection = new MySqlConnection(_connectionString)){
            return connection.Execute(sql, new {id, name});
        }
    }

    public int deleteUser(int id)
    {
        var sql = "DELETE FROM User WHERE Id = @id;";

        using (MySqlConnection connection = new MySqlConnection(_connectionString)){
            return connection.Execute(sql, new  {id} );
        }
    }
}
