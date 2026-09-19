using System.Diagnostics;

namespace calculr_inc
{
    public partial class MainPage : ContentPage
    {
        string caminho = Path.Combine(FileSystem.AppDataDirectory, "nota.txt");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AoClicarCalcularImc(object? sender, EventArgs e)
        {
            try
            {
                string pesoTexto = peso.Text ?? "";
                string alturaTexto = altura.Text ?? "";

                double valorPeso = Convert.ToDouble(pesoTexto);
                double valorAltura = Convert.ToDouble(alturaTexto);

                double alturaMetros = valorAltura / 100;

                double imc = valorPeso / (alturaMetros * alturaMetros);

                await DisplayAlert("Resultado do IMC", $"Seu IMC é: {imc:F2}", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await DisplayAlert("Erro", "Preencha o peso e a altura com números antes de calcular!", "OK");
            }
        }

        private void AoClicarNoSalvar(object? sender, EventArgs e)
        {
            string conteudo = NotasEditor.Text ?? "";
            File.WriteAllText(caminho, conteudo);
        }

        private async void AoClicarCarregar(object? sender, EventArgs e)
        {
            try
            {
                string conteudo = File.ReadAllText(caminho);
                NotasEditor.Text = conteudo;
            }
            catch (Exception aquiéonomedavariavel)
            {
                Debug.WriteLine(aquiéonomedavariavel.Message);
                await DisplayAlert("Algum campo não está preenchido", "Tentar de novo", "OK");
            }
        }
    }
}
