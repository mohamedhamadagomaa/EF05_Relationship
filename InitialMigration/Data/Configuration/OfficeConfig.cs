using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialMigration.Data.Configuration
{
    public class OfficeConfig : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            // first prop
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // second prop
            //builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.OfficeName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(); // varchar(255)

            // third prop
            builder.Property(x => x.OfficeLocation).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();

            builder.ToTable("Offices");

            // Load DAta 

            builder.HasData(LoadOffices());

        }

        private static List<Office> LoadOffices()
        {
            return new List<Office>
            {
                new Office{Id = 1 ,OfficeName = "off_05" , OfficeLocation = "Building A" },
                new Office {Id = 2 , OfficeName = "Off_12" , OfficeLocation = "Biulding B"},
                new Office{Id = 3 , OfficeName = "off_32" , OfficeLocation = "Adminstration"},
                new Office{Id = 4 , OfficeName = "off_44" , OfficeLocation = "IT Department"},
                new Office{Id = 5 , OfficeName = "off_43" , OfficeLocation = "IT Department"}
            };
        }
    }
}
