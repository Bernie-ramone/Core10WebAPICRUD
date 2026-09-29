using Core10WebAPICRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core10WebAPICRUD.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Genre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.ReleaseDate)
               .IsRequired();

        builder.Property(m => m.Rating)
               .IsRequired();

        builder.Property(m => m.Created)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(m => m.LastModified)
            .IsRequired()
            .ValueGeneratedOnUpdate();

        builder.HasIndex(m => m.Title);

        // Named query filter: only show released movies
        //builder.HasQueryFilter("Released", m => m.ReleaseDate <= DateTimeOffset.UtcNow);

        // Named query filter: only show movies rated 7 or higher
        //builder.HasQueryFilter("HighRated", m => m.Rating >= 7);
    }
}
