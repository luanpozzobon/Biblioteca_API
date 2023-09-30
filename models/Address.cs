using Newtonsoft.Json;

namespace Biblioteca_API.models
{
    public record Address(string cep, string state, string city, string street, string number, string complement)
    {

    }
}