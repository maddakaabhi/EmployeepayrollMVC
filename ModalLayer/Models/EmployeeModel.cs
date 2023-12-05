using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModalLayer.Models
{
    public class EmployeeModel
    {
        [Required]
        public int employeeID { get; set; }
        [Required]
        public string name {  get; set; }
        [Required]
        public string profileimage {  get; set; }
        [Required]
        public string gender { get; set; }
        [Required]    
        public string department {  get; set; }
        [Required]
        public long salary {  get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string notes {  get; set; }

    }
}
