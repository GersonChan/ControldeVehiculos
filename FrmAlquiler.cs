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
    public partial class FrmAlquiler : Form
    {
        public FrmAlquiler()
        {
            InitializeComponent();
        }

        List<Alquiler> alquileres = new List<Alquiler>();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.nit = txtNit.Text;
            alquiler.placa = txtPlaca.Text;
            alquiler.fechaAlquiler = dtpFechaAlquiler.Value;
            alquiler.fechaDevolucion = dtpFechaDevolucion.Value;
            alquiler.kRecorridos = Convert.ToInt16(txtKilometroRecorrido.Text);
            alquileres.Add(alquiler);
            guardar("alquiler.txt");
        }

        private void guardar(String fileNombre)
        {
            FileStream stream = new FileStream(fileNombre, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var alquiler in alquileres)
            {
                writer.WriteLine(alquiler.nit);
                writer.WriteLine(alquiler.placa);
                writer.WriteLine(alquiler.fechaAlquiler);
                writer.WriteLine(alquiler.fechaDevolucion);
                writer.WriteLine(alquiler.kRecorridos);
            }
            writer.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            FrmMostrar mostrar = new FrmMostrar();
            mostrar.ShowDialog();
        }
    }
}
