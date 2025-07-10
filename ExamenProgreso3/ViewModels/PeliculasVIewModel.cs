using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3.ViewModels
{
    internal class PeliculasVIewModel: INotifyPropertyChanged
    {
        private string _titulo;
        private string _genero;
        private int _anio;
        private int _calificacion;  
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }
        public string Genero
        {
            get => _genero;
            set
            {
                _genero = value;
                OnPropertyChanged(nameof(Genero));
            }
        }
        public int Anio
        {
            get => _anio;
            set
            {
                if (_anio < 2024) 
                { // Validación para que el año no sea mayor a 2024
                    throw new ArgumentOutOfRangeException(nameof(Anio), "El año no puede ser mayor a 2024.");
                }
                _anio = value;
                OnPropertyChanged(nameof(Anio));
            }
        }

        public int Calificacion 
        {
            get => _calificacion;
            set 
            {
                if (_calificacion < 3) 
                {
                    throw new ArgumentOutOfRangeException(nameof(Calificacion), "La calificación no puede ser menor a 3.");
                }
                _calificacion = value;
                OnPropertyChanged(nameof(Calificacion));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }   
}
