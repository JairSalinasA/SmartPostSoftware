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
        private bool isPanelHidden = false;
        private int panelWidth;
        private int step = 100; // Ajusta este valor para cambiar la velocidad de la animación
        private ToolTip toolTip1; 

        public Home()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Style.SuscribirEventosPaint(panel4);
            leftBorderBtn = new Panel
            {
                Size = new Size(10, iconButton1.Height)
            };
            panel_Menu.Controls.Add(leftBorderBtn);

            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Inicio";

            panelWidth = panel_Menu.Width;

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel_Menu, new object[] { true });

            toolTip1 = new ToolTip
            {
                AutomaticDelay = 100
            };
            toolTip1.SetToolTip(burger_Buttom, "Ocultar Menú");

            this.Resize += Form_Resize;
            AdjustLabelFont();

            timer1 = new Timer
            {
                Interval = 1000
            };
            timer1.Tick += timer1_Tick;
            timer1.Start();

            timer2 = new Timer
            {
                Interval = 15
            };
            timer2.Tick += timer2_Tick;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            AdjustLabelFont();
        }

        private void AdjustLabelFont()
        {
            // Calcular el tamaño de fuente máximo permitido basado en el tamaño actual del formulario
            int maxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 40;

            // Asegurarse de que el tamaño de fuente calculado sea mayor que 0
            if (maxSize > 0)
            {
                // Crear una nueva fuente con el tamaño máximo permitido
                Font newFont = new Font(lblHora.Font.FontFamily, maxSize, FontStyle.Bold);

                // Asignar la nueva fuente a los Labels
                lblHora.Font = newFont;
                lblFecha.Font = newFont;
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = Color.FromArgb(73, 152, 245);
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
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
            currentChildForm?.Close();
            currentChildForm?.Dispose();
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void burger_Buttom_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isPanelHidden)
            {
                panel_Menu.Width += step;
                if (panel_Menu.Width >= panelWidth)
                {
                    panel_Menu.Width = panelWidth;
                    timer2.Stop();
                    isPanelHidden = false;
                    toolTip1.SetToolTip(burger_Buttom, "Ocultar Menú");
                }
            }
            else
            {
                panel_Menu.Width -= step;
                if (panel_Menu.Width <= 0)
                {
                    panel_Menu.Width = 0;
                    timer2.Stop();
                    isPanelHidden = true;
                    toolTip1.SetToolTip(burger_Buttom, "Mostrar Menú");
                }
            }
        }
    }
}
