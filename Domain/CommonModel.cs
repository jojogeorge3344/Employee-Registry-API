using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CommonModel
    {
        public int Id { get; set; }
        [NotMapped]
        public DateTime ModifiedDate { get; set; }
        [NotMapped]
        public bool IsArchived { get; set; }
    }
}
