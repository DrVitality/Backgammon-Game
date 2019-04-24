using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon_Game
{
    public partial class NoMovesForm : Form
    {
        private bool switchTurn;
        public NoMovesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchTurn = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switchTurn = false;
            this.Close();
        }

        public bool SwitchTurn
        {
            get { return switchTurn; }
            set { switchTurn = value; }
        }

       
    }
}
