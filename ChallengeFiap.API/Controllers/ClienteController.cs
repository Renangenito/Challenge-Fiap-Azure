﻿using Azure.Storage.Blobs;
using ChallengeFiap.Models.Models;
using ChallengeFiap.Negocio.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace ChallengeFiap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ICliente _cliente;
       
        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
           
        }

        [HttpGet()]

        public List<ClienteModel> Get()
        {
            var clientes = _cliente.ObterLista();

            return clientes;
        }

        [HttpPost()]
        public async Task Post([FromBody] ClienteModel clienteModel)
        {

            if (clienteModel.Imagem != null && clienteModel.Imagem.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";

                // Limpa o hash enviado
                var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(clienteModel.Imagem, "");

                // Define o BLOB no qual a imagem será armazenada
                var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=renanimg01;AccountKey=hKxktZcGt+LWR3Bv9mHh576lhyZP9vrceBQklTRMvXcWb7xNLgAT0oHg6/RTPE1syTD++EddwIB5+AStViZINQ==;EndpointSuffix=core.windows.net", "dados", fileName);

                // Gera um array de Bytes
                byte[] bytes = Encoding.UTF8.GetBytes(data);

                // Envia a imagem
                using (var stream = new MemoryStream(bytes))
                {
                    blobClient.Upload(stream);
                }
               
            }

            await _cliente.Incluir(clienteModel);
        }

    }
}
