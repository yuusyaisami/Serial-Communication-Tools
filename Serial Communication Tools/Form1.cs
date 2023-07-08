using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Communication_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mainScene1_Load(object sender, EventArgs e)
        {

        }

        private void MainSceneBtn_Click(object sender, EventArgs e)
        {
            MainScene.Visible = true;
        }

        private void ControllerBtn_Click(object sender, EventArgs e)
        {
            MainScene.Visible = false;
        }
    }
}
