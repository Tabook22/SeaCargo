using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaCargo.Models.DB
{
    public class Social
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public Nullable<int> Order { get; set; }
        public string img { get; set; }
    }
}
