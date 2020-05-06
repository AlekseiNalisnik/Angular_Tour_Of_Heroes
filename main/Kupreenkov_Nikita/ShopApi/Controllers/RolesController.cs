using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ShopApi.Models.User;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;
        
        public RolesController(RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        [HttpGet]
        [Route("Roles")]
        public async Task<List<UserRole>> RoleList() => await _roleManager.Roles.ToListAsync();
        
        [HttpGet]
        [Route("Users")]
        public async Task<List<User>> UserList() => await _userManager.Users.ToListAsync();
 
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new UserRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Ok(name);
        }
         
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            UserRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("RoleList");
        }
 
 
        [Route("{userId}")]
        public async Task<IActionResult> Edit(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                // ChangeRoleViewModel model = new ChangeRoleViewModel
                // {
                //     UserId = user.Id,
                //     UserEmail = user.Email,
                //     UserRoles = userRoles,
                //     AllRoles = allRoles
                // };
                return CreatedAtAction("UserList", new { id = user.Id }, user);
            }
 
            return NotFound();
        }
        
        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
 
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
 
                return RedirectToAction("UserList");
            }
 
            return NotFound();
        }
    }
}