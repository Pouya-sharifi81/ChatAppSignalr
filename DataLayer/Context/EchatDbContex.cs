using DataLayer.Entities.Chats;
using DataLayer.Entities.Role;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class EchatDbContex : DbContext
    {
        public EchatDbContex(DbContextOptions<EchatDbContex> options):base(options) { }

        public DbSet<Chat> chats { get; set; }
        public DbSet<ChatGroup> chatGroups{ get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RolePermission> rolePermissions{ get; set; }
        public DbSet<UserEntity> userEntities{ get; set; }
        public DbSet<UserRole> userRoles{ get; set; }
        public DbSet<UserGroup> userGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(t => t.IsOwnership && t.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var entityType in cascades)
            {
                entityType.DeleteBehavior = DeleteBehavior.Restrict;
            }
           */
           modelBuilder.Entity<Chat>()
                .HasOne(t=>t.user)
                .WithMany(t=> t.chats)
                .HasForeignKey(t=>t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserGroup>()
                .HasOne(b => b.user)
                .WithMany(b => b.userGroups)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

           


     

            base.OnModelCreating(modelBuilder);
        }



    }
}
