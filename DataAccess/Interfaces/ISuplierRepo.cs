using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
     public interface ISuplierRepo
    {
        bool CreateSuplier(Suplier suplier);
        bool DeleteSuplier(Suplier suplier);
        List <Suplier> GetSupliers();
        Suplier GetSuplierById(int id);
        bool ModifySuplier (Suplier suplier);
    }
}
