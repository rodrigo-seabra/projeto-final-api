namespace Api.Models
{
    public class ObservacoesModel
    {
        public int ObservacoesId { get; set; }
        public string? ObservacoesDescricao { get; set; }
        public string? ObservacaoLocal { get; set; }
        public DateTime? ObservacoesData { get; set; }
        public int UsuarioId { get; set; }
        public int ObjetoId { get; set; }

        public static implicit operator List<ObservacoesModel>(ObservacoesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
