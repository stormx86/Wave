using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave
{
    public delegate void DelegateShow(int x, int y, int number);
    public partial class Wave : Form
    {
        static int size = 20;
        Label [,] box;
        Logic logic;
        public Wave()
        {
            InitializeComponent();
            InitLables();
            logic = new Logic(size, Show);
            logic.init_game();
        }

           
        private void InitLables()
        {
            int w = panel1.Width / size;
            int h = panel1.Height / size;
            box = new Label[size, size];
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    box[x, y] = CreateLable();
                    box[x, y].Size = new System.Drawing.Size(w - 10, h - 10);
                    box[x, y].Location = new Point(x * w + 10, y * h + 10);
                    panel1.Controls.Add(box[x, y]);
                }

        }

        private Label CreateLable()
        {
            Label label = new Label();
            label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            //label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label.Text = "";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }


        public void Show(int x, int y, int number)
        {
            box[x, y].Text = number > 0 && number<30 ? number.ToString() : "";
            if (number == 254) box[x, y].BackColor = Color.LimeGreen;
            if (number == 255) box[x, y].BackColor = Color.DarkOrange;
            if (number == 253) box[x, y].BackColor = Color.DarkOrchid;
            if (number == 0) box[x, y].BackColor = Color.Red;
            if (number == 251) box[x, y].BackColor = Color.Blue;
        }

        private void Wave_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter: 
                    if(!logic.flag)
                    logic.Wave(); break;               
                case Keys.Up: logic.lookup_finish(); break;
                case Keys.Escape: logic.init_game(); break;
                default: break;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
