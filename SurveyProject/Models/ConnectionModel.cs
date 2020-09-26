using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyProject.Models
{
    public class ConnectionModel : DbContext
    {
        public ConnectionModel(DbContextOptions<ConnectionModel> options):base(options)
        {

        }
        public DbSet<DataModel> DataModel { get; set; }
    }
}
