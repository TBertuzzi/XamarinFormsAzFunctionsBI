using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAzFunctionsBI.Models;
using XamarinFormsAzFunctionsBI.Services.DTO;

namespace XamarinFormsAzFunctionsBI.Services
{
    public class DadosCadastraisService : IDadosCadastraisService
    {
        public DadosCadastraisService()
        {

        }

        public Task<Response<RetornoDto>> Cadastrar(CadastroDto cadastro)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("[API: Cadastros] " + ex.Message);
            }
        }

        public Task<Response<IEnumerable<CadastroDto>>> ListarDadosCadastrais()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("[API: Cadastros] " + ex.Message);
            }
        }
    }
}
