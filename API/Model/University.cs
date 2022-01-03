using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_m_university")]
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Education> Educations { get; set; }

    }
}
