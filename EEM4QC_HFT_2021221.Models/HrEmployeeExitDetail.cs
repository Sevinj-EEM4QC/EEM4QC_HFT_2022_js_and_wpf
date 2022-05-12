using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employee_Exit_Detail")]
    public class HrEmployeeExitDetail
    {
        /// <summary>
        /// Gets or sets eedid property.
        /// </summary>
        [Key]
        public int Eed_Id { get; set; }

        /// <summary>
        /// Gets or sets eeddetails property .
        /// </summary>
        public string Eed_Details { get; set; }

        /// <summary>
        /// Gets or sets eeddate property .
        /// </summary>
        public DateTime Eed_Date { get; set; }

        /// <summary>
        /// Gets or sets eedquestions property .
        /// </summary>
        public string Eed_Questions { get; set; }

        /// <summary>
        /// Gets or sets eedinterviewer property.
        /// </summary>
        public int Eed_Interviewer { get; set; }

        /// <summary>
        /// Gets or sets eedemployeeid property .
        /// </summary>
        public int Eed_Employee_Work_Details_Id { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Details : {this.Eed_Details}\nDate : {this.Eed_Details}\nQuestions : {this.Eed_Questions}";
        }
    }
}
