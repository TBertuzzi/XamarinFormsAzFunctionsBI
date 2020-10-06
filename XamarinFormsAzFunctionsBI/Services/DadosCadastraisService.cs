using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XamarinFormsAzFunctionsBI.Helpers;
using XamarinFormsAzFunctionsBI.Models;
using XamarinFormsAzFunctionsBI.Services.DTO;

namespace XamarinFormsAzFunctionsBI.Services
{
    public class DadosCadastraisService : IDadosCadastraisService
    {
        private static HttpClient _httpClient;

        public DadosCadastraisService()
        {
            var handler = new HttpClientHandler();

            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(Infra.ApiURL) };

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Response<RetornoDto>> Cadastrar(CadastroDto cadastro)
        {
            try
            {
                var resultJson = await _httpClient.
                    PostAsync<Response<RetornoDto>>($"DadosCadastrais?code=quIxkhmhhEsex5Uhyab4QiQyvj5NfaOSKRwaGJWP4dRL5mU0M00mRw==", cadastro);

                return resultJson.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("[API: Cadastros] " + ex.Message);
            }
        }

        public async Task<Response<IEnumerable<CadastroDto>>> ListarDadosCadastrais()
        {
            try
            {
                var resultJson = await _httpClient.
                                     GetAsync<Response<IEnumerable<CadastroDto>>>("ListarDadosCadastrais");

                return resultJson.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("[API: Cadastros] " + ex.Message);
            }
        }
    }
}
