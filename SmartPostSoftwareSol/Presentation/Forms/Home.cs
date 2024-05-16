using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Presentation.Forms.Dashboard;
using Presentation.Forms.Inicio;
using Presentation.Helps;

namespace Presentation.Forms
{
    public partial class Home : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public Home()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Style.SuscribirEventosPaint(panel4);
            //leftBorderBtn = new Panel
            //{
            //    Size = new Size(10, 60)
            //};

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(10, iconButton1.Height);
            panel_Menu.Controls.Add(leftBorderBtn);

            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Inicio";
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if ( senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = Color.FromArgb(73, 152, 245);
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            CloseCurrentChildForm();
            currentChildForm = childForm;
            ConfigureChildForm(childForm);
            AddChildFormToPanel(childForm);
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void CloseCurrentChildForm()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }
        }

        private void ConfigureChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
        }

        private void AddChildFormToPanel(Form childForm)
        {
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ButtonColors.color1);
            OpenChildForm(new Form_Inicio());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ButtonColors.color1);
            OpenChildForm(new Form_DashBoard());
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            CloseCurrentChildForm();
            Reset();
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = Color.FromArgb(112, 112, 112);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(112, 112, 112);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private struct ButtonColors
        {
            public static Color color1 = Color.FromArgb(0, 122, 204);
            // Agrega otros colores según sea necesario
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
