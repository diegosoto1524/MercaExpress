using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercaExpress;

namespace MercaExpress.Services
{
    public interface ISuplierService
    {
        bool CreateSuplier(Suplier suplier);
        bool DeleteSuplier(Suplier suplier);
        List<Suplier> GetSupliers();
        Suplier GetSuplierById(int id);
        bool UpdateSuplier(Suplier suplier);

    }
}
