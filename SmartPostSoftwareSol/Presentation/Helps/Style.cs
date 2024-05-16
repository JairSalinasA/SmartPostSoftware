using FontAwesome.Sharp;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms; // Importa el namespace de los controles de Windows Forms

namespace Presentation.Helps
{
    public class Style
    {
        //Fields 
        public static void SuscribirEventosPaint(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.Paint += Panel1_Paint;
            }
        }

        private static void Panel1_Paint(object sender, PaintEventArgs e)
        {
            System.Windows.Forms.Panel panel = sender as System.Windows.Forms.Panel; // Usa System.Windows.Forms.Panel
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, panel.Height - 20), // Punto de inicio de la sombra
                new Point(0, panel.Height),      // Punto final de la sombra
                Color.FromArgb(50, Color.Black), // Color de inicio (transparente)
                Color.Transparent))              // Color final (transparente)
            {
                e.Graphics.FillRectangle(brush, new Rectangle(0, panel.Height - 20, panel.Width, 20)); // Dibujamos la sombra
            }
        }
         
    }
}
