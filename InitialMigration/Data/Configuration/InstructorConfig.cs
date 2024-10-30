using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialMigration.Data.Configuration
{
    internal class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Office).WithOne(x => x.Instructor).HasForeignKey<Instructor>(x => x.OfficeId).IsRequired(false);


            builder.ToTable("Instructors");

            builder.HasData(LoadInstructor());
        }

        private static List<Instructor> LoadInstructor()
        {
            return new List<Instructor>
            {
                new Instructor {Id = 1 , FName = "Ahmed" , LName =" Abdullah" , OfficeId = 1 },
                new Instructor {Id = 2 , FName = "Yassmen", LName ="Mohammed" , OfficeId = 2 },
                new Instructor {Id = 3 , FName = "Khelid" , LName = "Hassan", OfficeId = 3},
                new Instructor {Id = 4 , FName = "Nada" , LName = "Ali" , OfficeId = 4},
                new Instructor {Id = 5 , FName = "Omar" , LName = "Ibrahim" , OfficeId = 5},
            };
        }
    }
}
