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

        // Saving the user values
        public async Task<int> SaveNewBill(NewBillDetails newBill)
        {
            RjNewbilldetail newbilldetail = new RjNewbilldetail();
            List<RjJewelitem> rjJewelitems = new List<RjJewelitem>();
            List<JewelItem> jewelItems = new List<JewelItem>();
            jewelItems.AddRange(newBill.JewelItems);
            newbilldetail = mapper.Map<NewBillDetails, RjNewbilldetail>(newBill);
            rjJewelitems = mapper.Map<List<JewelItem>, List<RjJewelitem>>(jewelItems);
            var billNumber = await repository.GetBillNumber();
            foreach(var jewelitem in rjJewelitems)
            {
                jewelitem.BillNumber = billNumber + 1;
            }
            newbilldetail.BillNumber = billNumber + 1;
            int detail = repository.SaveJewelItems(rjJewelitems);
            detail = repository.SaveNewBill(newbilldetail);
            return detail;
        }
    }
} 

