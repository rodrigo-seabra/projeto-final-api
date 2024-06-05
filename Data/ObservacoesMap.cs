using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ObservacoesMap: IEntityTypeConfiguration<ObservacoesModel>
    {
        public void Configure(EntityTypeBuilder<ObservacoesModel> builder)
        {
            builder.HasKey(x => x.ObservacoesId);
            builder.Property(x => x.ObservacoesDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacoesData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetoId).IsRequired().HasMaxLength(255);

        }
    }
}
