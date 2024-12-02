using FraudPortal.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FraudPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public AccountController(ApplicationDbContext db)
        {
            _Db = db;
        }

        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([Required(ErrorMessage = "نام کاربری الزامیست")][FromForm] string userName, [Required(ErrorMessage = "رمز عبور الزامیست")][FromForm] string Password)
        {
            if (ModelState.IsValid)
            {
                var userIngroup = await _Db.UserInGroups.Where(u => u.UserName == userName).SingleOrDefaultAsync();
                if (userIngroup != null)
                {


                    using (var context = new PrincipalContext(ContextType.Domain))
                    {
                        if (context.ValidateCredentials(userName, Password))
                        {
                            var user = UserPrincipal.FindByIdentity(context, userName);
                            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.Email,user.EmailAddress),
                            new Claim("WorkGroup",userIngroup.WorkGroupName)
                        };
                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                                new AuthenticationProperties { IsPersistent = true });
                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "نام کاربری یا پسورد اشتباه است");
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "این نام کاربری دسترسی ورود به سامانه ندارد ");
                }
            }

            return View();

        }

        public ActionResult AccessDenied()
        {

            return View();
        }


        public async Task<ActionResult> WorkGroup()
        {
            ViewData["main-title"] = "مدیریت گروه های کاری";
            ViewData["section-titile-1"] = "افزودن گروه کاری";
            ViewData["section-titile-2"] = "لیست گروه های کاری";

            var listGroup = await _Db.WorkGroups.ToListAsync();

            return View(listGroup);
        }

        [HttpPost]
        public async Task<ActionResult> workGroup([Required][FromForm] string GroupName, [FromForm] string GroupDescribtion)
        {
            if (ModelState.IsValid)
            {
                var group = new WorkGroup()
                {
                    Name = GroupName,
                    Description = GroupDescribtion
                };

                await _Db.WorkGroups.AddAsync(group);

                await _Db.SaveChangesAsync();


            }

            return RedirectToAction("WorkGroup");
        }

        public async Task<ActionResult> DeletGroup(int Id)
        {

            var userExist = await _Db.UserInGroups.AnyAsync(u => u.WorkGroupId == Id);

            if (userExist)
            {
                TempData["userExist"] = "امکان حذف این گروه کاری به علت کاربر فعال در آن نیست";
                return RedirectToAction("WorkGroup");
            }

            var group = await _Db.WorkGroups.FindAsync(Id);
            if (group != null)
            {
                _Db.WorkGroups.Remove(group);

                await _Db.SaveChangesAsync();
            }


            return RedirectToAction("WorkGroup");
        }


        public async Task<ActionResult> UserGroup()
        {
            ViewData["main-title"] = "مدیریت کاربران";
            ViewData["section-titile-1"] = "افزودن کاربر به گروه کاری";
            ViewData["section-titile-2"] = "لیست کاربران";
            var listUser = await _Db.UserInGroups.ToListAsync();

            var options = new SelectList(_Db.WorkGroups, "Id", "Name");

            ViewData["GroupOptions"] = options;

            return View(listUser);
        }

        [HttpPost]
        public async Task<ActionResult> UserGroup([FromForm] string userName, [FromForm] int groupId)
        {
            ViewData["main-title"] = "مدیریت کاربران";
            ViewData["section-titile-1"] = "افزودن کاربر به گروه کاری";
            ViewData["section-titile-2"] = "لیست کاربران";
            var listUser = await _Db.UserInGroups.ToListAsync();


            var existUser = await _Db.UserInGroups.AnyAsync(user => user.UserName == userName);

            if (existUser)
            {
                ModelState.AddModelError(string.Empty, "این کاربری قبلا ثبت و تخصیص داده شده است");
                return View(listUser);
            }

            var group = await _Db.WorkGroups.FindAsync(groupId);
            if (group != null)
            {
                var user = new UserInGroup()
                {
                    UserName = userName,
                    WorkGroupName = group.Name,
                    WorkGroup = group,
                };
                await _Db.UserInGroups.AddAsync(user);
                _Db.SaveChanges();
            }



            return RedirectToAction("UserGroup");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser([FromForm] string userName, [FromForm] int groupId)
        {
            var group = await _Db.WorkGroups.FindAsync(groupId);
            var user = await _Db.UserInGroups.FindAsync(userName);
            if (user != null && group != null)
            {
                user.WorkGroup = group;
                user.WorkGroupName = group.Name;
                _Db.UserInGroups.Update(user);

                await _Db.SaveChangesAsync();
            }




            return RedirectToAction("UserGroup");
        }


        [HttpPost]
        public async Task<ActionResult> DeleteUser([FromForm] string userName, [FromForm] int groupId)
        {

            var user = await _Db.UserInGroups.FindAsync(userName);

            if (user != null)
            {

                _Db.UserInGroups.Remove(user);

                await _Db.SaveChangesAsync();
            }




            return RedirectToAction("UserGroup");
        }

    }
}
