using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Helpers;
using System.Web.Security;
using WCCB.Models;
using WebMatrix.WebData;

namespace WCCB.DataLayer
{
    public class WccbContextInitializer : DropCreateDatabaseAlways<WccbContext>
    {
        public WccbContextInitializer()
        {
            //this.Seed(new WccbContext());
        }

        protected override void Seed(WccbContext context)
        {
            //base.Seed(context);
            //context.Users.Add(
            //    new User
            //        {
            //            Id = Guid.NewGuid(),
            //            Username = "Administrator",
            //            Password = Crypto.HashPassword("!3joe37T")
            //        });
            //context.SaveChanges();
        }
    }
}
