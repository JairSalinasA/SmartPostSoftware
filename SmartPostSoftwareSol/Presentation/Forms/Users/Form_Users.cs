using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Presentation.Forms.Modals;
using Presentation.Forms.Users.Helps; // Importa la clase ResizeHandler

namespace Presentation.Forms.Users
{
    public partial class Form_Users : Form
    {
        public Form_Users()
        {
            InitializeComponent();
            InitializeCustomButton();

        }
        private void InitializeCustomButton()
        {            

            // Personaliza el botón
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.BackColor = Color.FromArgb(40, 167, 69); // Color verde Bootstrap
            iconButton1.ForeColor = Color.White;

            // Asigna el evento Paint al botón
            iconButton1.Paint += new PaintEventHandler(this.IconButton1_Paint);
        }

        private void IconButton1_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Radio de los bordes redondeados
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Crea y muestra el formulario modal
            modal_User_Form modalForm = new modal_User_Form();
            modalForm.ShowDialog();

        }
    }
}
