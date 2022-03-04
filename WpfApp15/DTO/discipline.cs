using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("discipline")]
    public class discipline : BaseDTO
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("prepod_id")]
        public string PrepodID { get; set; }


    }
}