using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartHome.Domain.Models;

namespace SmartHome.Domain.Context
{
    public partial class SmartHomeContext : DbContext
    {
        public SmartHomeContext()
        {
        }

        public SmartHomeContext(DbContextOptions<SmartHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceDeviceGroup> DeviceDeviceGroup { get; set; }
        public virtual DbSet<DeviceDevicePins> DeviceDevicePins { get; set; }
        public virtual DbSet<DeviceGroup> DeviceGroup { get; set; }
        public virtual DbSet<DeviceMqttTopics> DeviceMqttTopics { get; set; }
        public virtual DbSet<DevicePins> DevicePins { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<ExternalDeviceInformation> ExternalDeviceInformation { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MqttTopics> MqttTopics { get; set; }
        public virtual DbSet<Protocols> Protocols { get; set; }

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

            modelBuilder.Entity<DeviceDevicePins>(entity =>
            {
                entity.ToTable("DeviceDevicePins", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IoTdeviceId).HasColumnName("IoTDeviceId");

                entity.Property(e => e.IoTdevicePinsId).HasColumnName("IoTDevicePinsId");

                entity.HasOne(d => d.IoTdevice)
                    .WithMany(p => p.DeviceDevicePins)
                    .HasForeignKey(d => d.IoTdeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDeviceDevicePins_IoTDevice");

                entity.HasOne(d => d.IoTdevicePins)
                    .WithMany(p => p.DeviceDevicePins)
                    .HasForeignKey(d => d.IoTdevicePinsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IoTDeviceDevicePins_IoTDevicePins");
            });

            modelBuilder.Entity<DeviceGroup>(entity =>
            {
                entity.ToTable("DeviceGroup", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SystemInteralId)
                    .IsRequired()
                    .HasMaxLength(25);

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

            modelBuilder.Entity<DevicePins>(entity =>
            {
                entity.ToTable("DevicePins", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Iostate).HasColumnName("IOState");

                entity.Property(e => e.PinNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("DeviceType", "IoT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<Protocols>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
