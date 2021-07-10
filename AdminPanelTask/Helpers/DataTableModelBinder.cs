using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Helpers
{
    public class DataTableModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var request = bindingContext.HttpContext.Request;

            var draw = Convert.ToInt32(request.Query["draw"]);
            var start = Convert.ToInt32(request.Query["start"]);
            var length = Convert.ToInt32(request.Query["length"]);

            // Search
            var search = new Search
            {
                Value = request.Query["search[value]"],
                Regex = Convert.ToBoolean(request.Query["search[regex]"])
            };

            // Columns
            var c = 0;
            var columns = new List<Column>();
            while (!StringValues.IsNullOrEmpty(request.Query["columns[" + c + "][name]"]))
            {
                columns.Add(new Column
                {
                    Data = request.Query["columns[" + c + "][data]"],
                    Name = request.Query["columns[" + c + "][name]"],
                    Searchable = Convert.ToBoolean(request.Query["columns[" + c + "][searchable]"]),
                    Search = new Search
                    {
                        Value = request.Query["columns[" + c + "][search][value]"],
                        Regex = Convert.ToBoolean(request.Query["columns[" + c + "][search][regex]"])
                    }
                });
                c++;
            }

            var result = new DataTableParams
            {
                Draw = draw,
                Start = start,
                Length = length,
                Search = search,
                Columns = columns
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;

        }
    }
}
