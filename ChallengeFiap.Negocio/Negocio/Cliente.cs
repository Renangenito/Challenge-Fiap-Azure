using ChallengeFiap.Entity;
using ChallengeFiap.Models.Models;
using Microsoft.Extensions.Configuration;


namespace ChallengeFiap.Negocio.Negocio
{
    public class Cliente : ICliente
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public Cliente(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Incluir(ClienteModel clienteModel)
        {
            _context.TBClientes.Add(clienteModel);
            await _context.SaveChangesAsync();
        }



        public List<ClienteModel> ObterLista()
        {
            return _context.TBClientes.ToList();
        }
    }
}
