using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_m_account")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }
        //[JsonIgnore]
        public virtual Profilling Profilling { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime Expired { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
