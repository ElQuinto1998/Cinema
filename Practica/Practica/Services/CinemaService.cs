using Practica.Helpers;
using Practica.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica.Services
{
    class CinemaService
    {
        public static List<Cartelera> GetCinemas()
        {
            var carteleras = ApiHelper.Get<List<Cartelera>>("/api/Cartelera");
            return carteleras;

        }

        public static Permiso Login(Usuarios usuario)
        {
            var respuesta = ApiHelper.Post<Permiso>("/api/Seguridad", usuario);
            return respuesta;
        }
    }
}
