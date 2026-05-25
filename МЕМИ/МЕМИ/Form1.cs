using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace МЕМИ
{
    public partial class Form1 : Form
    {
       
        private string folderPath = @"C:\Users\skoro\Desktop\Myroslav\Инфа 9 клас\інфа\Меме";
        private string[] memeFiles;
        private int currentIndex = 0;

        private PictureBox pictureBox;
        private Button btnPrev;
        private Button btnNext;

        public Form1()
        {
            Text = "Мемна Галерея (Локальна)";
            Width = 600;
            Height = 500;
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();
            LoadMemeFolder();
        }

        private void InitializeComponents()
        {
            pictureBox = new PictureBox
            {
                Location = new Point(20, 20),
                Size = new Size(540, 360),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            btnPrev = new Button
            {
                Text = "◀ Назад",
                Location = new Point(150, 400),
                Size = new Size(100, 40)
            };
            btnPrev.Click += BtnPrev_Click;

            btnNext = new Button
            {
                Text = "Вперед ▶",
                Location = new Point(330, 400),
                Size = new Size(100, 40)
            };
            btnNext.Click += BtnNext_Click;

            Controls.Add(pictureBox);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
        }

        private void LoadMemeFolder()
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    
                    memeFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                    memeFiles = Array.FindAll(memeFiles, f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"));

                    if (memeFiles.Length > 0)
                    {
                        ShowMeme();
                    }
                    else
                    {
                        MessageBox.Show("Папка порожня! Додайте туди картинки .jpg або .png");
                    }
                }
                else
                {
                    MessageBox.Show($"Не знайдено папку за шляхом: {folderPath}\nБудь ласка, створіть її.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при зчитуванні папки: {ex.Message}");
            }
        }

        private void ShowMeme()
        {
            try
            {
                
                if (pictureBox.Image != null) pictureBox.Image.Dispose();

                
                pictureBox.Image = Image.FromFile(memeFiles[currentIndex]);
            }
            catch
            {
                MessageBox.Show("Не вдалося відкрити файл картинки.");
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (memeFiles == null || memeFiles.Length == 0) return;

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = memeFiles.Length - 1;

            ShowMeme();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (memeFiles == null || memeFiles.Length == 0) return;

            currentIndex++;
            if (currentIndex >= memeFiles.Length)
                currentIndex = 0;

            ShowMeme();
        }
    }
}

