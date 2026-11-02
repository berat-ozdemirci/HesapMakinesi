namespace HesapMakinesiÖdev;

public partial class Bilimsel : ContentPage
{

    bool yeniGirdi = false;

    double ilkG = 0;
    string islem = "";


    public Bilimsel()
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

        if (BilimselSonuc.Text == "0" || yeniGirdi)
        {
            BilimselSonuc.Text = sayi;
            yeniGirdi = false;
        }
        else
        {
            BilimselSonuc.Text = BilimselSonuc.Text + sayi;
        }
    }

    private void CTikla(object sender, EventArgs e)
    {
        BilimselSonuc.Text = "0";
        ilkG = 0;
        islem = "";
        yeniGirdi = false;
    }

    private void IslemTikla(object sender, EventArgs e)
    {
        if (sender is not Button buton)
        {
            return;
        }

        if (double.TryParse(BilimselSonuc.Text, out double sayi))
        {
            ilkG = sayi;
            islem = buton.Text;
            yeniGirdi = true;
        }
    }

    private void Esittir(object sender, EventArgs e)
    {
        if (islem == "")
        {
            return;
        }

        if (!double.TryParse(BilimselSonuc.Text, out double ikinciG))
        {
            return;
        }

        double sonuc = 0;

        if (islem == "+")
        {
            sonuc = ilkG + ikinciG;
        }
        else if (islem == "-")
        {
            sonuc = ilkG - ikinciG;
        }
        else if (islem == "x")
        {
            sonuc = ilkG * ikinciG;
        }
        else if (islem == "÷")
        {
            if (ikinciG == 0)
            {
                BilimselSonuc.Text = "Sıfıra bölünemez";
                islem = "";
                yeniGirdi = true;
                return;
            }

            sonuc = ilkG / ikinciG;
        }

        BilimselSonuc.Text = sonuc.ToString();
        islem = "";
        yeniGirdi = true;
    }

    private void TrigoIslemler(object? sender, EventArgs e)
    {
        if (sender is not Button buton)
        {
            return;
        }

        if (!double.TryParse(BilimselSonuc.Text, out double sayi))
        {
            return;
        }

        double sonuc = 0;

        if (buton.Text == "sin")
        {
            double radyan = sayi * Math.PI / 180;
            sonuc = Math.Sin(radyan);
        }
        else if (buton.Text == "cos")
        {
            double radyan = sayi * Math.PI / 180;
            sonuc = Math.Cos(radyan);
        }
        else if (buton.Text == "tan")
        {
            double radyan = sayi * Math.PI / 180;

            if (Math.Abs(Math.Cos(radyan)) < 0.0000000001)
            {
                BilimselSonuc.Text = "Tanımsız";
                yeniGirdi = true;
                return;
            }

            sonuc = Math.Tan(radyan);
        }
        else if (buton.Text == "log")
        {
            if (sayi <= 0)
            {
                BilimselSonuc.Text = "Geçersiz işlem";
                yeniGirdi = true;
                return;
            }

            sonuc = Math.Log10(sayi);
        }
        else if (buton.Text == "ln")
        {
            if (sayi <= 0)
            {
                BilimselSonuc.Text = "Geçersiz işlem";
                yeniGirdi = true;
                return;
            }

            sonuc = Math.Log(sayi);
        }

        BilimselSonuc.Text = sonuc.ToString();
        yeniGirdi = true;
    }

    private void PiTikla(object sender, EventArgs e)
    {
        BilimselSonuc.Text = Math.PI.ToString();
        yeniGirdi = true;
    }

    private void KareKüpAl(object sender, EventArgs e)
    {
        if (sender is not Button buton)
        {
            return;
        }

        if (!double.TryParse(BilimselSonuc.Text, out double sayi))
        {
            return;
        }

        double sonuc = 0;

        if (buton.Text == "x²")
        {
            sonuc = sayi * sayi;
        }
        else if (buton.Text == "x³")
        {
            sonuc = sayi * sayi * sayi;
        }
        else if (buton.Text == "√x")
        {
            if (sayi < 0)
            {
                BilimselSonuc.Text = "Geçersiz işlem..";
                yeniGirdi = true;
                return;
            }

            sonuc = Math.Sqrt(sayi);
        }
        else if (buton.Text == "1/x")
        {
            if (sayi == 0)
            {
                BilimselSonuc.Text = "Sıfıra bölünemez.";
                yeniGirdi = true;
                return;
            }

            sonuc = 1 / sayi;
        }

        BilimselSonuc.Text = sonuc.ToString();
        yeniGirdi = true;
    }

    private void IsaretDegis(object? sender, EventArgs e)
    {
        if (double.TryParse(BilimselSonuc.Text, out double sayi))
        {
            sayi = -sayi;
            BilimselSonuc.Text = sayi.ToString();
        }
    }
    private void VirgulKoy(object? sender, EventArgs e)
    {
        if (yeniGirdi)
        {
            BilimselSonuc.Text = "0,";
            yeniGirdi = false;
        }
        else if (!BilimselSonuc.Text.Contains(","))
        {
            BilimselSonuc.Text = BilimselSonuc.Text + ",";
        }
    }
    private void YuzdeTikla(object sender, EventArgs e)
    {
        if (double.TryParse(BilimselSonuc.Text, out double sayi))
        {
            double sonuc = sayi / 100;
            BilimselSonuc.Text = sonuc.ToString();
            yeniGirdi = false;
        }
    }

    private void Sil(object? sender, EventArgs e)
    {
        string ekran = BilimselSonuc.Text;

        if (!double.TryParse(ekran, out double sayi))
        {
            BilimselSonuc.Text = "0";
            yeniGirdi = false;
            return;
        }

        if (ekran.Length > 1)
        {
            BilimselSonuc.Text =
                ekran.Substring(0, ekran.Length - 1);

            if (BilimselSonuc.Text == "-")
            {
                BilimselSonuc.Text = "0";
            }
        }
        else
        {
            BilimselSonuc.Text = "0";
        }

        yeniGirdi = false;
    }






}