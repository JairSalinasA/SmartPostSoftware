using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentation.Helps
{
    public class Style
    {
        // Suscribe los eventos Paint de los paneles para redondear bordes y agregar sombra
        public static void SuscribirEventosPaint(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.Paint += Panel_Paint;
                panel.Resize += Panel_Resize; // Para redibujar cuando se redimensione
            }
        }

        // Redondea los bordes del panel y agrega sombra
        private static void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            int radius = 20; // Radio para esquinas redondeadas
            int shadowOffset = 5; // Desplazamiento de la sombra

            // Crear una sombra
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                shadowPath.AddArc(new Rectangle(shadowOffset, shadowOffset, radius, radius), 180, 90);
                shadowPath.AddArc(new Rectangle(panel.Width - radius + shadowOffset, shadowOffset, radius, radius), -90, 90);
                shadowPath.AddArc(new Rectangle(panel.Width - radius + shadowOffset, panel.Height - radius + shadowOffset, radius, radius), 0, 90);
                shadowPath.AddArc(new Rectangle(shadowOffset, panel.Height - radius + shadowOffset, radius, radius), 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(50, Color.Black);
                    shadowBrush.SurroundColors = new Color[] { Color.Transparent };
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Crear los bordes redondeados del panel
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), -90, 90);
                path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
                path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();

                panel.Region = new Region(path);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(Pens.Transparent, path);
            }
        }

        // Redibuja el panel al redimensionar
        private static void Panel_Resize(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.Invalidate(); // Fuerza a que el panel se redibuje
            }
        }
    }
}
