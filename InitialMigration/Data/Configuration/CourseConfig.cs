using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialMigration.Data.Configuration
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // first prop
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // second prop
            //builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.CourseName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(); // varchar(255)

            // third prop
            builder.Property(x => x.Price).HasPrecision(15, 2);

            builder.ToTable("Courses");

            // Load DAta 

            builder.HasData(LoadCourses());

        }

        private static List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course{Id = 1 ,CourseName = "Mathematics" , Price = 1000m },
                new Course {Id = 2 , CourseName = "Physics" , Price = 2000m},
                new Course{Id = 3 , CourseName = "Chemistry" , Price = 1500m},
                new Course{Id = 4 , CourseName = "Biology" , Price = 1200m},
                new Course{Id = 5 , CourseName = "CS-50" , Price = 3000m}
            };
        }
    }
}
