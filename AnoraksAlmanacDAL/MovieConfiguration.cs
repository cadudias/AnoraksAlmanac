using AnoraksAlmanacModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnoraksAlmanacDAL
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .Property(m => m.OriginalTitle)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
               .Property(m => m.Title)
               .HasColumnType("nvarchar(50)")
               .IsRequired();

            builder
               .Property(m => m.OriginalLanguage)
               .HasColumnType("nvarchar(10)");

            builder
              .Property(m => m.PosterPath)
              .HasColumnType("nvarchar(250)");

            builder
              .Property(m => m.Adult)
              .HasColumnType("bit");

            builder
              .Property(m => m.Overview)
              .HasColumnType("text");

            //builder
            //  .Property(m => m.ReleaseDate)
            //  .HasColumnType("datetime");

            builder
              .Property(m => m.BackdropPath)
              .HasColumnType("text");

            builder
             .Property(m => m.VoteCount)
             .HasColumnType("int");
        }
    }
}