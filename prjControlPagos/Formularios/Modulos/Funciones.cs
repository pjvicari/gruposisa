using System;
namespace ControlPagos
{
    public static class Funciones
    {
        // Para la conexión de base de datos
        public static Conexion.ModuloGeneral.AmbienteDeBaseDeDatos Ambiente = Conexion.ModuloGeneral.AmbienteDeBaseDeDatos.Desarrollo;
        public static int AñoDeOperacion = DateTime.Now.Year;
        // Información de la aplicación
        public static int IDAplicacion = 1;
        public static string SiglasDelSistema = "SCP";
        public static string NombreDelSistema = "Sistema de control de pagos";
        // Para la seguridad
        //public static Negocio.Usuario Usuario = new Negocio.Usuario();
        public static Conexion.UnidadOperativa UnidadOperativa = new Conexion.UnidadOperativa();
    }
}