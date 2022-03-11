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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Vehiculo vehiculo = new Vehiculo();            
            vehiculo.placa = txtPlaca.Text;
            vehiculo.marca = txtMarca.Text;
            vehiculo.modelo = Convert.ToInt16(txtModelo.Text);
            vehiculo.precio = Convert.ToInt16(txtPreciok.Text);
            cliente.nit = txtNit.Text;
            cliente.nombre = txtNombre.Text;
            cliente.direccion = txtDireccion.Text;
            int pocicionVehiculo = vehiculos.FindIndex(p => p.placa == vehiculo.placa);
            int pocicionCiente = clientes.FindIndex(c => c.nit == cliente.nit);
            if (pocicionVehiculo == -1)
            {
                vehiculos.Add(vehiculo);
                guardar("vehiculos.txt");
            }
            else
            {
                MessageBox.Show("vehiculo ya existente");
            }
            if (pocicionCiente == -1)
            {
                clientes.Add(cliente);
                guardar("clientes.txt");
            }
            else
            {
                MessageBox.Show("cliente ya existente");
            }
        }

        private void guardar(String fileNombre)
        {
            FileStream stream = new FileStream(fileNombre, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            if (fileNombre == "vehiculos.txt")
            {
                foreach (var vehiculo in vehiculos)
                {
                    writer.WriteLine(vehiculo.placa);
                    writer.WriteLine(vehiculo.marca);
                    writer.WriteLine(vehiculo.modelo);
                    writer.WriteLine(vehiculo.color);
                    writer.WriteLine(vehiculo.precio);
                }
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine(cliente.nit);
                    writer.WriteLine(cliente.nombre);
                    writer.WriteLine(cliente.direccion);
                }
            }
            writer.Close();
        }
    }
}
