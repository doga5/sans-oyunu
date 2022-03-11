using System.Collections;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(GetPaintEventHandler1(GetPaintEventHandler()));
        }
        ArrayList sayi = new System.Collections.ArrayList(new int[] { 1, 10, 20, 50, 100, 250, 500, 1000, 2000, 5000, 7500, 10000, 20000, 30000, 50000, 100000, 200000, 300000, 500000, 1000000 });
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Left = j * 55;
                    btn.Top = i * 55;
                    btn.Text = ((i * 10) + (j + 1)).ToString();
                    btn.Click += Btn_Click;
                    panel1.Controls.Add(btn);
                }
            }
        }
        int secilensayi;
        private void Btn_Click(object? sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e, Button secilen)
        {
            Random rnd = new Random();
            int rasgele = rnd.Next(0, Math.Max(sayi.Count, 1));
            secilensayi = Convert.ToInt32(sayi[rasgele]);
            sayi.Remove(secilensayi);
            secilen.Enabled = false;
            secilen.Text = secilensayi.ToString();
            //Geliþme
            int toplam = 0;
            foreach (object x in sayi)
            {
                toplam += (int)x;
            }
            int ortalama = toplam / Math.Max(sayi.Count, 1);
            if (sayi.Count == 1)
            {
                MessageBox.Show(ortalama.ToString() + "TL kazandýnýz, TEBRÝKLER!!!");
                panel1.Visible = false;
            }
            
            label1.Text = ortalama.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label1.Text + "TL kazandýnýz, TEBRÝKLER!!");
            panel1.Visible = false;
        }
    }
}