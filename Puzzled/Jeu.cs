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

            picBoxJeu1.AllowDrop = true;
            picBoxJeu2.AllowDrop = true;
            picBoxJeu3.AllowDrop = true;
            picBoxJeu4.AllowDrop = true;
            picBoxJeu5.AllowDrop = true;
            picBoxJeu6.AllowDrop = true;
            picBoxJeu7.AllowDrop = true;
            picBoxJeu8.AllowDrop = true;
            picBoxJeu9.AllowDrop = true;
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

        // Drag and drop 

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {

            PictureBox img = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
                img.DoDragDrop(img.Image, DragDropEffects.Move);
        }

        private void picBoxJeu_DragEnter(object sender, DragEventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void picBoxJeu_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            img.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
    }
}