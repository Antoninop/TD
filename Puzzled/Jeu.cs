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
    public partial class Jeu : Form
    {
        private List<PictureBox> picboxes;

        public Jeu()
        {
            InitializeComponent();
            InitializePicboxes();
            ShuffleImagesInPicboxes();
        }

        private void InitializePicboxes()
        {
            picboxes = new List<PictureBox>()
            {
                picBox1, picBox2, picBox3, picBox4, picBox5, picBox6, picBox7, picBox8, picBox9
            };
        }

        private void ShuffleImagesInPicboxes()
        {
            List<PictureBox> shuffledPicboxes = new List<PictureBox>(picboxes);
            List<Image> images = new List<Image>(); // Liste des images à mélanger

            Random random = new Random();

            foreach (PictureBox picbox in picboxes)
            {
                if (shuffledPicboxes.Count == 0)
                    break;

                int randomIndex = random.Next(0, shuffledPicboxes.Count);

                PictureBox shuffledPicbox = shuffledPicboxes[randomIndex];

                // Échanger les images entre les PictureBox
                Image tempImage = picbox.Image;
                picbox.Image = shuffledPicbox.Image;
                shuffledPicbox.Image = tempImage;

                shuffledPicboxes.RemoveAt(randomIndex);
            }

            
        }
    }
}