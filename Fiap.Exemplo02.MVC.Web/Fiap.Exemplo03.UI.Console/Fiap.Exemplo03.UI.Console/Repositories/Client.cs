using Fiap.Exemplo03.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{
    public class Client
    {
        public IEnumerable<AlunoDTO> client_consome()
        {
            using (var client = new HttpClient()) {
                IEnumerable<AlunoDTO> aluno;

                client.BaseAddress = new Uri("http://localhost:58692/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/aluno").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<AlunoDTO>>().Result;
                }                return null;

            }

        }

        public void client_post(AlunoDTO aluno)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58692/");
                var cli = new AlunoDTO() {Nome = aluno.Nome, 
                    Desconto = aluno.Desconto,Bolsa = aluno.Bolsa};

                HttpResponseMessage response = client.PostAsJsonAsync("api/aluno", cli).Result;

                if (response.IsSuccessStatusCode)
                {
                    Uri uri = response.Headers.Location;
                }
            }
        }
        



    }

}
