using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEM4QC_HFT_2021221.Models
{
    [Table("Hr_Employee_Work_Details")]
    public class HrEmployeeWorkDetails
    {
        /// <summary>
        /// Wdid property 
        /// </summary>
        [Key]
        public int Wd_Id { get; set; }
        /// <summary>
        /// Wdmanager property 
        /// </summary>
        public int Wd_Manager { get; set; }
        /// <summary>
        /// Wdlocation property 
        /// </summary>
        public string Wd_Location { get; set; }
        /// <summary>
        /// Wdtitle property 
        /// </summary>
        public string Wd_Title { get; set; }
        /// <summary>
        /// Wdjoin_date property 
        /// </summary>
        public DateTime Wd_Join_Date { get; set; }
        /// <summary>
        /// Wdexperience property 
        /// </summary>
        public int Wd_Experience { get; set; }
        /// <summary>
        /// Wdwork_mail property 
        /// </summary>
        public string Wd_Work_Mail { get; set; }
        /// <summary>
        /// Wdwork_phone property 
        /// </summary>
        public string Wd_Work_Phone { get; set; }
        /// <summary>
        /// Wdsummary_job property 
        /// </summary>
        public string Wd_Summary_Job { get; set; }
        /// <summary>
        /// Wdabout property 
        /// </summary>
        public string Wd_About { get; set; }
        /// <summary>
        /// hr_employee_status_id property 
        /// </summary>
        public int Wd_Employee_Status_Id { get; set; }
        /// <summary>
        /// Wddepartment_member_id property 
        /// </summary>
        public int Wd_Employee_Id { get; set; }
        /// <summary>
        /// Employee exited or not
        /// </summary>
        public bool Wd_Is_Exited { get; set; }
        /// <summary>
        /// WdEmployeeExitDetailId property
        /// </summary>
        public int? Wd_Employee_Exit_Detail_Id { get; set; }

    }
}
