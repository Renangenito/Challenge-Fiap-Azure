using ChallengeFiap.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Negocio.Negocio
{
    public interface ICliente
    {
        List<ClienteModel> ObterLista();

        Task Incluir(ClienteModel clienteModel);
    }
}
