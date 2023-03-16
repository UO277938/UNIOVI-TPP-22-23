using System;

namespace Modelo
{
    public class Libro
    {
        public string Titulo { get; private set; }

        public string Autor { get; private set; }

        public uint NPages { get; private set; }

        public uint Year { get; private set; }

        public string Genero { get; private set; }

        public override string ToString()
        {
            return String.Format("Libro: {0}, Autor: {1} con nPages: {2} salio en: {3} y genero: {4}.", Titulo, Autor, NPages, Year, Genero);
        }

        public Libro(string titulo, string autor, uint nPages, uint year, string genero)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.NPages = nPages;
            this.Year = year;
            this.Genero = genero;
        }

        public void Saluda()
        {
            Console.WriteLine("Hola, soy {0}", this.Titulo);
        }

    }
}
