using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employee_Salary_Record")]
    public class HrEmployeeSalaryRecord
    {
        /// <summary>
        /// Gets or sets esrid property.
        /// </summary>
        [Key]
        public int Esr_Id { get; set; }

        /// <summary>
        /// Gets or sets esrcurrency property .
        /// </summary>
        public double Esr_Currency { get; set; }

        /// <summary>
        /// Gets or sets esrdate property .
        /// </summary>
        public DateTime Esr_Date { get; set; }

        /// <summary>
        /// Gets or sets esrhours property .
        /// </summary>
        public byte Esr_Hours { get; set; }

        /// <summary>
        /// Gets or sets esrovertime property.
        /// </summary>
        public int Esr_Over_Time { get; set; }

        /// <summary>
        /// Gets or sets esramount property .
        /// </summary>
        public double Esr_Amount { get; set; }

        /// <summary>
        /// Gets or sets esrtype property.
        /// </summary>
        public byte Esr_Type { get; set; }

        /// <summary>
        /// Gets or sets esrfrequency property .
        /// </summary>
        public byte Esr_Frequency { get; set; }

        /// <summary>
        /// Gets or sets esremployeeid property .
        /// </summary>
        public int Esr_Employee_Id { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Hour : {this.Esr_Hours}\nDate : {this.Esr_Date}\nAmount : {this.Esr_Amount}";
        }
    }
}
