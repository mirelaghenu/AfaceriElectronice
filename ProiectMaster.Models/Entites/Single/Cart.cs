using ProiectMaster.Models.Entites.Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMaster.Models.Entites.Single
{
    public class Cart : IEntity<int>
    {
        public int Id { get; set; }
        public virtual ICollection<CartsProduct> CartsProducts { get; set; }
    }
}
