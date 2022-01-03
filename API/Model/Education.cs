using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_m_education")]
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string Degree { get; set; }
        public float GPA { get; set; }
        [JsonIgnore]
        public virtual University University { get; set; }
        public int UniversityId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profilling> Profillings { get; set; }

    }
}
