using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModalLayer.Models
{
    public class EmployeeModel
    {
        
        public int employeeID { get; set; }
        [Required(ErrorMessage ="{0} input must be given")]
        [RegularExpression(@"[A-Z][a-z]+",ErrorMessage ="Enter valid Name")]
        public string name {  get; set; }
        [Required(ErrorMessage ="{0} input must be given")]
        public string profileimage {  get; set; }
        [Required(ErrorMessage = "{0} input must be given")]    
        public string gender { get; set; }
        [Required(ErrorMessage = "{0} input must be given")]    
        public string department {  get; set; }
        [Required(ErrorMessage = "{0} input must be given")]
        public long salary {  get; set; }
        [Required(ErrorMessage = "{0} input must be given")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "{0} input must be given")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Mininum character 5 and Maximum character 50")]
        public string notes {  get; set; }

    }
}
