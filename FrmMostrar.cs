using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControldeVehiculos
{
    public partial class FrmMostrar : Form
    {
        public FrmMostrar()
        {
            InitializeComponent();
        }
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<VehiculosAlquilados> vehiculosAl = new List<VehiculosAlquilados>();

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            leer("clientes.txt");
            leer("vehiculos.txt");
            leer("alquiler.txt");
            vehiculosAlquilados();

            alquileres = alquileres.OrderByDescending(c => c.kRecorridos).ToList();
            kmRecorrido.Text = "Kilometros recorriodos: " + alquileres[0].kRecorridos.ToString();
            mostrar();
        }

        private void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = vehiculos;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            dataGridView2.DataSource = alquileres;
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.Refresh();

            dataGridView3.DataSource = vehiculosAl;
            dataGridView3.Refresh();
        }

        private void vehiculosAlquilados()
        {
            for(int i = 0; i < alquileres.Count; i++)
            {
                VehiculosAlquilados vehiculoAlTemp = new VehiculosAlquilados();
                for (int j = 0; j < clientes.Count; j++)
                {
                    if (clientes[j].nit == alquileres[i].nit)
                    {
                        vehiculoAlTemp.nombre = clientes[j].nombre;
                        vehiculoAlTemp.fechaDevolucion = alquileres[i].fechaDevolucion;
                    }
                }
                for (int k = 0; k < vehiculos.Count; k++)
                {
                    if (alquileres[i].placa == vehiculos[k].placa)
                    {
                        vehiculoAlTemp.placa = vehiculos[k].placa;
                        vehiculoAlTemp.marca = vehiculos[k].marca;
                        vehiculoAlTemp.modelo = vehiculos[k].modelo;
                        vehiculoAlTemp.color = vehiculos[k].color;
                        vehiculoAlTemp.totalPagar = vehiculos[k].precio * alquileres[i].kRecorridos;
                    }
                }
                vehiculosAl.Add(vehiculoAlTemp);
            }
        }

        private void leer(string fileNombre)
        {
            FileStream stream = new FileStream(fileNombre, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Cliente clienteTemp = new Cliente();
                Vehiculo vehiculoTemp = new Vehiculo();
                Alquiler alquilerTemp = new Alquiler();
                if (fileNombre == "clientes.txt")
                {
                    clienteTemp.nit = reader.ReadLine();
                    clienteTemp.nombre = reader.ReadLine();
                    clienteTemp.direccion = reader.ReadLine();
                    clientes.Add(clienteTemp);
                }
                else if (fileNombre == "vehiculos.txt")
                {
                    vehiculoTemp.placa = reader.ReadLine();
                    vehiculoTemp.marca = reader.ReadLine();
                    vehiculoTemp.modelo = Convert.ToInt16(reader.ReadLine());
                    vehiculoTemp.color = reader.ReadLine();
                    vehiculoTemp.precio = Convert.ToInt16(reader.ReadLine());
                    vehiculos.Add(vehiculoTemp);
                }
                else if (fileNombre == "alquiler.txt")
                {
                    alquilerTemp.nit = reader.ReadLine();
                    alquilerTemp.placa = reader.ReadLine();
                    alquilerTemp.fechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                    alquilerTemp.fechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                    alquilerTemp.kRecorridos = Convert.ToInt16(reader.ReadLine());
                    alquileres.Add(alquilerTemp);
                }
            }
            reader.Close();
        }

    }
}
