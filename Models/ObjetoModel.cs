namespace Api.Models
{
    public class ObjetoModel
    {
        public int ObjetoId { get; set; }

        public string ObjetoNome { get; set; } = string.Empty;

        public string ObjetoCor { get; set; } = string.Empty;

        public string ObjetoObservacao { get; set; } = string.Empty;

        public string ObjetoLocalDesaparecimento { get; set; } = string.Empty;

        public string? ObjetoFoto { get; set; }

        public DateTime ObjetoDtDesaparecimento { get; set; }

        public DateTime? ObjetoDtEncontro { get; set; }
        public byte ObjetoStatus { get; set; }
        public int UsuarioId { get; set; }

        public static implicit operator List<ObjetoModel>(ObjetoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
