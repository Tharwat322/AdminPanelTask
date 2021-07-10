using AdminPanelTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.ViewModels
{
    public class EmployeeFormViewModel
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<Company> Companies { get; set; }

    }
}
