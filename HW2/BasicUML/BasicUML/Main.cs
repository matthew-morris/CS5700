using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicUML
{
    public partial class Main : Form
    {
        private Random random = new Random();
        private Color foregroundColor = new Color();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            BackColor = randomColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foregroundColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            label1.ForeColor = foregroundColor;
        }
    }
}
