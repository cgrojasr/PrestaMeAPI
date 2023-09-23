using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PrestaMe.BE;

namespace UPC.PrestaMe.DA
{
    public class TasaDA
    {
        private readonly SqlConnection conn;
        private readonly AppSettings appSettings;
        public TasaDA()
        {
            appSettings = new AppSettings();
            conn = new SqlConnection(appSettings.ConnectionString);
        }

        public TasaBE_Activa Obtener_RangoActivo() { 
            using(conn)
            {
                var query = "SELECT id_tasa_rango, tasa_minimo, tasa_maximo FROM tasa_rango WHERE activo = 1";
                var tasa_rango = conn.Query<TasaBE_Activa>(query).Single();
                return tasa_rango;
            }
        }
    }
}
