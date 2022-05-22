using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employee_Credentials")]
    public class HrEmployeeCredentials
    {
        /// <summary>
        /// Empcid property 
        /// </summary>
        [Key]
        public int Empc_Id { get; set; }
        /// <summary>
        /// Empcemail property 
        /// </summary>
        public string Empc_Mail { get; set; }
        /// <summary>
        /// Empcpassword property 
        /// </summary>
        public string Empc_Password { get; set; }
        /// <summary>
        /// Empcemployee_id property 
        /// </summary>
        public int Empc_Employee_Id { get; set; }
        public HrEmployee Empc_Employee { get; set; }
    }
}
