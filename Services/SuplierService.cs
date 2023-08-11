using DataAccess.Interfaces;
using Entities;
using MercaExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaExpress.Services
{
    public class SuplierService: ISuplierService
    {
        ISuplierRepo suplierRepo;

        public SuplierService(ISuplierRepo suplierRepo)
        {
            this.suplierRepo = suplierRepo; 
        }

        public bool CreateSuplier(Suplier suplier)
        {
            return suplierRepo.CreateSuplier(suplier);
        }

        public bool DeleteSuplier(Suplier suplier)
        {
            return suplierRepo.DeleteSuplier(suplier);
        }

        public Suplier GetSuplierById(int id)
        {
            return suplierRepo.GetSuplierById(id);
        }

        public List<Suplier> GetSupliers()
        {
            return suplierRepo.GetSupliers();
        }

        public bool UpdateSuplier(Suplier suplier)
        {
            return suplierRepo.ModifySuplier(suplier);
        }
    }
}
