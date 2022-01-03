using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_tr_accountrole")]
    public class AccountRole
    {
        [Key]
        public int AccountRoleId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        public string AccountId { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
