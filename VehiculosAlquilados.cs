using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControldeVehiculos
{
    internal class VehiculosAlquilados
    {
        public string nombre { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public int modelo { get; set; }
        public string color { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public int totalPagar { get; set; }
    }
}
