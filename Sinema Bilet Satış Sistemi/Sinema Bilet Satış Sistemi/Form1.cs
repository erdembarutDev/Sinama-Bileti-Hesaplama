using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Bilet_Satış_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name_surname, movie, session, ticket;
            string old = "";
            float number_of_ticket;
            float result = 0;
            float adim1 = 0, adim2 = 0, adim3 = 0;

            name_surname = textBox1.Text;
            ticket = textBox2.Text;
            number_of_ticket = float.Parse(ticket);
            movie = comboBox1.SelectedItem.ToString().Trim();
            session = comboBox2.SelectedItem.ToString().Trim();

            // Film Türü Seçimi
            if (movie == "Aksiyon")
            {
                result = 100 * number_of_ticket;
            }
            else if (movie == "Komedi")
            {
                result = 90 * number_of_ticket;
            }
            else if (movie == "Korku")
            {
                result = 95 * number_of_ticket;
            }
            else if (movie == "Animasyon")
            {
                result = 85 * number_of_ticket;
            }

            adim1 = result;  // Film ücreti kaydet

            // Yaş Seçimi
            if (radioButton1.Checked)
            {
                result = result - (result * 50 / 100);
                old = "Çocuk";
            }
            else if (radioButton2.Checked)
            {
                result = result - (result * 40 / 100);
                old = "Genç";
            }
            else if (radioButton3.Checked)
            {
                old = "Yetişkin";
            }
            else if (radioButton4.Checked)
            {
                result = result - (result * 30 / 100);
                old = "Yaşlı";
            }

            adim2 = result;  // Yaş indirimi sonrası kaydet

            // Seans İndirimi
            if (session == "10:00")
            {
                result = result - (result * 20 / 100);
            }
            else if (session == "13:00")
            {
                result = result - (result * 10 / 100);
            }

            adim3 = result;  // Seans indirimi sonrası kaydet

            // Toplu Bilet İndirimi
            if (number_of_ticket >= 3 && number_of_ticket <= 5)
            {
                result = result - (result * 5 / 100);
            }
            else if (number_of_ticket >= 6)
            {
                result = result - (result * 10 / 100);
            }

            float adim4 = result;  // Toplu bilet sonrası

            // Mısır ve İçecek
            float misir = 0, icecek = 0;
            if (checkBox1.Checked)
            {
                misir = number_of_ticket * 15;
                result = result + misir;
            }
            if (checkBox2.Checked)
            {
                icecek = number_of_ticket * 10;
                result = result + icecek;
            }

            // DETAYLI ÇIKTI
            MessageBox.Show($"=== DEBUG BİLGİLERİ ===\n" +
                            $"Bilet Sayısı: {number_of_ticket}\n" +
                            $"Film: {movie}\n" +
                            $"Yaş: {old}\n" +
                            $"Seans: {session}\n\n" +
                            $"1) Film Ücreti: {adim1} TL\n" +
                            $"2) Yaş İndirimi Sonrası: {adim2} TL\n" +
                            $"3) Seans İndirimi Sonrası: {adim3} TL\n" +
                            $"4) Toplu Bilet Sonrası: {adim4} TL\n" +
                            $"5) Mısır: +{misir} TL\n" +
                            $"6) İçecek: +{icecek} TL\n\n" +
                            $"TOPLAM: {result} TL");
        }
    }
}
