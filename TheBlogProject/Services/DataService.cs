using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await _dbContext.Database.MigrateAsync();
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            if(_dbContext.Roles.Any()) {
                return;
            }

            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            if(_dbContext.Users.Any())
            {
                return;
            }

            var adminUser = new BlogUser()
            {
                Email = "wljmanie@gmail.com",
                UserName = "wljmanie@gmail.com",
                FirstName = "Wesley",
                LastName = "Manie",
                PhoneNumber = "0640073722",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(adminUser, "ShouldBeFixed123!");
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());
            
            var modUser = new BlogUser()
            {
                Email = "mod@gmail.com",
                UserName = "mod@gmail.com",
                FirstName = "Mod",
                LastName = "Test",
                PhoneNumber = "0123456789",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "ShouldBeFixed123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

            var proofReaderUser = new BlogUser()
            {
                Email = "proofReader@gmail.com",
                UserName = "proofReader@gmail.com",
                FirstName = "ProofReader",
                LastName = "Test",
                PhoneNumber = "0123456789",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(proofReaderUser, "ShouldBeFixed123!");
            await _userManager.AddToRoleAsync(proofReaderUser, BlogRole.ProofReader.ToString());

            var readerUser = new BlogUser()
            {
                Email = "reader@gmail.com",
                UserName = "reader@gmail.com",
                FirstName = "Reader",
                LastName = "Test",
                PhoneNumber = "0123456789",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(readerUser, "ShouldBeFixed123!");
            await _userManager.AddToRoleAsync(readerUser, BlogRole.Reader.ToString());
        }
    }
}
