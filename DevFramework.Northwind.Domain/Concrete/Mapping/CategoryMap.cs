using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Domain.Concrete.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryID);

            Property(x => x.CategoryID).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
       
        }
    }
}
