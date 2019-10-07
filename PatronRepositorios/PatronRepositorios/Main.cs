using PatronRepositorios.UI.Consultas;
using PatronRepositorios.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorios
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void RegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEmpleados r = new rEmpleados();
            r.Show();
        }

        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEmpleados r = new cEmpleados();
            r.Show();
        }
    }
}
