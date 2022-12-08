using System;
using RajJewels.domain.Entities;

namespace RajJewels.domain.IRepositories
{
	public interface IRepository
	{
        // Getting the user details
        public Task<RjUser> getUsers(string userID, string password);

        // Saving the user details
        public int SaveUsers(RjUser user);
    }
}

