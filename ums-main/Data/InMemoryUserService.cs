using UMS.Models;

namespace UMS.Data;

public class InMemoryUserService
{
    private readonly List<User> _users = [];
    private int _nextId = 1;

    public IEnumerable<User> GetAll() => _users.AsReadOnly();

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Create(User user)
    {
        user.Id = _nextId++;
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        _users.Add(user);
        return user;
    }

    public bool Update(int id, User user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == id);
        if (existing == null)
            return false;

        existing.Name = user.Name;
        existing.Email = user.Email;
        existing.Phone = user.Phone;
        existing.UpdatedAt = DateTime.UtcNow;
        return true;
    }

    public bool Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return false;

        _users.Remove(user);
        return true;
    }
}
