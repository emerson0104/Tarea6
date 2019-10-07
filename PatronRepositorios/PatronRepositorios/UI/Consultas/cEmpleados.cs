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

namespace PatronRepositorios.UI.Consultas
{
    public partial class cEmpleados : Form
    {
        public cEmpleados()
        {
            InitializeComponent();
        }

            private int getID()
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    return id;
                }
                catch (Exception)
                {
                    MessageBox.Show("El criterio debe ser un dato numerico de tipo entero", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return id;
            }
        private void Consultabutton_Click(object sender, EventArgs e)
        {


            RepositorioBases<Empleados> repos = new RepositorioBases<Empleados>();
                List<Empleados> Lista = new List<Empleados>();
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrocomboBox.SelectedIndex)
                    {
                        case 0: //todo
                            Lista = repos.GetList(p => true);
                            break;
                        case 1: //ID
                            int id = getID();
                            Lista = repos.GetList(p => p.EmpleadoID == id);
                            break;
                        case 2: //Nombre
                            Lista = repos.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                            break;
                        case 3: //Direccion
                            Lista = repos.GetList(p => p.Direccion.Contains(CriteriotextBox.Text));
                            break;
                        case 4: //Cedula
                            Lista = repos.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                            break;
                        case 5: //Telefono
                            Lista = repos.GetList(p => p.Telefonos.Contains(CriteriotextBox.Text));
                            break;
                        case 6: //Celular
                            Lista = repos.GetList(p => p.Celular.Contains(CriteriotextBox.Text));
                            break;
                        default:
                            MessageBox.Show("No existe este filtro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    Lista = Lista.Where(p => p.Fecha >= DesdedateTimePicker.Value.Date && p.Fecha <= HastadateTimePicker.Value.Date).ToList();
                }
                else
                {
                    Lista = repos.GetList(p => true);
                }

                ConsultadataGridView.DataSource = null;
                ConsultadataGridView.DataSource = Lista;
            }
        }
    }

