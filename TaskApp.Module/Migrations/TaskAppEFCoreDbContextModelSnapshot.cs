using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskApp.Module.BusinessObjects;

#nullable disable

namespace TaskApp.Module.Migrations
{
    [DbContext(typeof(TaskAppEFCoreDbContext))]
    partial class TaskAppEFCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.ModelDifference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ModelDifference", (string)null);
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.ModelDifferenceAspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AffectedProperties")
                        .HasColumnType("int");

                    b.Property<int>("ModelDifferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("XmlDefinition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelDifferenceId");

                    b.ToTable("ModelDifferenceAspect", (string)null);
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdministrative")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("PermissionPolicyRole", (string)null);
                });

            modelBuilder.Entity("TaskApp.Module.BusinessObjects.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("PermissionPolicyUser", (string)null);
                });

            modelBuilder.Entity("TaskApp.Module.BusinessObjects.ApplicationUserLoginInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LoginProviderName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderUserKey")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<Guid>("UserForeignKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LoginProviderName", "ProviderUserKey")
                        .IsUnique()
                        .HasFilter("[LoginProviderName] IS NOT NULL AND [ProviderUserKey] IS NOT NULL");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("PermissionPolicyUserLoginInfo", (string)null);
                });

            modelBuilder.Entity("TaskApp.Module.BusinessObjects.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreadaEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Tarea", (string)null);
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.ModelDifferenceAspect", b =>
                {
                    b.HasOne("DevExpress.Persistent.BaseImpl.EF.ModelDifference", "Owner")
                        .WithMany("Aspects")
                        .HasForeignKey("ModelDifferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TaskApp.Module.BusinessObjects.ApplicationUserLoginInfo", b =>
                {
                    b.HasOne("TaskApp.Module.BusinessObjects.ApplicationUser", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.ModelDifference", b =>
                {
                    b.Navigation("Aspects");
                });

            modelBuilder.Entity("TaskApp.Module.BusinessObjects.ApplicationUser", b =>
                {
                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
