using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("journal")]
    public class journal : BaseDTO
    {
        [Column("discipline_id")]
        public int discipline_id { get; set; }
        [Column("student_id")]
        public int student_id { get; set; }
        [Column("day")]
        public DateTime day { get; set; }
        [Column("value")]
        public int value { get; set; }
    }
}
