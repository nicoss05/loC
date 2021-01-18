using System;
using Entities;
using Interface;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using DattaMonica;

namespace loC
{
    class Program
    {
        readonly CompositionContainer contenedor;
        private Program()
        {
            var catalogo = new AggregateCatalog();
            catalogo.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            contenedor = new CompositionContainer(catalogo);
            try
            {
                this.contenedor.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        [Import(typeof(IGrabador))]
        public IGrabador Persistencia { get; set; }
       

        public static void Main(string[] args)
        {
           
            var programa = new Program();
            programa.RealizarTrabajo();
        }

        public void RealizarTrabajo()
        {
            Console.WriteLine("Hello Inversion de Control!");
            var persistencia = new Persistencia();
            var estudiante = new Estudiante
            
            {
                Nombre = "Nicolás",
                Apellido = "Suárez"
            };
           // IGrabador persistencia = new Persistencia();
            if (persistencia.Grabar(estudiante))
                Console.WriteLine("Se grabo");
        }

    }

}
