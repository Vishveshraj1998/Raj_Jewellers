using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using RajJewels.domain.Entities;
using RajJewels.domain.IRepositories;

namespace RajJewels.domain;

public class Repository: IRepository
{
    // Intializers
    private readonly DBContext _context;

    // Constructor
    public Repository(DBContext context)
    {
        _context = context;
    }

    // Getting the User values
    public async Task<RjUser> getUsers(string userID, string password)
    {
        return await _context.RjUsers.FirstOrDefaultAsync(x => x.UserId == userID && x.Pass == password);
    }

    // Saving the user values
    public int SaveUsers(RjUser user)
    {
        var emplyee = new RjUser();
        _context.Add<RjUser>(user);
        _context.SaveChanges();
        return 1;
    }

}

