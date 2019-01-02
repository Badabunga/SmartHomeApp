using Microsoft.EntityFrameworkCore;
using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Domain.Context
{
    public class MqttTopicContext : DbContext
    {
        public MqttTopicContext()
        {
        }

        public MqttTopicContext(DbContextOptions<SmartHomeContext> options)
            : base(options)
        {

        }


        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<MqttTopics> MqttTopics { get; set; }

        public virtual DbSet<DeviceGroup> DeviceGroups { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<ExternalDeviceInformation> ExternalDeviceInformations { get; set; }


        public virtual DbSet<DeviceDeviceGroup> DeviceDeviceGroups { get; set; }

        public virtual DbSet<DeviceMqttTopics> DeviceMqttTopics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BRUTELSERVER;Database=SmartHome;User Id=bruteldbuser;Password = BrutelPassword!");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastConnectionTime).HasColumnType("datetime");

                entity.Property(e => e.MacAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDevice_DeviceType1");

                entity.HasOne(d => d.Information)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.InformationId)
                    .HasConstraintName("FK_IoTDevice_ExternalDeviceInformation");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDevice_Location");
            });

            modelBuilder.Entity<DeviceDeviceGroup>(entity =>
            {
                entity.ToTable("DeviceDeviceGroup", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.DeviceGroup)
                    .WithMany(p => p.DeviceDeviceGroup)
                    .HasForeignKey(d => d.DeviceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceDeviceGroup_DeviceGroup");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceDeviceGroup)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceDeviceGroup_Device");
            });


            modelBuilder.Entity<DeviceGroup>(entity =>
            {
                entity.ToTable("DeviceGroup", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DeviceGroup)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceGroup_Location");
            });

            modelBuilder.Entity<DeviceMqttTopics>(entity =>
            {
                entity.ToTable("DeviceMqttTopics", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IoTdeviceId).HasColumnName("IoTDeviceId");

                entity.HasOne(d => d.IoTdevice)
                    .WithMany(p => p.DeviceMqttTopics)
                    .HasForeignKey(d => d.IoTdeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDeviceTopics_IoTDevice");

                entity.HasOne(d => d.MqttTopic)
                    .WithMany(p => p.DeviceMqttTopics)
                    .HasForeignKey(d => d.MqttTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDeviceTopics_IoTDeviceMqttTopics");
            });


            modelBuilder.Entity<ExternalDeviceInformation>(entity =>
            {
                entity.ToTable("ExternalDeviceInformation", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SystemInternalId)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MqttTopics>(entity =>
            {
                entity.ToTable("MqttTopics", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(50);
            });

        }
    }
}
