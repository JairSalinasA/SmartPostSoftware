using System;
using System.Windows.Forms;
using Presentation.Forms.Users.Helps; // Importa la clase ResizeHandler

namespace Presentation.Forms.Users
{
    public partial class Form_Users : Form
    {
        public Form_Users()
        {
            InitializeComponent();

            // Instanciar la clase de manejo de redimensionamiento
            //ResizeHandler resizeHandler = new ResizeHandler(this);

            // Redimensionar el formulario al tamaño de la pantalla al inicio
            //resizeHandler.ResizeToScreen();

            // Suscribirse al evento Resize del formulario
            //this.Resize += new EventHandler(resizeHandler.Form_Resize);
        }
    }
}
