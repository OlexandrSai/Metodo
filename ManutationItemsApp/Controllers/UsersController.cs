using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ManutationItemsApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
        }
             
        // GET: Users
        public async Task<ActionResult> Index()
        {
            var users = await _context.ApplicationUsers.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();
            foreach (var user in users)
            {
                var roleNames = await _userManager.GetRolesAsync(_mapper.Map<UserDTO, ApplicationUser>(user));
                user.RoleName = roleNames.FirstOrDefault();

            }
            return PartialView(users);
        }

        public IActionResult AssetSyncF()
        {
            //return View(_userManager..GetAll();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return PartialView();
            }
        }


        
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var userIdentity = await _userManager.FindByIdAsync(id);
            var userRole = await _userManager.GetRolesAsync(userIdentity);
           
            var user = await _context.ApplicationUsers.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u=>u.Id==id);
             
            if (user==null)
            {
                return NotFound();
            }

            
            var roles = _roleManager.Roles.ToList();
            var rolesList = new List<string>();
            foreach (var role in roles)
            {
                rolesList.Add(role.Name);
            };
            if (userRole.Count!=0)
            {
                ViewBag.userRoles = new SelectList(rolesList, userRole.First());
            }
            else
            {
                ViewBag.userRoles = new SelectList(rolesList);
            }
            return PartialView(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDTO user)
        {
            var u = await _userManager.FindByIdAsync(user.Id);
            var userRole = await _userManager.GetRolesAsync(u);
            if (u == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (userRole.First() != "Admin"&& userRole.First()!=user.RoleName)
                    {
                        await ChangeUserRole(u, userRole.First(), user.RoleName); 
                    }
                    var updatedValue = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == user.Id);
                    updatedValue.Company = user.Company;
                    updatedValue.Email = user.Email;
                    updatedValue.Name = user.Name;
                    updatedValue.Phone = user.Phone;
                    updatedValue.Surname = user.Surname;
                    _context.Entry(updatedValue).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(user);
        }

        private async System.Threading.Tasks.Task ChangeUserRole(ApplicationUser user,string OldRole,string NewRole)
        {
            if (OldRole!=null)
            {
              await _userManager.RemoveFromRoleAsync(user, OldRole);
            }
            await _userManager.AddToRoleAsync(user, NewRole);
        }

        // GET: Users/Delete/5
       
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(); 
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool UserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}