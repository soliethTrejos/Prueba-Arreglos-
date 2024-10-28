using ejercicio_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_2
{
    public partial class Form1 : Form
    {
        Biblioteca biblioteca = new Biblioteca();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Leer los datos del libro desde los controles
            string titulo = tbNombre.Text;
            string autor = tbAutor.Text;
            int añoPublicacion = dtpFecha.Value.Year;

            // Crear un nuevo libro y agregarlo a la biblioteca
            Libro nuevoLibro = new Libro(titulo, autor, añoPublicacion);
            biblioteca.AgregarLibro(nuevoLibro);

            // Ordenar la lista de libros por título
            biblioteca.OrdenarLibros();

            // Limpiar los campos
            tbNombre.Clear();
            tbAutor.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el título a buscar
            string tituloBuscar = tblibro.Text;

            // Buscar el libro en la biblioteca
            var librosEncontrados = biblioteca.BuscarLibroPorTitulo(tituloBuscar);

            // Mostrar los libros encontrados en el ListBox
            lbLibrosEncontrados.Items.Clear();
            foreach (var libro in librosEncontrados)
            {
                lbLibrosEncontrados.Items.Add($"{libro.Titulo} - {libro.Autor} - {libro.AñoPublicacion}");
            }
        }

        private void lbLibrosEncontrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLibrosEncontrados.SelectedIndex >= 0)
            {
                // Obtener el libro seleccionado
                var libroSeleccionado = biblioteca.BuscarLibroPorTitulo(lbLibrosEncontrados.SelectedItem.ToString());

                // Mostrar los datos del libro seleccionado
                tbNombre.Text = libroSeleccionado[0].Titulo;
                tbAutor.Text = libroSeleccionado[0].Autor;
                dtpFecha.Value = new DateTime(libroSeleccionado[0].AñoPublicacion, 1, 1);
            }
            else
            {
                tbNombre.Clear();
                tbAutor.Clear();
            }
        }
    }
}

