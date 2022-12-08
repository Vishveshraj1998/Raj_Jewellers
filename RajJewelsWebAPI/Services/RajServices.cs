using System;
using RajJewels.domain;
using RajJewels.domain.Entities;
using RajJewelsWebAPI.IServices;
using RajJewelsWebAPI.ViewModels;
using AutoMapper;
using RajJewels.domain.IRepositories;

namespace RajJewelsWebAPI.Services
{
	public class RajServices: IRajServices
    {
        // Initializers
        private readonly IRepository repository;
        private readonly IMapper mapper;

        // Constuctors
        public RajServices(IMapper _mapper)
		{
            mapper = _mapper;
            repository = new Repository(new DBContext());
        }

        // Getting the user values
		public UserDetails getUsers(string userName, string password)
		{
            Task<RjUser> users = repository.getUsers(userName, password);
            UserDetails userDetails = new UserDetails();
            userDetails = mapper.Map<RjUser, UserDetails>(users.Result);
            return userDetails;
        }

        // Saving the user values
		public int saveUsers(Users user)
		{
            RjUser rjUser = new RjUser();
            user.UserName = user.FirstName + " " + user.LastName;
            rjUser = mapper.Map<Users, RjUser>(user);
            int detail = repository.SaveUsers(rjUser);
            return detail;
        }
	}
} 

