using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Integracao
{
    public static class IntegracaoService
    {
        public static Response<Cliente> GetCliente(string email)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("cliente/ObterPorEmail", new { Dados = email, Token = "CorrectHorseBatteryStaple" }).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<Cliente>>().Result;
                return result;
            }
            else return new Response<Cliente> { Sucesso = false };
        }

        public static Response<int> PostCliente(Cliente cliente)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("cliente/post", new { Dados = new { Nome = cliente.Nome, CPF = cliente.Cpf, Email = cliente.Email, Senha = cliente.Senha, Nascimento = cliente.DataNascimento, Cartao = "123543"},
                Token = "CorrectHorseBatteryStaple" }).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<int>>().Result;
                return result;
            }
            else return new Response<int> { Sucesso = false };
        }

        public static Response<Agencia> GetAgencia(string sigla)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/" + $"agencia/obterporsigla?sigla={sigla}")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<Agencia>>().Result;
                return result;
            }
            else return new Response<Agencia> { Sucesso = false };
        }

        public static Response<int> PostLocacao(Locacao locacao)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("locacao/post", locacao).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<int>>().Result;
                return result;
            }
            else return new Response<int> { Sucesso = false };

        }

    }
}
