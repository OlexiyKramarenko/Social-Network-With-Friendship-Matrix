using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DB")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
    }
   // public class DBInitializer : DropCreateDatabaseAlways<DataBaseContext>
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext> 
    {
        protected override void Seed(DataBaseContext db)
        {
            db.Users.AddRange(new List<User>
            {
                new User { ID = 1, Password = "123", UserName="policeman", Avatar = "/Content/avatars/1_policeman.jpg" },
                new User { ID = 2, Password = "123", UserName="firefighter", Avatar = "/Content/avatars/2_firefighter.jpg" },
                new User { ID = 3, Password = "123", UserName="detective", Avatar = "/Content/avatars/3_detective.jpg" },
                new User { ID = 4, Password = "123", UserName="sheriff", Avatar = "/Content/avatars/4_sheriff.jpg" },
                new User { ID = 5, Password = "123", UserName="judje", Avatar = "/Content/avatars/5_judje.jpg" },
                new User { ID = 6, Password = "123", UserName="tankman", Avatar = "/Content/avatars/6_tankman.jpg" },
                new User { ID = 7, Password = "123", UserName="military", Avatar = "/Content/avatars/7_military.jpg" },
                new User { ID = 8, Password = "123", UserName="doctor", Avatar = "/Content/avatars/8_doctor.jpg" },
                new User { ID = 9, Password = "123", UserName="surgeon", Avatar = "/Content/avatars/9_surgeon.jpg" },
                new User { ID = 10, Password = "123", UserName="assistant", Avatar = "/Content/avatars/10_assistant.jpg" },
                new User { ID = 11, Password = "123", UserName="nurse", Avatar = "/Content/avatars/11_nurse.jpg" },
                new User { ID = 12, Password = "123", UserName="scientist", Avatar = "/Content/avatars/12_scientist.jpg" },
                new User { ID = 13, Password = "123", UserName="astronaut", Avatar = "/Content/avatars/13_astronaut.jpg" },
                new User { ID = 14, Password = "123", UserName="diver", Avatar = "/Content/avatars/14_diver.jpg" },
                new User { ID = 15, Password = "123", UserName="pilot", Avatar = "/Content/avatars/15_pilot.jpg" },
                new User { ID = 16, Password = "123", UserName="captain", Avatar = "/Content/avatars/16_captain.jpg" },
                new User { ID = 17, Password = "123", UserName="stewardess", Avatar = "/Content/avatars/17_stewardess.jpg" },
                new User { ID = 18, Password = "123", UserName="taxidriver", Avatar = "/Content/avatars/18_taxidriver.jpg" },
                new User { ID = 19, Password = "123", UserName="engineer", Avatar = "/Content/avatars/19_engineer.jpg" },
                new User { ID = 20, Password = "123", UserName="builder", Avatar = "/Content/avatars/20_builder.jpg" },
                new User { ID = 21, Password = "123", UserName="me", Avatar = "/Content/avatars/default.jpg" }
            });
            db.Friends.AddRange(new List<Friendship> {
                new Friendship { IdFirst = 1, IdSecond = 2 },
                new Friendship { IdFirst = 1, IdSecond = 3 },
                new Friendship { IdFirst = 1, IdSecond = 4 },
                new Friendship { IdFirst = 1, IdSecond = 5 },
                new Friendship { IdFirst = 1, IdSecond = 6 },

                new Friendship { IdFirst = 3, IdSecond = 2 }, 
                new Friendship { IdFirst = 3, IdSecond = 4 },
                new Friendship { IdFirst = 3, IdSecond = 5 },
                new Friendship { IdFirst = 3, IdSecond = 6 },
                 
                new Friendship { IdFirst = 2, IdSecond = 4 },
                new Friendship { IdFirst = 2, IdSecond = 5 },
                new Friendship { IdFirst = 2, IdSecond = 6 },
                new Friendship { IdFirst = 2, IdSecond = 7 },
                new Friendship { IdFirst = 2, IdSecond = 8 },
                new Friendship { IdFirst = 2, IdSecond = 9 },
                new Friendship { IdFirst = 2, IdSecond = 10 },
                new Friendship { IdFirst = 2, IdSecond = 11 },
                new Friendship { IdFirst = 2, IdSecond = 12 },
                new Friendship { IdFirst = 2, IdSecond = 13 },

                 new Friendship { IdFirst = 21, IdSecond = 2 },
                new Friendship { IdFirst = 21, IdSecond = 3 },
                new Friendship { IdFirst = 21, IdSecond = 4 },
                new Friendship { IdFirst = 21, IdSecond = 5 },
                new Friendship { IdFirst = 21, IdSecond = 6 },
                });
            db.SaveChanges();
        }
    }
}

