using RajJewels.domain.Entities;

namespace RajJewels.domain.IRepositories
{
    public interface IRepository
	{
        // Getting the user details
        public Task<RjUser> getUsers(string userID, string password);

        // Saving the user details
        public int SaveUsers(RjUser user);

        // Saving the Jewel Values
        public int SaveJewelItems(List<RjJewelitem> jewelitems);

        // Saving the New bill values
        public int SaveNewBill(RjNewbilldetail newbilldetail);

        // Getting the bill number
        public Task<int> GetBillNumber();
    }
}

