using System;
using System.Windows.Forms;

namespace Presentation.Forms.Users.Helps
{
    // Clase para manejar el redimensionamiento del formulario
    public class ResizeHandler
    {
        private Form form;

        public ResizeHandler(Form form)
        {
            this.form = form;
        }

        // Método para redimensionar el formulario al tamaño de la pantalla
        public void ResizeToScreen()
        {
            form.Width = Screen.PrimaryScreen.Bounds.Width;
            form.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        // Método para manejar el evento Resize del formulario
        public void Form_Resize(object sender, EventArgs e)
        {
            // Lógica para manejar el evento Resize aquí
            // Por ejemplo, podrías ajustar el tamaño o la posición de los controles del formulario
            // Por ahora, simplemente imprimir un mensaje en la consola cuando se redimensione el formulario
            Console.WriteLine("El formulario se ha redimensionado.");
        }
    }
}
