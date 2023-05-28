using RajJewelsWebAPI.ViewModels;

namespace RajJewelsWebAPI.IServices
{
    public interface IRajServices
	{
        // Getting the Uservalues
        public UserDetails getUsers(string userName, string password);

        // Saving the User values
        public int saveUsers(Users user);

        // Saving the user values
        public Task<int> SaveNewBill(NewBillDetails newBill);
    }
}

