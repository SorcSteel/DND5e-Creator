using DND5e.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace DND5e.PL.Data
{
    public class DND5eEntities : DbContext
    {
        public DbSet<tblAbilityScore> tblAbilityScores { get; set; }
        public DbSet<tblCharacter> tblCharacters { get; set; }
        public DbSet<tblEquipment> tblEquipments { get; set; }
        public DbSet<tblFeat> tblFeats { get; set; }
        public DbSet<tblPersonality> tblPersonalities { get; set; }
        public DbSet<tblSave> tblSaves { get; set; }
        public DbSet<tblSkill> tblSkills { get; set; }
        public DbSet<tblSpell> tblSpells { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DND5eEntities(DbContextOptions<DND5eEntities> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DND5eEntities()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            CreateUsers(modelBuilder);
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id);
                entity.Property(e => e.UserName);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Password);
                entity.Property(e => e.Email);
                entity.Property(e => e.Role);
            });

            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = -1,
                UserName = "testuser1",
                FirstName = "Logan",
                LastName = "Test",
                Password = GetHash("password"),
                Email = "lpvang@gmail.com",
                Role = "Admin"
            });
        }
        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

    }
}
