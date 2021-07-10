using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Helpers
{
    public class DataTableResponse<T>
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public T [] Data { get; set; }
        
    }
}
