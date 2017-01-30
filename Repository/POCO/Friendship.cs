using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.POCO
{
    public  class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int IdFirst { get; set; }
        public int IdSecond { get; set; }
    }
    
}
