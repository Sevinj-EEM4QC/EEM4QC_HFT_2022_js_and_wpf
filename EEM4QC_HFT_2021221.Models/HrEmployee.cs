using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employees")]
    public class HrEmployee
    {
        /// <summary>
        /// Empid property 
        /// </summary>
        [Key]
        public int Emp_Id { get; set; }

        /// <summary>
        /// Employee name
        /// </summary>
        public string Emp_Name { get; set; }

        /// <summary>
        /// Employee Surname
        /// </summary>
        public string Emp_Surname { get; set; }

        /// <summary>
        /// Empis_existed property 
        /// </summary>
        public bool Emp_Is_Existed { get; set; }
        public override string ToString()
        {
            return $"EmployeeId : {this.Emp_Id}\nSurname : {this.Emp_Surname}\nName : {this.Emp_Name}\nExited or not : {this.Emp_Is_Existed}";
        }
    }
}
