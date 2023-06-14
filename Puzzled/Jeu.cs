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
        private List<PictureBox> picboxesJeu;

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

            picboxesJeu = new List<PictureBox>()
            {
            picBoxJeu1, picBoxJeu2, picBoxJeu3, picBoxJeu4, picBoxJeu5, picBoxJeu6, picBoxJeu7, picBoxJeu8, picBoxJeu9
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
            PictureBox picbox = (PictureBox)sender;
            picbox.Tag = true;
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
            //condition de victoire non fonctionnel
            bool win = true;
            PictureBox img = (PictureBox)sender;
            img.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            PictureBox[] picList = { picBoxJeu1, picBoxJeu2, picBoxJeu3, picBoxJeu4, picBoxJeu5, picBoxJeu6, picBoxJeu7, picBoxJeu8, picBoxJeu9 };
            for (int i = 1; i < 10; i++)
            {
                //if (picList[i].Image != Image.FromFile($"Resources/nemo9p_{i}.png"))
                {
                    win = false;
                }
            }

            ShowImagesInPicboxes(); // Mettre à jour l'affichage des images
        }


        private bool IsImageDisplayedInGame(Image image)
        {
            foreach (PictureBox picboxJeu in picboxesJeu)
            {
                if (picboxJeu.Image == image)
                {
                    return true; // L'image est déjà affichée dans les PictureBox de jeu
                }
            }
            return false; // L'image n'est pas affichée dans les PictureBox de jeu
        }


        private void ShowImagesInPicboxes()
        {
            foreach (PictureBox picbox in picboxes)
            {
                // Vérifier si l'image a été déplacée
                bool dragged = (bool)picbox.Tag;

                // Vérifier si l'image est affichée dans les PictureBox de jeu
                bool displayedInGame = IsImageDisplayedInGame(picbox.Image);

                // Afficher l'image uniquement si elle a été déplacée ou si elle n'est pas présente dans le jeu (pas fonctionnelle)
                if (dragged || displayedInGame)
                {
                    picbox.Visible = false;
                }

                else
                    picbox.Visible = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Modele Modele = new Modele();
            Modele.Show();
        }
    }
}