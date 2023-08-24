using Microsoft.EntityFrameworkCore;
using MVC_Bartender_Application.Models;

namespace MVC_Bartender_Application.Data
{
    public class ApplicationDbContex : DbContext 
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

    }
}
