using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronRepositorios.BLL;



namespace PatronRepositoriosTests
{
    [TestClass()]
    public class RepositorioBasesTests
    {
        [TestMethod()]
      
       
        public void GuardarTest()
        {
            RepositorioBases<Empleados> repositorio = new RepositorioBases<Empleados>();
            Empleados empleados = new Empleados();
            empleados.EmpleadoID = 0;
            empleados.Fecha = DateTime.Now;
            empleados.Direccion = "arenoso/principal casa#29";
            empleados.Nombres = "Carlos";
            empleados.Telefonos = "829-912-2344";
            empleados.Celular = "829-456-2111";
            empleados.Cedula = "402-1890234-7";
            empleados.Sueldo = 23223;
            empleados.Incentivo = 289;
            Assert.IsTrue(repositorio.Guardar(empleados));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBases<Empleados> repositorio = new RepositorioBases<Empleados>();
            Empleados empleados = new Empleados();
            empleados.EmpleadoID = 2;
            empleados.Fecha = DateTime.Now;
            empleados.Direccion = "arenoso/principal casa#29";
            empleados.Nombres = "Carlos";
            empleados.Telefonos = "809-912-2344";
            empleados.Celular = "809-456-2111";
            empleados.Cedula = "402-1890234-7";
            empleados.Sueldo = 23223;
            empleados.Incentivo = 289;
            Assert.IsTrue(repositorio.Guardar(empleados));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBases<Empleados> datos = new RepositorioBases<Empleados>();
            Empleados e = new Empleados();
            e = datos.Buscar(2);
            Assert.IsNotNull(e);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBases<Empleados> repos = new RepositorioBases<Empleados>();
            List<Empleados> 
                Lista = new List<Empleados>();
            Lista = repos.GetList(p => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void DisposeTest()
        {

        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBases<Empleados> repos= new RepositorioBases<Empleados>();
            Assert.IsTrue(repos.Eliminar(2));
        }
    }
}
