using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProgreso3.Models;

namespace ExamenProgreso3.Repositories
{
    internal class PeliculaRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Pelicula>();
        }

        public PeliculaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPelicula(string titulo, string genero, int anio, int calificacion)
        {
            //Este metodo es para el agregar una nueva película a la base de datos.
            int result = 0;
            try
            {
                //Inicializamos la conexión a la base de datos
                Init();
                //Comprobamos que el título no sea nulo o vacío
                if (string.IsNullOrEmpty(titulo))
                    throw new Exception("El título es obligatorio");

                //Creamos un tipo de dato Pelicula y le asignamos los valores
                var nuevaPelicula = new Pelicula
                {
                    titulo = titulo,
                    genero = genero,
                    anio = anio,
                    calificacion = calificacion
                };
                //Insertamos la nueva película en la base de datos
                result = conn.Insert(nuevaPelicula);

                //Asignamos el mensaje de estado con el número de registros agregados y el título de la película
                StatusMessage = string.Format("Se registro correctamente");
            }
            catch (Exception ex)
            {
                //Si hay error durante el proceso de guardar dentro de la base de datos
                StatusMessage = string.Format("No se pudo agregar, revisale bien, papi",ex.Message);
            }
        }

        public List<Pelicula> GetAllPeliculas()
        {
            //Es un método para recuperar todas las películas de la base de datos.
            try
            {
                //Inicializamos la conexión a la base de datos
                Init();
                //Creamos una lista que contenga todos los valores de al base datos ue son del tipo Pelicula
                return conn.Table<Pelicula>().ToList();
            }
            catch (Exception ex)
            {
                //Nuestro error exception, si no se pudo recuperar la información de la base de datos
                StatusMessage = string.Format("No se pudo recuperar la información");
            }
            //Si todo estabien,  enlistaraa a las peliculas.
            return new List<Pelicula>();
        }
    }
}
