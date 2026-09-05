using Gmc.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Data
{
    public class ChurchDbContext(DbContextOptions<ChurchDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Visitor> Visitors => Set<Visitor>();
        public DbSet<Ministry> Ministries => Set<Ministry>();
        public DbSet<MinistryMember> MinistryMembers => Set<MinistryMember>();
        public DbSet<SmallGroup> SmallGroups => Set<SmallGroup>();
        public DbSet<SmallGroupMember> SmallGroupMembers => Set<SmallGroupMember>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public DbSet<Sermon> Sermons => Set<Sermon>();
        public DbSet<Podcast> Podcasts => Set<Podcast>();
        public DbSet<ChurchEvent> Events => Set<ChurchEvent>();
        public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();
        public DbSet<SermonNote> SermonNotes => Set<SermonNote>();
        public DbSet<PrayerRequest> PrayerRequests => Set<PrayerRequest>();
        public DbSet<ConnectionSubmission> ConnectionSubmissions => Set<ConnectionSubmission>();
        public DbSet<Child> Children => Set<Child>();
        public DbSet<ChildGuardian> ChildGuardians => Set<ChildGuardian>();
        public DbSet<ChildCheckIn> ChildCheckIns => Set<ChildCheckIn>();
        public DbSet<ServingRole> ServingRoles => Set<ServingRole>();
        public DbSet<ServingSchedule> ServingSchedules => Set<ServingSchedule>();
        public DbSet<ServingRequest> ServingRequests => Set<ServingRequest>();
        public DbSet<Donation> Donations => Set<Donation>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Permission>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<RefreshToken>().HasIndex(x => x.TokenHash).IsUnique();

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId });
            modelBuilder.Entity<MinistryMember>().HasKey(x => new { x.MinistryId, x.MemberId });
            modelBuilder.Entity<SmallGroupMember>().HasKey(x => new { x.SmallGroupId, x.MemberId });
            modelBuilder.Entity<ChildGuardian>().HasKey(x => new { x.ChildId, x.MemberId });

            modelBuilder.Entity<Member>()
                .HasOne(x => x.User)
                .WithOne(x => x.Member)
                .HasForeignKey<Member>(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SmallGroup>()
                .HasOne(x => x.LeaderMember)
                .WithMany()
                .HasForeignKey(x => x.LeaderMemberId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Visitor>()
                .HasOne(x => x.ConvertedMember)
                .WithMany()
                .HasForeignKey(x => x.ConvertedMemberId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Announcement>()
                .HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Donation>().Property(x => x.Amount).HasColumnType("numeric(12,2)");
            modelBuilder.Entity<Donation>().HasIndex(x => x.ProviderReference).IsUnique();
            modelBuilder.Entity<EventRegistration>().ToTable("event_registrations");
            modelBuilder.Entity<ChurchEvent>().ToTable("church_events");
        }
    }
}
