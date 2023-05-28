using Microsoft.AspNetCore.Mvc;
using RajJewelsWebAPI.IServices;
using RajJewelsWebAPI.ViewModels;

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

        /// <summary>
        /// Saving the New bill
        /// </summary>
        /// <param name="newBill">New bill</param>
        /// <returns>Returns http response result with integer</returns>
        [HttpPost]
        [Route("SaveNewBill")]
        public async Task<ActionResult> SaveNewBill([FromBody] NewBillDetails newBill)
        {
            int detail = await rajServices.SaveNewBill(newBill);
            return Ok(detail);
        }
    }
}

