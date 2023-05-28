using Microsoft.EntityFrameworkCore;
using RajJewels.domain.Entities;
using RajJewels.domain.IRepositories;

namespace RajJewels.domain;

public class Repository : IRepository
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
        _context.Add<RjUser>(user);
        _context.SaveChanges();
        return 1;
    }

    // Saving the Jewel Values
    public int SaveJewelItems(List<RjJewelitem> jewelitems)
    {
        foreach (var item in jewelitems)
        {
            _context.Add<RjJewelitem>(item);
        }
        _context.SaveChanges();
        return 1;
    }

    // Saving the New bill values
    public int SaveNewBill(RjNewbilldetail newbilldetail)
    {
        _context.Add<RjNewbilldetail>(newbilldetail);
        _context.SaveChanges();
        return 1;
    }

    // Getting the bill number
    public async Task<int> GetBillNumber()
    {
        var billDetails = await _context.RjNewbilldetails.OrderBy(x=> x.BillNumber).LastOrDefaultAsync(x=> x.BillNumber>0);
        if(billDetails == null)
        {
            return 0;
        }
        return billDetails.BillNumber;
    }
}

