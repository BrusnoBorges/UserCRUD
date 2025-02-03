using User.Model;

namespace User.Interface
{
    public interface IBrasilApiService
    {
        Task<EnderecoModel> GetEnderecoByCEP(string CEP);
    }
}
