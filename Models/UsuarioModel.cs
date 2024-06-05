namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string? UsuarioEmail { get; set; }

        public string? UsuarioSenha { get; set; }
        public string? UsuarioTelefone { get; set; }

        public string? UsuarioNome { get; set; }

        public static implicit operator List<object>(UsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
