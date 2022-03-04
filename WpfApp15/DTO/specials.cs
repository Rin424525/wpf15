using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp15.DTO
{
    [Table("specials")]
    public class Special : BaseDTO
    {
        [Column("title")]
        public string Title { get; set; }
        
        public int GroupId { get; internal set; }
    }
}
