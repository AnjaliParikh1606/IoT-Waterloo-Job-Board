using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class JobBoardContext : DbContext
    {
        public JobBoardContext()
        {
        }

        public JobBoardContext(DbContextOptions<JobBoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountInformation> AccountInformation { get; set; }
        public virtual DbSet<AgencyDetails> AgencyDetails { get; set; }
        public virtual DbSet<AgentDetails> AgentDetails { get; set; }
        public virtual DbSet<CandidateDetails> CandidateDetails { get; set; }
        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<CompnaySubscription> CompnaySubscription { get; set; }
        public virtual DbSet<EventDetails> EventDetails { get; set; }
        public virtual DbSet<JobDetails> JobDetails { get; set; }
        public virtual DbSet<LinkedInProfiles> LinkedInProfiles { get; set; }
        public virtual DbSet<NewsLetter> NewsLetter { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<RegistrationDetails> RegistrationDetails { get; set; }
        public virtual DbSet<RegistrationEventDetails> RegistrationEventDetails { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<WebsiteSubscriber> WebsiteSubscriber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localDB)\\MsSQLLocalDB;Database=JobBoard;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AccountInformation>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_AcountInformation");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountInformation)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role_AccountInformation");
            });

            modelBuilder.Entity<AgencyDetails>(entity =>
            {
                entity.HasKey(e => e.AgencyId);

                entity.Property(e => e.AgencyId)
                    .HasColumnName("agencyId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgencyEmail)
                    .IsRequired()
                    .HasColumnName("agencyEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.AgencyName)
                    .IsRequired()
                    .HasColumnName("agencyName")
                    .HasMaxLength(50);

                entity.Property(e => e.AgencyPhone).HasColumnName("agencyPhone");

                entity.Property(e => e.AgencyWebsite)
                    .IsRequired()
                    .HasColumnName("agencyWebsite")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AgentDetails>(entity =>
            {
                entity.HasKey(e => e.AgentId);

                entity.Property(e => e.AgentId)
                    .HasColumnName("agentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgencyId).HasColumnName("agencyId");

                entity.Property(e => e.AgenntLastName)
                    .IsRequired()
                    .HasColumnName("agenntLastName")
                    .HasMaxLength(50);

                entity.Property(e => e.AgentExtensionNumber).HasColumnName("agentExtensionNumber");

                entity.Property(e => e.AgentFirstName)
                    .IsRequired()
                    .HasColumnName("agentFirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.AgentPhone).HasColumnName("agentPhone");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.AgentDetails)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AgencyDetails_AgentDetails");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.AgentDetails)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Role_AgentDetails");
            });

            modelBuilder.Entity<CandidateDetails>(entity =>
            {
                entity.HasKey(e => e.CandidateId);

                entity.Property(e => e.CandidateId)
                    .HasColumnName("candidateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CandidateFirstName)
                    .HasColumnName("candidateFirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.CandidateLastName)
                    .HasColumnName("candidateLastName")
                    .HasMaxLength(50);

                entity.Property(e => e.LinkedInId).HasColumnName("linkedInId");

                entity.Property(e => e.ResumeId).HasColumnName("resumeId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.LinkedIn)
                    .WithMany(p => p.CandidateDetails)
                    .HasForeignKey(d => d.LinkedInId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateDetails_LinkedInProfiles");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.CandidateDetails)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateDetails_Resume");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.CandidateDetails)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CandidateDetails_AccountInformation");
            });

            modelBuilder.Entity<CompanyDetails>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__CompanyD__AD5459902AC91DE6");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("companyAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyCity)
                    .HasColumnName("companyCity")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyContactPerson)
                    .HasColumnName("companyContactPerson")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyEmailId)
                    .HasColumnName("companyEmailId")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyLandLineExtensionNumber)
                    .HasColumnName("companyLandLineExtensionNumber")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyLandLinePhoneNumber)
                    .HasColumnName("companyLandLinePhoneNumber")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyPostalCode)
                    .HasColumnName("companyPostalCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyRegistrationDateTime)
                    .HasColumnName("companyRegistrationDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompnayRole");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.UserName)
                    .HasConstraintName("FK_CompnayAccountInformation");
            });

            modelBuilder.Entity<CompnaySubscription>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId);

                entity.Property(e => e.SubscriptionId).HasColumnName("subscriptionId");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.SubscriptionExprityDate)
                    .HasColumnName("subscriptionExprityDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionStartDate)
                    .HasColumnName("subscriptionStartDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.CompnaySubscription)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanySubscription_PaymentDetails");
            });

            modelBuilder.Entity<EventDetails>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("eventDescription")
                    .HasMaxLength(1000);

                entity.Property(e => e.EventEndDateTime)
                    .HasColumnName("eventEndDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasColumnName("eventLocation")
                    .HasMaxLength(50);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("eventName")
                    .HasMaxLength(50);

                entity.Property(e => e.EventSratDateTime)
                    .HasColumnName("eventSratDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("eventType")
                    .HasMaxLength(50);

                entity.Property(e => e.SubscriberEmailId)
                    .HasColumnName("subscriberEmailId")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SubscriberEmail)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.SubscriberEmailId)
                    .HasConstraintName("FK_EventDetails_WensiteSubscriber");
            });

            modelBuilder.Entity<JobDetails>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(50);

                entity.Property(e => e.CompnayId).HasColumnName("compnayId");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasColumnName("jobDescription")
                    .HasMaxLength(500);

                entity.Property(e => e.JobExpiryDate)
                    .HasColumnName("jobExpiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobPostDate)
                    .HasColumnName("jobPostDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("jobTitle")
                    .HasMaxLength(50);

                entity.Property(e => e.Jobtype)
                    .IsRequired()
                    .HasColumnName("jobtype")
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50);

                entity.Property(e => e.MaxSalary)
                    .HasColumnName("max_salary")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinSalary)
                    .HasColumnName("min_salary")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NumberOfPosition).HasColumnName("numberOfPosition");

                entity.Property(e => e.PayPeriod)
                    .HasColumnName("payPeriod")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Compnay)
                    .WithMany(p => p.JobDetails)
                    .HasForeignKey(d => d.CompnayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobDetails_CompnayDetails");
            });

            modelBuilder.Entity<LinkedInProfiles>(entity =>
            {
                entity.HasKey(e => e.LinkedInId);

                entity.Property(e => e.LinkedInId)
                    .HasColumnName("linkedInId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProfilrUrl)
                    .IsRequired()
                    .HasColumnName("ProfilrURL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NewsLetter>(entity =>
            {
                entity.Property(e => e.NewsletterId)
                    .HasColumnName("newsletterId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Discription)
                    .IsRequired()
                    .HasColumnName("discription")
                    .HasMaxLength(50);

                entity.Property(e => e.SubscriptionEmailId)
                    .HasColumnName("subscriptionEmailId")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SubscriptionEmail)
                    .WithMany(p => p.NewsLetter)
                    .HasForeignKey(d => d.SubscriptionEmailId)
                    .HasConstraintName("FK_WebsiteSubscriber_Newsletter");
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.PaymentCardType)
                    .HasColumnName("paymentCardType")
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentDateTime)
                    .HasColumnName("paymentDateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<RegistrationDetails>(entity =>
            {
                entity.HasKey(e => e.RegistrationId);

                entity.Property(e => e.RegistrationId).HasColumnName("registrationID");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasColumnName("contactNumber")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LasttName)
                    .IsRequired()
                    .HasColumnName("lasttName")
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.RegistrationDateTime)
                    .HasColumnName("registrationDateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.RegistrationDetails)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegistration_paymentDetails");
            });

            modelBuilder.Entity<RegistrationEventDetails>(entity =>
            {
                entity.HasKey(e => new { e.RegistrationId, e.EventId })
                    .HasName("PK__Registra__21076FC54E009489");

                entity.Property(e => e.RegistrationId).HasColumnName("registrationID");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RegistrationEventDetails)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationDetailsEventDetails_EventDetails");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity.Property(e => e.ResumeId)
                    .HasColumnName("resumeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FilePath)
                    .HasColumnName("filePath")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.PermissionType)
                    .IsRequired()
                    .HasColumnName("permissionType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WebsiteSubscriber>(entity =>
            {
                entity.HasKey(e => e.SubscriberEmailId);

                entity.Property(e => e.SubscriberEmailId)
                    .HasColumnName("subscriberEmailId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();
            });
        }
    }
}
