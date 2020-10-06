using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAzFunctionsBI.Models;
using XamarinFormsAzFunctionsBI.Services.DTO;

namespace XamarinFormsAzFunctionsBI.Services
{
    public interface IDadosCadastraisService
    {
        Task<Response<IEnumerable<CadastroDto>>> ListarDadosCadastrais();
        Task<HttpExtensionResponse<RetornoDto>> Cadastrar(CadastroDto cadastro);
    }
}
