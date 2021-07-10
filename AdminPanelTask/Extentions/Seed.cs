using AdminPanelTask.Data;
using AdminPanelTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminPanelTask.Extentions
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (await context.Employees.AnyAsync()) return;

            var companiesData = await System.IO.File.ReadAllTextAsync("Data/dataSeed.json");

           
            var companies = JsonSerializer.Deserialize<List<Company>>(companiesData);

            foreach(var company in companies)
            {
                context.Companies.Add(company);
            }

            await context.SaveChangesAsync();
            
            
        }
    }
}
