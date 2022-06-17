using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using moviesAPI.Models;

namespace moviesAPI.ModelConfiguration
{

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Director).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.Gender).IsRequired();

        }
    }
}
