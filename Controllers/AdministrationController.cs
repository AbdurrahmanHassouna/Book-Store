using AprilBookStore.Models;
using AprilBookStore.Security;
using AprilBookStore.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace AprilBookStore.Controllers;

[Authorize(Roles = "SuperAdmin,Admin")]
public class AdministrationController : Controller
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly ILogger<AdministrationController> logger;
    private readonly IDataProtector dataProtector;
    public AdministrationController(RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager, ILogger<AdministrationController> logger,
        IDataProtectionProvider dataProtectionProvider)
    {
        this.roleManager=roleManager;
        this.userManager=userManager;
        this.logger=logger;
        dataProtector = dataProtectionProvider.CreateProtector(DataProtectionPurposeStrings.IdRouteValue);
    }
    public IActionResult CreateRole()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var identity = new IdentityRole(model.RoleName);
            var result = await roleManager.CreateAsync(identity);
            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
    public IActionResult ListRoles()
    {
        var roles = roleManager.Roles;
        return View(roles);
    }

    public async Task<IActionResult> EditRole(string id)
    {
        try
        {
            var role = roleManager.FindByIdAsync(id).Result;

            if (role == null)
            {
                ViewBag.ErrorMessage = $"no role with this id = {id}";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, model.RoleName))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            ViewBag.ErrorMessage = "An error occurred. Please contact support.";
            return View("Error");
        }

    }
    [HttpPost]

    public async Task<IActionResult> EditRole(EditRoleViewModel model)
    {
        // ... your existing code ...

        var role = await roleManager.FindByIdAsync(model.Id);

        if (role == null)
        {
            ViewBag.ErrorMessage = $"no role with this id = {model.Id}";
            return View("NotFound");
        }
        else
        {
            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
    [HttpPost]
    [Authorize(Policy = "DeleteRolePolicy")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        var role = await roleManager.FindByIdAsync(id);
        try
        {
            if (role == null)
            {
                ViewBag.ErrorMessage = $"no roole with this id = {id}";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ListRoles");
            }
        }
        catch (DbUpdateException ex)
        {
            //Log the exception to a file. We discussed logging to a file
            // using Nlog in Part 63 of ASP.NET Core tutorial
            logger.LogError($"Exception Occured : {ex}");
            // Pass the ErrorTitle and ErrorMessage that you want to show to
            // the user using ViewBag. The Error view retrieves this data
            // from the ViewBag and displays to the user.
            ViewBag.ErrorTitle = $"{role.Name} role is in use";
            ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role. If you want to delete this role, please remove the users from the role and then try to delete";
            ViewBag.RoleId=$"{id}";
            return View("Error");
        }
    }
    public async Task<IActionResult> EditUsersInRole(string id)
    {
        try
        {
            ViewBag.roleId = id;
            // ... your existing code ...

            var role = roleManager.FindByIdAsync(id).Result;

            if (role == null)
            {
                ViewBag.ErrorMessage = $"no role with this id = {id}";
            }
            var model = new List<UserRoleViewModel>();
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                var item = new UserRoleViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id,
                    IsSelected = await userManager.IsInRoleAsync(user, role.Name)
                };
                model.Add(item);
            }
            return View(model);
        }
        catch (Exception ex)
        {
            // Log the exception:
            Console.WriteLine(ex.ToString());

            // Consider returning a more informative error view
            ViewBag.ErrorMessage = "An error occurred. Please contact support.";
            return View("Error");
        }

    }

    [HttpPost]
    public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> models, string id)
    {
        var role = roleManager.FindByIdAsync(id).Result;

        if (role == null)
        {
            ViewBag.ErrorMessage = $"no role with this id = {id}";
            return View("NotFound");
        }
        for (int i = 0; i<models.Count; i++)
        {
            IdentityResult result = null;
            var user = await userManager.FindByIdAsync(models[i].UserId);
            if (models[i].IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
            {
                result = await userManager.AddToRoleAsync(user, role.Name);
            }
            else if (!models[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
            {
                result = await userManager.RemoveFromRoleAsync(user, role.Name);
            }
            else
            {
                continue;
            }
            if (result.Succeeded)
            {
                if (i<models.Count-1)
                    continue;
                else
                    return RedirectToAction("EditRole", new { id = id });
            }

        }
        return RedirectToAction("EditRole", new { id = id });
    }
    public IActionResult ListUsers()
    {
        var users = userManager.Users.ToList();
        return View(users);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            ViewBag.ErrorMessage = $"no user with this id = {id}";
            return View("NotFound");
        }
        else
        {
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers");

            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View("ListUsers");
        }
    }
    public async Task<IActionResult> EditUser(string id)
    {

        var user = userManager.FindByIdAsync(id).Result;

        if (user == null)
        {
            ViewBag.ErrorMessage = $"no User with this id = {id}";
            return View("NotFound");
        }
        var roles = await userManager.GetRolesAsync(user);
        var claims = await userManager.GetClaimsAsync(user);
        var model = new EditUserViewModel
        {

            UserName = user.UserName,
            Email = user.Email,
            Id = user.Id,
            Roles = roles,
            Claims =claims.Select(x => x.Type+" :  " + x.Value).ToList()
        };
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> EditUser(EditUserViewModel model)
    {
        var user = await userManager.FindByIdAsync(model.Id);
        if (user == null)
        {
            ViewBag.ErrorMessage = $"no user with this id {model.Id}";
            return View("NotFound");
        }
        else
        {
            user.Email= model.Email;

            user.UserName= model.UserName;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

    }
    [Authorize(Policy = "EditRolePolicy")]
    public async Task<IActionResult> EditUserRoles(string id)
    {
        try
        {
            ViewBag.userId = id;


            var user = userManager.FindByIdAsync(id).Result;

            if (user == null)
            {
                ViewBag.ErrorMessage = $"no user with this id = {id}";
            }
            var model = new List<UserRolesViewModel>();
            var roles = roleManager.Roles.ToList();
            foreach (var role in roles)
            {
                var item = new UserRolesViewModel
                {
                    RoleName = role.Name,
                    RoleId = role.Id,
                    IsSelected = await userManager.IsInRoleAsync(user, role.Name)
                };
                model.Add(item);
            }
            return View(model);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            ViewBag.ErrorMessage = "An error occurred. Please contact support.";
            return View("Error");
        }

    }

    [HttpPost]
    [Authorize(Policy = "EditRolePolicy")]
    public async Task<IActionResult> EditUserRoles(List<UserRolesViewModel> models, string id)
    {
        var user = userManager.FindByIdAsync(id).Result;

        if (user == null)
        {
            ViewBag.ErrorMessage = $"no user with this id = {id}";
            return View("NotFound");
        }
        for (int i = 0; i<models.Count; i++)
        {
            IdentityResult result;
            var role = await roleManager.FindByIdAsync(models[i].RoleId);
            if (models[i].IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
            {
                result = await userManager.AddToRoleAsync(user, role.Name);
            }
            else if (!models[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
            {
                result = await userManager.RemoveFromRoleAsync(user, role.Name);
            }
            else
            {
                continue;
            }
            if (result.Succeeded)
            {
                if (i<models.Count-1)
                    continue;
                else
                    return RedirectToAction("EditUser", new { id });
            }

        }
        return RedirectToAction("EditUser", new { id });
    }
    [HttpGet]
    public async Task<IActionResult> EditUserClaims(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            ViewBag.ErrorMessage = $"no user with this id = {id}";
        }
        var existingUserClaims = await userManager.GetClaimsAsync(user);
        var model = new UserClaimsViewModel
        {
            UserId = user.Id
        };

        foreach (Claim claim in ClaimsStore.AllClaims)
        {
            UserClaim userClaim = new UserClaim
            {
                ClaimType = claim.Type
            };
            if (existingUserClaims.Any(c => c.Type == claim.Type &&  c.Value=="true"))
            {
                userClaim.IsSelected=true;
            }
            model.Claims.Add(userClaim);
        }
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> EditUserClaims(UserClaimsViewModel model, string id)
    {
        var user = userManager.FindByIdAsync(id).Result;

        if (user == null)
        {
            ViewBag.ErrorMessage = $"no user with this id = {id}";
            return View("NotFound");
        }
        var calims = await userManager.GetClaimsAsync(user);
        var result = await userManager.RemoveClaimsAsync(user, calims);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Can't remove Claims");
            return View(model);
        }
        result = await userManager.AddClaimsAsync(user,
            model.Claims.Select(c => new Claim(c.ClaimType, c.IsSelected ? "true" : "false")));
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Can't add Claims");
            return View(model);
        }
        return RedirectToAction("EditUser", new { id });
    }
}