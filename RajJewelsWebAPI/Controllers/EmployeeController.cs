using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RajJewels.domain.Entities;
using RajJewels.domain;
using RajJewelsWebAPI.Services;
using RajJewelsWebAPI.ViewModels;
using RajJewelsWebAPI.IServices;

// Raj Jewellers Controller

namespace RajJewelsWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        // Initializers
        private readonly IRajServices rajServices;


        // Constructors
        public EmployeeController(IRajServices _rajServices)
        {
            rajServices = _rajServices;
        }

        /// <summary>
        /// Get User values
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="password">Password</param>
        /// <returns>Http Respoense Result with the values matched</returns>
        [HttpGet]
        [Route("GetUsers/{userID}/{password}")]
        public ActionResult getUsers(string userID, string password)
        {
            UserDetails users = new UserDetails();
            if (!(String.IsNullOrEmpty(userID) && String.IsNullOrEmpty(password)))
            {
                users = rajServices.getUsers(userID, password);
            }
            if(users == null || String.IsNullOrEmpty(users.UserName))
            {
                return BadRequest("Invalid Credentials - Object not found");
            }
            return Ok(users);
        }


        /// <summary>
        /// Saving the User Deatils
        /// </summary>
        /// <param name="user">User details</param>
        /// <returns>Returns http response result with integer</returns>
        [HttpPost]
        [Route("SaveUsers")]
        public ActionResult saveUsers([FromBody]Users user)
        {
            int detail = rajServices.saveUsers(user);
            return Ok(detail);
        }
    }
}

