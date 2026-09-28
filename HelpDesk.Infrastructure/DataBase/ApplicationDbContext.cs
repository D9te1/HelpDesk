using HelpDesk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ticketEntity = modelBuilder.Entity<Ticket>()
                .ToTable("tickets");
            ticketEntity.HasKey(x => x.Id);
            ticketEntity.Property(x=> x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            ticketEntity.Property(x=>x.Title)
                .HasColumnName("title")
                .IsRequired();
            ticketEntity.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();
            ticketEntity.Property(x => x.Priority)
                .HasColumnName("priority")
                .IsRequired();
            ticketEntity.Property(x => x.AuthorId)
                .HasColumnName("authorId")
                .IsRequired();
            ticketEntity.Property(x => x.AssignedUserId)
                .HasColumnName("assignedUserId")
                .IsRequired();
            ticketEntity.Property(x => x.CategoryId)
                .HasColumnName("categoryId")
                .IsRequired();
            ticketEntity.Property(x => x.Category)
                .HasColumnName("category")
                .IsRequired();
            ticketEntity.Property(x => x.CreatedAtUtc)
                .HasColumnName("createdAtUtc")
                .IsRequired();
            ticketEntity.Property(x => x.UpdatedAtUtc)
                .HasColumnName("updatedAtUtc")
                .IsRequired();
            ticketEntity.Property(x => x.ClosedAtUtc)
                .HasColumnName("closedAtUtc")
                .IsRequired();
            ticketEntity.Property(x => x.Comments)
                .HasColumnName("comments")
                .IsRequired();
            ticketEntity
                .HasOne(ticket => ticket.Category)
                .WithMany(category => category.Tickets)
                .HasForeignKey(ticket => ticket.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            ticketEntity
                .HasMany(ticket => ticket.Comments)
                .WithOne(comment => comment.Ticket)
                .HasForeignKey(comment => comment.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            var ticketCategoriesEntity = modelBuilder.Entity<TicketCategory>()
                .ToTable("ticketCategories");
            ticketCategoriesEntity.HasKey(x => x.Id);
            ticketCategoriesEntity.Property(x=>x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            ticketCategoriesEntity.Property(x => x.Name)
                .HasColumnName("name")
                .UseIdentityColumn();
            ticketCategoriesEntity.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .UseIdentityColumn();
            ticketCategoriesEntity.Property(x => x.Tickets)
                .HasColumnName("tickets")
                .UseIdentityColumn();

            var ticketCommentsEntity = modelBuilder.Entity<TicketComment>()
                .ToTable("ticketcomments");
            ticketCommentsEntity.HasKey(x => x.Id);
            ticketCommentsEntity.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            ticketCommentsEntity.Property(x=>x.TicketId)
                .HasColumnName("ticketId")
                .UseIdentityColumn();
            ticketCommentsEntity.Property(x => x.Ticket)
                .HasColumnName("ticket")
                .UseIdentityColumn();
            ticketCommentsEntity.Property(x => x.AuthorId)
                .HasColumnName("authorId")
                .UseIdentityColumn();
            ticketCommentsEntity.Property(x => x.Text)
                .HasColumnName("text")
                .UseIdentityColumn();
            ticketCommentsEntity.Property(x => x.CreatedAtUtc)
                .HasColumnName("createdAtUtc")
                .UseIdentityColumn();
        }
    }
}
