using ChallengeFiap.Comum.Modelo;
using ChallengeFiap.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ChallengeFiap.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;

        public ClienteController(IOptions<DadosBase> dadosBase, HttpClient httpClient)
        {
            _dadosBase = dadosBase;
            _httpClient = httpClient;
        }

        public async Task<ActionResult> Index(string mensagem = null, bool sucesso = true)
        {
           
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}/Cliente");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar obter o cliente!");
            }

        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ClienteModel clienteModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}/Cliente", clienteModel);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro cadastraado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao Cadastrar o Cliente!");
                    }


                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }
    }
}
