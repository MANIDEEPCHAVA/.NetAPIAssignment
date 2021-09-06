using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.Property(s => s.Name);
            builder.Property(s => s.Age);
            builder.Property(s => s.Salary);
        }
    }
}
