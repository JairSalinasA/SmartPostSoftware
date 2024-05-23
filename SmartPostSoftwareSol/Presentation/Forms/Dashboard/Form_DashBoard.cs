using System;
using System.Drawing;
using System.Windows.Forms;
using Presentation.Helps;

namespace Presentation.Forms.Dashboard
{
    public partial class Form_DashBoard : Form
    {
        public Form_DashBoard()
        {
            InitializeComponent();
            // Suscribir eventos Paint para los paneles con sombra
            Style.SuscribirEventosPaint(panel_caja,panel_abonos,panel_Entradas,panel_Salidas);
            // Agrega más paneles aquí si es necesario
        }
    }
}
