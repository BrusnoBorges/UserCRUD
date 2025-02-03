using Microsoft.EntityFrameworkCore.Metadata;
using User.Model;

namespace User.DTO
{
    public class EnderecoDTO
    {
        public string? CEP { get; private set; }
        public string? Rua { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }

        public void PrencherDTO(EnderecoModel enderecoModel)
        {
            CEP = enderecoModel.cep;
            Rua = enderecoModel.street;
            Bairro = enderecoModel.neighborhood;
            Cidade = enderecoModel.city;
            Estado = enderecoModel.state;
        }
    }
}
