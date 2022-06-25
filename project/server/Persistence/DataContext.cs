using Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Persistence
{

    public class DataContext: DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(b => b.Logs)
                .WithOne();
            modelBuilder.Entity<Project>()
                .HasOne(b => b.Company)
                .WithMany(b => b.Projects)
                .HasForeignKey(p => p.CompanyId);
            base.OnModelCreating(modelBuilder);
            seed(modelBuilder);
        }

        public void seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company()
                { 
                    Id = Guid.Parse("01e3903b-fabf-43bf-ad1f-550eee74f6bc"),
                    Name = "Tesco",
                },
                new Company()
                { 
                    Id = Guid.Parse("6dd0b608-04a8-42e1-bcaf-971367bd8302"),
                    Name = "ING",
                },
                new Company()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1ae2"),
                    Name = "Porche",
                },
                new Company()
                { 
                    Id = Guid.Parse("c6aee1bb-a570-49f4-b3b8-6448e336c42b"),
                    Name = "BMW",
                },
                new Company()
                { 
                    Id = Guid.Parse("be8a467f-0f93-4993-b516-5ba58e88abf0"),
                    Name = "Nike",
                },
                new Company()
                { 
                    Id = Guid.Parse("daa4e8ca-929f-43f1-816d-c580f11ff905"),
                    Name = "Addidas",
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project()
                { 
                    Id = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    Name = "External portal",
                    Deadline = DateTime.Parse("2022-07-22T09:00:00.898Z"),
                    CompanyId = Guid.Parse("01e3903b-fabf-43bf-ad1f-550eee74f6bc"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    Name = "Main project",
                    Deadline = DateTime.Parse("2022-07-12T15:00:00.898Z"),
                    CompanyId = Guid.Parse("01e3903b-fabf-43bf-ad1f-550eee74f6bc"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775"),
                    Name = "Proctocol Update",
                    Deadline = DateTime.Parse("2022-08-10T12:00:00.898Z"),
                    CompanyId = Guid.Parse("6dd0b608-04a8-42e1-bcaf-971367bd8302"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("2593faee-7b0d-4a56-81d8-9466c82a2ac4"),
                    Name = "Car Preview",
                    Deadline = DateTime.Parse("2022-07-01T16:00:00.898Z"),
                    CompanyId = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1ae2"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    Name = "SSO Auth",
                    Deadline = DateTime.Parse("2022-06-28T16:00:00.898Z"),
                    CompanyId = Guid.Parse("c6aee1bb-a570-49f4-b3b8-6448e336c42b"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    Name = "Project Update",
                    Deadline = DateTime.Parse("2022-07-05T18:00:00.898Z"),
                    CompanyId = Guid.Parse("c6aee1bb-a570-49f4-b3b8-6448e336c42b"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("b23817f7-1eae-4de4-bd4a-a1d8544604ee"),
                    Name = "Admin Panel",
                    Deadline = DateTime.Parse("2022-07-09T11:00:00.898Z"),
                    CompanyId = Guid.Parse("c6aee1bb-a570-49f4-b3b8-6448e336c42b"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("7f650e8b-f17c-48e5-a343-e7658d9feb39"),
                    Name = "Shoe Designer Tool",
                    Deadline = DateTime.Parse("2022-08-01T07:00:00.898Z"),
                    CompanyId = Guid.Parse("be8a467f-0f93-4993-b516-5ba58e88abf0"),
                    Completed = false
                },
                new Project()
                { 
                    Id = Guid.Parse("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1"),
                    Name = "Site update",
                    Deadline = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                    CompanyId = Guid.Parse("daa4e8ca-929f-43f1-816d-c580f11ff905"),
                    Completed = true
                }
            );

            modelBuilder.Entity<TimeLog>().HasData(
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a00"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 30,
                    CreatedAt = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a01"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-15T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a02"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 90,
                    CreatedAt = DateTime.Parse("2022-07-16T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a03"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-17T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a04"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 100,
                    CreatedAt = DateTime.Parse("2022-07-18T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a05"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 20,
                    CreatedAt = DateTime.Parse("2022-07-19T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a06"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 50,
                    CreatedAt = DateTime.Parse("2022-07-20T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a07"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-22T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a08"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 40,
                    CreatedAt = DateTime.Parse("2022-07-23T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a10"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-14T11:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a11"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-15T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a12"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 90,
                    CreatedAt = DateTime.Parse("2022-07-16T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a13"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-17T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a14"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 130,
                    CreatedAt = DateTime.Parse("2022-07-18T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a15"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 200,
                    CreatedAt = DateTime.Parse("2022-07-19T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a16"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 160,
                    CreatedAt = DateTime.Parse("2022-07-20T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a17"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 210,
                    CreatedAt = DateTime.Parse("2022-07-22T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a18"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 240,
                    CreatedAt = DateTime.Parse("2022-07-23T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a19"),
                    ProjectId = Guid.Parse("c76cab95-4a52-4344-a803-ab78e06c59fd"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-24T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a20"),
                    ProjectId = Guid.Parse("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a21"),
                    ProjectId = Guid.Parse("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-15T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a22"),
                    ProjectId = Guid.Parse("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775"),
                    LoggedMinutes = 90,
                    CreatedAt = DateTime.Parse("2022-07-16T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a30"),
                    ProjectId = Guid.Parse("2593faee-7b0d-4a56-81d8-9466c82a2ac4"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a31"),
                    ProjectId = Guid.Parse("2593faee-7b0d-4a56-81d8-9466c82a2ac4"),
                    LoggedMinutes = 60,
                    CreatedAt = DateTime.Parse("2022-07-15T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a40"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 20,
                    CreatedAt = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a41"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 35,
                    CreatedAt = DateTime.Parse("2022-07-13T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a42"),
                    ProjectId = Guid.Parse("1c070edb-5e19-43f7-9727-cbc585524ebb"),
                    LoggedMinutes = 150,
                    CreatedAt = DateTime.Parse("2022-07-14T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a43"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 135,
                    CreatedAt = DateTime.Parse("2022-07-18T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a44"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 170,
                    CreatedAt = DateTime.Parse("2022-07-20T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a45"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-21T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a46"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 90,
                    CreatedAt = DateTime.Parse("2022-07-22T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a47"),
                    ProjectId = Guid.Parse("59dedd79-bce9-4c6e-8004-e91196dc7d3b"),
                    LoggedMinutes = 100,
                    CreatedAt = DateTime.Parse("2022-07-24T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a50"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 35,
                    CreatedAt = DateTime.Parse("2022-07-01T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a51"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 55,
                    CreatedAt = DateTime.Parse("2022-07-02T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a52"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 115,
                    CreatedAt = DateTime.Parse("2022-07-03T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a53"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 45,
                    CreatedAt = DateTime.Parse("2022-07-05T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a54"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 40,
                    CreatedAt = DateTime.Parse("2022-07-08T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a55"),
                    ProjectId = Guid.Parse("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"),
                    LoggedMinutes = 50,
                    CreatedAt = DateTime.Parse("2022-07-09T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a60"),
                    ProjectId = Guid.Parse("b23817f7-1eae-4de4-bd4a-a1d8544604ee"),
                    LoggedMinutes = 480,
                    CreatedAt = DateTime.Parse("2022-06-01T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a61"),
                    ProjectId = Guid.Parse("b23817f7-1eae-4de4-bd4a-a1d8544604ee"),
                    LoggedMinutes = 300,
                    CreatedAt = DateTime.Parse("2022-06-08T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a62"),
                    ProjectId = Guid.Parse("b23817f7-1eae-4de4-bd4a-a1d8544604ee"),
                    LoggedMinutes = 360,
                    CreatedAt = DateTime.Parse("2022-06-13T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a63"),
                    ProjectId = Guid.Parse("b23817f7-1eae-4de4-bd4a-a1d8544604ee"),
                    LoggedMinutes = 300,
                    CreatedAt = DateTime.Parse("2022-06-15T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a70"),
                    ProjectId = Guid.Parse("7f650e8b-f17c-48e5-a343-e7658d9feb39"),
                    LoggedMinutes = 120,
                    CreatedAt = DateTime.Parse("2022-07-01T10:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a80"),
                    ProjectId = Guid.Parse("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1"),
                    LoggedMinutes = 180,
                    CreatedAt = DateTime.Parse("2022-07-02T15:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a81"),
                    ProjectId = Guid.Parse("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1"),
                    LoggedMinutes = 240,
                    CreatedAt = DateTime.Parse("2022-07-04T15:00:00.898Z"),
                },
                new TimeLog()
                { 
                    Id = Guid.Parse("01cfd494-fca0-4a3f-9a2d-1763d62f1a82"),
                    ProjectId = Guid.Parse("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1"),
                    LoggedMinutes = 210,
                    CreatedAt = DateTime.Parse("2022-07-05T15:00:00.898Z"),
                }
            );
        }
    }

}
