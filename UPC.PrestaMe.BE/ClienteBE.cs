using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PrestaMe.BE
{
    public class ClienteBE
    {
        public int id_cliente { get; set; } = 0;
        public string nombres { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime fecha_nacimiento { get; set; }
        public int id_doc_identidad { get; set; }
        public string numero_doc_identidad { get; set; } = string.Empty;
    }
}
