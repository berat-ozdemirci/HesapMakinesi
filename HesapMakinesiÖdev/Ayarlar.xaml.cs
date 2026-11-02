namespace HesapMakinesiÖdev
{
    public partial class Ayarlar : ContentPage
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void AcikTema(object sender, EventArgs e)
        {
            Application.Current!.UserAppTheme = AppTheme.Light;
            Preferences.Set("Tema", "Acik");
        }

        private void KoyuTema(object sender, EventArgs e)
        {
            Application.Current!.UserAppTheme = AppTheme.Dark;
            Preferences.Set("Tema", "Koyu");
        }
        private void SistemTeması(object? sender, EventArgs e)
        {
            Application.Current!.UserAppTheme = AppTheme.Unspecified;
            Preferences.Set("Tema", "Sistem");
        }
    }
}