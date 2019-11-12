using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CarreraBLL
    {
        public Carrera CrearCarrera(Carrera carrera)
        {
            Carrera nuevaCarrera = null;
            using (var r = new Repository<Carrera>())
            {
               nuevaCarrera = r.Create(carrera);
            }
            return nuevaCarrera;
        }

        public Carrera ObtenerCarrera(int id)
        {
            Carrera carrera = null;
            using (var r = new Repository<Carrera>())
            {
               carrera = r.Retrieve(p => p.Id == id);
            }
            return carrera;
        }
    }
}
