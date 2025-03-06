using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Desktop.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityEvent> ActivityEvents { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventsName> EventsNames { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Juri> Juris { get; set; }

    public virtual DbSet<Moder> Moders { get; set; }

    public virtual DbSet<Napravlenie> Napravlenies { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Winner> Winners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=2808");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.IdActivity).HasName("activity_pkey");

            entity.ToTable("activity");

            entity.Property(e => e.IdActivity)
                .ValueGeneratedNever()
                .HasColumnName("id_activity");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.IdModer).HasColumnName("id_moder");
            entity.Property(e => e.Juri1).HasColumnName("juri1");
            entity.Property(e => e.Juri2).HasColumnName("juri2");
            entity.Property(e => e.Juri3).HasColumnName("juri3");
            entity.Property(e => e.Juri4).HasColumnName("juri4");
            entity.Property(e => e.Juri5).HasColumnName("juri5");
            entity.Property(e => e.NameActivity).HasColumnName("name_activity");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.IdModerNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.IdModer)
                .HasConstraintName("activity_id_moder_fkey");

            entity.HasOne(d => d.Juri1Navigation).WithMany(p => p.ActivityJuri1Navigations)
                .HasForeignKey(d => d.Juri1)
                .HasConstraintName("activity_juri1_fkey");

            entity.HasOne(d => d.Juri2Navigation).WithMany(p => p.ActivityJuri2Navigations)
                .HasForeignKey(d => d.Juri2)
                .HasConstraintName("activity_juri2_fkey");

            entity.HasOne(d => d.Juri3Navigation).WithMany(p => p.ActivityJuri3Navigations)
                .HasForeignKey(d => d.Juri3)
                .HasConstraintName("activity_juri3_fkey");

            entity.HasOne(d => d.Juri4Navigation).WithMany(p => p.ActivityJuri4Navigations)
                .HasForeignKey(d => d.Juri4)
                .HasConstraintName("activity_juri4_fkey");

            entity.HasOne(d => d.Juri5Navigation).WithMany(p => p.ActivityJuri5Navigations)
                .HasForeignKey(d => d.Juri5)
                .HasConstraintName("activity_juri5_fkey");
        });

        modelBuilder.Entity<ActivityEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("activity_event");

            entity.Property(e => e.Activity).HasColumnName("activity");
            entity.Property(e => e.EventId).HasColumnName("event_id");

            entity.HasOne(d => d.ActivityNavigation).WithMany()
                .HasForeignKey(d => d.Activity)
                .HasConstraintName("activity_event_activity_fkey");

            entity.HasOne(d => d.Event).WithMany()
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("activity_event_event_id_fkey");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.IdCity)
                .ValueGeneratedNever()
                .HasColumnName("id_city");
            entity.Property(e => e.NameCity).HasColumnName("name_city");
            entity.Property(e => e.PhotoCity).HasColumnName("photo_city");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.IdCountry)
                .ValueGeneratedNever()
                .HasColumnName("id_country");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasColumnName("code");
            entity.Property(e => e.Code2).HasColumnName("code2");
            entity.Property(e => e.NameCountry).HasColumnName("name_country");
            entity.Property(e => e.NameCountryEng).HasColumnName("name_country_eng");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_event");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.City)
                .HasConstraintName("events_city_fkey");
        });

        modelBuilder.Entity<EventsName>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("events_name_pkey");

            entity.ToTable("events_name");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_event");
            entity.Property(e => e.NameEvent).HasColumnName("name_event");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.IdGender)
                .ValueGeneratedNever()
                .HasColumnName("id_gender");
            entity.Property(e => e.NameGender)
                .HasMaxLength(10)
                .HasColumnName("name_gender");
        });

        modelBuilder.Entity<Juri>(entity =>
        {
            entity.HasKey(e => e.IdJuri).HasName("juri_pkey");

            entity.ToTable("juri");

            entity.Property(e => e.IdJuri)
                .ValueGeneratedNever()
                .HasColumnName("id_juri");
            entity.Property(e => e.Dr)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dr");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdNapravleniya).HasColumnName("id_napravleniya");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameFirst).HasColumnName("name_first");
            entity.Property(e => e.NameLast).HasColumnName("name_last");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Juris)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("juri_id_country_fkey");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Juris)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("juri_id_gender_fkey");

            entity.HasOne(d => d.IdNapravleniyaNavigation).WithMany(p => p.Juris)
                .HasForeignKey(d => d.IdNapravleniya)
                .HasConstraintName("juri_id_napravleniya_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Juris)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("juri_id_role_fkey");
        });

        modelBuilder.Entity<Moder>(entity =>
        {
            entity.HasKey(e => e.IdModera).HasName("moders_pkey");

            entity.ToTable("moders");

            entity.Property(e => e.IdModera)
                .ValueGeneratedNever()
                .HasColumnName("id_modera");
            entity.Property(e => e.Dr)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dr");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdNapravleniya).HasColumnName("id_napravleniya");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameFirst).HasColumnName("name_first");
            entity.Property(e => e.NameLast).HasColumnName("name_last");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Moders)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("moders_id_country_fkey");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Moders)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("moders_id_event_fkey");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Moders)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("moders_id_gender_fkey");

            entity.HasOne(d => d.IdNapravleniyaNavigation).WithMany(p => p.Moders)
                .HasForeignKey(d => d.IdNapravleniya)
                .HasConstraintName("moders_id_napravleniya_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Moders)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("moders_id_role_fkey");
        });

        modelBuilder.Entity<Napravlenie>(entity =>
        {
            entity.HasKey(e => e.IdNapravleniya).HasName("napravlenie_pkey");

            entity.ToTable("napravlenie");

            entity.Property(e => e.IdNapravleniya)
                .ValueGeneratedNever()
                .HasColumnName("id_napravleniya");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.IdOrganizer).HasName("organizers_pkey");

            entity.ToTable("organizers");

            entity.Property(e => e.IdOrganizer)
                .ValueGeneratedNever()
                .HasColumnName("id_organizer");
            entity.Property(e => e.Dr)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dr");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameFirst).HasColumnName("name_first");
            entity.Property(e => e.NameLast).HasColumnName("name_last");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("organizers_id_country_fkey");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("organizers_id_gender_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("organizers_id_role_fkey");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.IdParticipants).HasName("participants_pkey");

            entity.ToTable("participants");

            entity.Property(e => e.IdParticipants)
                .ValueGeneratedNever()
                .HasColumnName("id_participants");
            entity.Property(e => e.Dr)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dr");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameFirst).HasColumnName("name_first");
            entity.Property(e => e.NameLast).HasColumnName("name_last");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("participants_id_country_fkey");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("participants_id_gender_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("participants_id_role_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("id_role");
            entity.Property(e => e.NameRole).HasColumnName("name_role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsera).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.IdUsera)
                .ValueGeneratedNever()
                .HasColumnName("id_usera");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameFirst).HasColumnName("name_first");
            entity.Property(e => e.NameLast).HasColumnName("name_last");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("users_id_country_fkey");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("users_id_gender_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        modelBuilder.Entity<Winner>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("winners");

            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdWinner).HasColumnName("id_winner");

            entity.HasOne(d => d.IdEventNavigation).WithMany()
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("winners_id_event_fkey");

            entity.HasOne(d => d.IdWinnerNavigation).WithMany()
                .HasForeignKey(d => d.IdWinner)
                .HasConstraintName("winners_id_winner_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
