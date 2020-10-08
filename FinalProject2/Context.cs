using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    public class Context : DbContext
    {
        public Context(): base()
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
