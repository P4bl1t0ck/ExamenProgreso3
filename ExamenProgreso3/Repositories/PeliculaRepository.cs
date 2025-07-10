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

        // TODO: Add variable for the SQLite connection
        private SQLiteConnection conn;
        private void Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return; // already initialized
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Pelicula>(); // Create the table if it doesn't exist
        }

        public PeliculaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                conn.Insert
                result = conn.Insert(new Pelicula { titulo= titulo});

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list

            try
            {
                Init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }

    }
}
