using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employee_Status")]
    public class HrEmployeeStatus
    {
        /// <summary>
        /// Empsid property 
        /// </summary>
        [Key]
        public int Emps_Id { get; set; }
        /// <summary>
        /// Empstitle property 
        /// </summary>
        public string Emps_Title { get; set; }
        /// <summary>
        /// Empsdescription property 
        /// </summary>
        public string Emps_Description { get; set; }
    }
}
