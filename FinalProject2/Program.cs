using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new Context())
            {
                var stud = new Student() { FirstName = "Elena", LastName = "Diaz", Email = "ed2020@email.com" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }

        }
    }
}
