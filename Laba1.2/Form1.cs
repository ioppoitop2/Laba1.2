using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1._2
{
    public partial class Form1 : Form
    {
        private const string ImagesDirectory = @"C:\Users\Виталя\Desktop\На понедельник\Дорошенко\Прогга\Laba1.2\Pictyre"; // Замените на путь к вашей папке с изображениями

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string query = textBox2.Text;
            if (!string.IsNullOrWhiteSpace(query))
            {
                string imageUrl = await GetRandomImageUrl(query);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    pictureBox2.Load(imageUrl);
                }
                else
                {
                    MessageBox.Show("Изображение не найдено.");
                }
            }
        }

        private async Task<string> GetRandomImageUrl(string query)
        {
            try
            {
                var searchPattern = $"{query}*.jpg";
                var files = Directory.GetFiles(ImagesDirectory, searchPattern);

                if (files.Length > 0)
                {
                    Random rand = new Random();
                    int randomIndex = rand.Next(files.Length);
                    return files[randomIndex]; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            return null;
        }
    }
}
