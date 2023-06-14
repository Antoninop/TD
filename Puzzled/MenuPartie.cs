using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzled
{
    public partial class MenuPartie : Form
    {
        public MenuPartie()
        {
            InitializeComponent();
        }

        private void MenuPartie_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            Jeu jeu = new Jeu();
            jeu.Show();
        }
    }
}
