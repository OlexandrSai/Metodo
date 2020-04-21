using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetItem> AssetsItems { get; set; }
        public DbSet<AssetErrorCode> AssetErrorCodes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ErrorCode> ErrorCodes { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Manutation> Manutations { get; set; }
        public DbSet<ManutationTypess> ManutationTypes { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<ManutationStage> ManutationStages { get; set; }
        //public DbSet<ManutationStageStatus> ManutationStagesStatuses { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<MeasuringTool> MeasuringTools { get; set; }
        public DbSet<UserManutationStage> UserManutationStages { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<AssetFile> AssetFiles { get; set; }
        public DbSet<ItemFile> ItemFiles { get; set; }
        //public DbSet<ItemSupplier> ItemSuppliers { get; set; }
        public DbSet<TypeOfFault> typeOfFaults { get; set; }

        public DbSet<ConsumableTemp> ConsumableTemps { get; set; }
        public DbSet<ItemTemp> ItemTemps { get; set; }
        public DbSet<ToolTemp> ToolTemps { get; set; }
        public DbSet<MeasuringToolTemp> MeasuringToolTemps { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Asset>()
        .HasMany(p => p.Files)
        .WithOne(t => t.Asset)
        .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Item>()
       .HasMany(p => p.Files)
       .WithOne(t => t.Item)
       .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Supplier>().Property(e => e.Id).ValueGeneratedNever();

            //AssetsItems
            builder.Entity<AssetItem>()
                .HasKey(t => new { t.ItemId, t.AssetId });

            builder.Entity<AssetItem>()
                .HasOne(pt => pt.Item)
                .WithMany(p => p.AssetsItems)
                .HasForeignKey(pt => pt.ItemId);

            builder.Entity<AssetItem>()
                .HasOne(pt => pt.Asset)
                .WithMany(p => p.AssetsItems)
                .HasForeignKey(pt => pt.AssetId);

            //AssetsErrorCodes
            builder.Entity<AssetErrorCode>()
                .HasKey(t => new { t.AssetId, t.ErrorCodeId });

            builder.Entity<AssetErrorCode>()
                .HasOne(pt => pt.ErrorCode)
                .WithMany(p => p.AssetsErrorCodes)
                .HasForeignKey(pt => pt.ErrorCodeId);

            builder.Entity<AssetErrorCode>()
                .HasOne(pt => pt.Asset)
                .WithMany(p => p.AssetsErrorCodes)
                .HasForeignKey(pt => pt.AssetId);

            ////ItemsSuppliers
            //builder.Entity<ItemSupplier>()
            //    .HasKey(t => new { t.ItemId, t.SupplierId });

            //builder.Entity<ItemSupplier>()
            //    .HasOne(pt => pt.Item)
            //    .WithMany(p => p.ItemFornitores)
            //    .HasForeignKey(pt => pt.ItemId);

            //builder.Entity<ItemSupplier>()
            //    .HasOne(pt => pt.Supplier)
            //    .WithMany(p => p.ItemSuppliers)
            //    .HasForeignKey(pt => pt.SupplierId);

            //UserManutationStage
            builder.Entity<UserManutationStage>()
                .HasKey(t => new { t.ApplicationUserId, t.ManutationStageId });

            builder.Entity<UserManutationStage>()
                .HasOne(pt => pt.ApplicationUser)
                .WithMany(p => p.ManutationStages)
                .HasForeignKey(pt => pt.ApplicationUserId);

            builder.Entity<UserManutationStage>()
                .HasOne(pt => pt.ManutationStage)
                .WithMany(p => p.UserManutationStages)
                .HasForeignKey(pt => pt.ManutationStageId);

            ////ManutationStageConsumable

            //builder.Entity<ManutationStageConsumable>()
            //    .HasOne(pt => pt.ManutationStage)
            //    .WithMany(p => p.ManutationStageConsumables)
            //    .HasForeignKey(pt => pt.ConsumableId);

            //builder.Entity<ManutationStageConsumable>()
            //    .HasOne(pt => pt.Consumable)
            //    .WithMany(p => p.ManutationStageConsumables)
            //    .HasForeignKey(pt => pt.ManutationStageId);

            ////ManutationStageItem
           

            //builder.Entity<ManutationStageItem>()
            //    .HasOne(pt => pt.ManutationStage)
            //    .WithMany(p => p.ManutationStageItems)
            //    .HasForeignKey(pt => pt.ItemId);

            //builder.Entity<ManutationStageItem>()
            //    .HasOne(pt => pt.Item)
            //    .WithMany(p => p.ManutationStageItems)
            //    .HasForeignKey(pt => pt.ManutationStageId);

            ////ManutationStageTool
            

            //builder.Entity<ManutationStageTool>()
            //    .HasOne(pt => pt.ManutationStage)
            //    .WithMany(p => p.ManutationStageTools)
            //    .HasForeignKey(pt => pt.ToolId);

            //builder.Entity<ManutationStageTool>()
            //    .HasOne(pt => pt.Tool)
            //    .WithMany(p => p.ManutationStageTools)
            //    .HasForeignKey(pt => pt.ManutationStageId);
        }
    }
}
