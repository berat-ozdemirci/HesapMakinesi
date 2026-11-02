namespace HesapMakinesiÖdev
{
    public partial class MainPage : ContentPage
    {

        double ilkG = 0;
        string islem = "";
        bool yeniGirdi = false;


        public MainPage()
        {
            InitializeComponent();
        }

        private void SayiTikla(object sender, EventArgs e)
        {

            if (sender is not Button buton)
            {
                return;
            }
            string sayi = buton.Text;
            
            if (SonucEkranı.Text == "0" || yeniGirdi)
            {
                SonucEkranı.Text = sayi;
                yeniGirdi = false; 
            }
            else
            {
                SonucEkranı.Text = SonucEkranı.Text + sayi;
            }
        }

        private void IslemTikla(Object sender, EventArgs e)
        {
            if (sender is not Button buton)
            {
                return;
            }

            if (double.TryParse(SonucEkranı.Text, out double sayi))
            {
                ilkG = sayi;
                islem = buton.Text;
                yeniGirdi = true;
            }
        }

        private void Esittir(Object sender, EventArgs e)
        {
            if(islem == "")
            {
                return;
            }

            if (!double.TryParse(SonucEkranı.Text, out double ikinciG))
            {
                return;
            }
            double sonuc = 0;

            if(islem == "+")
            {
                sonuc = ilkG + ikinciG;
            }
            else if(islem == "-")
            {
                sonuc = ilkG - ikinciG;
            }
            else if(islem == "x")
            {
                sonuc = ilkG * ikinciG;
            }
            else if(islem == "÷")
            {
                if(ikinciG == 0)
                {
                    SonucEkranı.Text = "Sıfıra bölünemez.";
                    islem = "";
                    yeniGirdi = true;
                    return;
                }
                sonuc = ilkG / ikinciG;
            }
            SonucEkranı.Text = sonuc.ToString();
            islem = "";
            yeniGirdi = true;

        }

        private void CTiklandi(object sender, EventArgs e)
        {
            SonucEkranı.Text = "0";
            ilkG = 0; ;
            islem = "";
            yeniGirdi = false;
        }

        private void CETiklandi(object sender, EventArgs e)
        {
            SonucEkranı.Text = "0";
            yeniGirdi = false;
        }

        private void Sil(object sender, EventArgs e)
        {
            string MevcutEkran = SonucEkranı.Text;

            if(MevcutEkran.Length > 1)
            {
                SonucEkranı.Text = MevcutEkran.Substring(0, MevcutEkran.Length - 1);
            }
            else
            {
                SonucEkranı.Text = "0";
            }
        }

        private void VirgulTiklandi(object sender, EventArgs e)
        {
            if(yeniGirdi)
            {
                SonucEkranı.Text = "0,";
                yeniGirdi = false;
            }
            else if (!SonucEkranı.Text.Contains(","))
            {
                SonucEkranı.Text = SonucEkranı.Text + ",";
            }
        }

        private void IsaretDegis(object? sender, EventArgs e)
        {
            if (double.TryParse(SonucEkranı.Text, out double sayi))
            {
                sayi = -sayi;
                SonucEkranı.Text = sayi.ToString();
            }
        }

        private void KareAl(object? sender, EventArgs e)
        {
            if(double.TryParse(SonucEkranı.Text,out double sayi))
            {
                double sonuc = sayi * sayi;
                SonucEkranı.Text = sonuc.ToString();
                yeniGirdi = true;
            }
        }
        private void KarekokAl(object sender, EventArgs e)
        {
            if(double.TryParse(SonucEkranı.Text, out double sayi))
            {
                if(sayi < 0)
                {
                    SonucEkranı.Text = "HATA";
                    yeniGirdi =true;
                    return;
                }
                double sonuc = Math.Sqrt(sayi);
                SonucEkranı.Text = sonuc.ToString();
                yeniGirdi = true;

            }
        }


        private void TersiniAl(object? sender, EventArgs e)
        {
            if (double.TryParse(SonucEkranı.Text, out double sayi))
            {
                if (sayi == 0)
                {
                    SonucEkranı.Text = "HATA";
                    yeniGirdi = true;
                    return;
                }

                double sonuc = 1 / sayi;
                SonucEkranı.Text = sonuc.ToString();
                yeniGirdi = true;
            }
        }
        private void YuzdeAl(object? sender, EventArgs e)
        {
            if (double.TryParse(SonucEkranı.Text, out double sayi))
            {
                double sonuc = sayi / 100;
                SonucEkranı.Text = sonuc.ToString();
                yeniGirdi = false;
            }
        }





    }
}
