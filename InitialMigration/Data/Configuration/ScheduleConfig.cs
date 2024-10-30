﻿using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialMigration.Data.Configuration
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            // first prop
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // second prop
            //builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.Title).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(); // varchar(255)

            // relation Many To Many 


            builder.ToTable("Schedules");

            // Load DAta 

            builder.HasData(LoadSchedules());

        }

        private static List<Schedule> LoadSchedules()
        {
            return new List<Schedule>
            {
           new Schedule { Id = 1, Title = "Daily", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 2, Title = "DayAfterDay", SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 3, Title = "Twice-a-Week", SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, Title = "Weekend", SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
                new Schedule { Id = 5, Title = "Compact", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
            };
        }
    }
}

