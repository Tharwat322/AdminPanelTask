using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Helpers
{
    [ModelBinder(BinderType = typeof(DataTableModelBinder))]
    public class DataTableParams
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Search Search { get; set; }
        public List<Column> Columns { get; set; }

    }
}
