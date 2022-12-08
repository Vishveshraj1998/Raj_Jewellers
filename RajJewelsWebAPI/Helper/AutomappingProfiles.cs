using System;
using AutoMapper;
using RajJewels.domain.Entities;
using RajJewelsWebAPI.ViewModels;

namespace RajJewelsWebAPI.Helper
{
	public class AutomappingProfiles:Profile
	{
		public AutomappingProfiles()
		{
			// Mapping the User and Rjuser
			CreateMap<Users, RjUser>().ReverseMap();

			// Mapping the UserDetails and Rjuser
            CreateMap<UserDetails, RjUser>().ReverseMap();
        }
	}
}

