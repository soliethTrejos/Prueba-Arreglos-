using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_2.Models
{
    public class Biblioteca
    {
        private List<Libro> libros;

        public Biblioteca()
        {
            libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void OrdenarLibros()
        {
            QuickSort(libros, 0, libros.Count - 1);
        }

        private void QuickSort(List<Libro> lista, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int pivote = Particionar(lista, izquierda, derecha);
                QuickSort(lista, izquierda, pivote - 1);
                QuickSort(lista, pivote + 1, derecha);
            }
        }

        private int Particionar(List<Libro> lista, int izquierda, int derecha)
        {
            string pivote = lista[derecha].Titulo;
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (string.Compare(lista[j].Titulo, pivote, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    i++;
                    var temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            var temp2 = lista[i + 1];
            lista[i + 1] = lista[derecha];
            lista[derecha] = temp2;

            return i + 1;
        }

        public List<Libro> BuscarLibroPorTitulo(string titulo)
        {
            return libros.Where(libro =>
            {
                return libro.Titulo.IndexOf(titulo, StringComparison.OrdinalIgnoreCase) >= 0;
            }).ToList();
        }
    }
    public struct Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoPublicacion { get; set; }

        public Libro(string titulo, string autor, int añoPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            AñoPublicacion = añoPublicacion;
        }
    }
}



