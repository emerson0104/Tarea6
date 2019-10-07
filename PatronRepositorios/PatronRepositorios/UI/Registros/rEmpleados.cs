using PatronRepositorios.BLL;
using PatronRepositorios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorios.UI.Registros
{
    public partial class rEmpleados : Form
    {
        public rEmpleados()
        {
            InitializeComponent();
        }
        private Empleados LlenaClase()
        {
            Empleados empleados = new Empleados();
            empleados.EmpleadoID = (int)(EmpleadoIDnumericUpDown.Value);
            empleados.Fecha = FechadateTimePicker.Value;
            empleados.Nombres = NombrestextBox.Text;
            empleados.Direccion = DirecciontextBox.Text;
            empleados.Telefonos = TelefonomaskedTextBox.Text;
            empleados.Celular = CelularmaskedTextBox.Text;
            empleados.Cedula = CedulamaskedTextBox.Text;
            empleados.Sueldo = Convert.ToDecimal(SueldotextBox.Text);
            empleados.Incentivo = Convert.ToDecimal(IncentivotextBox.Text);
            return empleados;
        }
        private void Limpiar()
        {
            EmpleadoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombrestextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;
            errorProvider.Clear();
        }

        private void LlenaCampo(Empleados empleados)
        {
            EmpleadoIDnumericUpDown.Value = empleados.EmpleadoID;
            FechadateTimePicker.Value = empleados.Fecha;
            NombrestextBox.Text = empleados.Nombres;
            DirecciontextBox.Text = empleados.Direccion;
            TelefonomaskedTextBox.Text = empleados.Telefonos;
            CelularmaskedTextBox.Text = empleados.Celular;
            CedulamaskedTextBox.Text = empleados.Cedula;
            SueldotextBox.Text = empleados.Sueldo.ToString();
            IncentivotextBox.Text = empleados.Incentivo.ToString();
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                errorProvider.SetError(NombrestextBox, "No puede Haber Campos en Blanco ");
                NombrestextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "El Campo Direccion no puede estar en Blanco ");
                DirecciontextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider.SetError(TelefonomaskedTextBox, "El Campo Telefono no puede estar en Blanco ");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider.SetError(CedulamaskedTextBox, "El Campo cedula no puede estar en Blanco");
                CedulamaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelularmaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider.SetError(CelularmaskedTextBox, "El campo celular no puede estar en Blanco ");
                CelularmaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                errorProvider.SetError(SueldotextBox, "El campo sueldo no puede estar En Blanco");
                SueldotextBox.Focus();
                paso = false;
            }
            else
            {
                if (Convert.ToDecimal(SueldotextBox.Text) < 0)
                {
                    errorProvider.SetError(SueldotextBox, "El Empleado no puede Tener un sueldo Menor Que cero");
                    SueldotextBox.Focus();
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(IncentivotextBox.Text))
            {
                errorProvider.SetError(IncentivotextBox, "El campo incentivo no puede estar En Blanco");
                IncentivotextBox.Focus();
                paso = false;
            }
            else
            {
                if (Convert.ToDecimal(IncentivotextBox.Text) < 0)
                {
                    errorProvider.SetError(IncentivotextBox, "El campo incentivo tiene que ser mayor que cero");
                    IncentivotextBox.Focus();
                    paso = false;
                }
            }

            return paso;
        }

        private bool Existe()
        {
            var repositorio = new RepositorioBases<Empleados>();
            Empleados empleado = repositorio.Buscar((int)(EmpleadoIDnumericUpDown.Value));
            return (empleado != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

     


    

        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            var repositorio = new RepositorioBases<Empleados>();
            int id = (int)(EmpleadoIDnumericUpDown.Value);
            Empleados empleados = new Empleados();

            empleados = repositorio.Buscar(id);

            if (empleados != null)
            {
                Limpiar();
                LlenaCampo(empleados);
            }
            else
            {
                MessageBox.Show("Empleado no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            int id = (int)(EmpleadoIDnumericUpDown.Value);
            var repositorio = new RepositorioBases<Empleados>();

            if (!Existe())
            {
                MessageBox.Show("No se puede Eliminar Un Empleado Que no Existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                paso = repositorio.Eliminar(id);

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Empleado Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empleado no Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Guardarbutton_Click_1(object sender, EventArgs e)
        {
            Empleados em = new Empleados();
            bool paso = false;
            RepositorioBases<Empleados> repositorio = new RepositorioBases<Empleados>();

            if (!Validar())
                return;

            em = LlenaClase();

            if (EmpleadoIDnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(em);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este Empleado", "Falla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(em);
            }

            if (paso)
            {
                MessageBox.Show("!!Guardado", "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se Guardo", "Falla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


   
}
