using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelTask.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }
        [MaxLength(300)]
        public string  Address { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new Collection<Employee>();
        }
    }
}