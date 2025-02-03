using Microsoft.EntityFrameworkCore.Metadata;
using User.Model;

namespace User.DTO
{
    public record EnderecoDTO
    {
        public string? CEP { get; set; }
        public string? Rua { get;  set; }
        public string? Bairro { get;  set; }
        public string? Cidade { get;  set; }
        public string? Estado { get;  set; }

    }
}
