using AdminPanelTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.ViewModels
{
    public class CompanyFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }

    }
}
