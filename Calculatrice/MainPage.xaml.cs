using Microsoft.Extensions.Logging.Abstractions;

namespace Calculatrice;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    double premierNombre;
    string operateur;
    bool isResultDisplayed = false;

    private void OnCounterClicked(object sender, EventArgs e)
    {
       if (isResultDisplayed)
        {
            ResultLabel.Text = " ";
            isResultDisplayed = false;
        }
       Button clickedButton = (Button)sender;
       string buttonText = clickedButton.Text;

        if (ResultLabel.Text == " ")
        {
            ResultLabel.Text = buttonText;
        }
        else
        {
            ResultLabel.Text += buttonText;
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = " ";
        HistoryLabel.Text = " ";
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        if (ResultLabel.Text == "Erreur")
        {
            ResultLabel.Text = " ";
        }
        premierNombre = double.Parse(ResultLabel.Text);
        operateur = ((Button)sender).Text;
        ResultLabel.Text = " ";
    }

    private void OnEqualClicked(object sender, EventArgs e)
    {
        if (operateur == null)
        {
            return;
        }
        if (ResultLabel.Text == "Erreur")
        {
            ResultLabel.Text = " ";
            return;
        }
        isResultDisplayed = true;
        double deuxiemeNombre = double.Parse(ResultLabel.Text);
        double resultat = 0;
        switch (operateur)
        {
            case "+":
                resultat = premierNombre + deuxiemeNombre;
                break;
            case "-":
                resultat = premierNombre - deuxiemeNombre;
                break;
            case "×":
                resultat = premierNombre * deuxiemeNombre;
                break;
            case "÷":
                if (deuxiemeNombre != 0)
                {
                    resultat = premierNombre / deuxiemeNombre;
                }
                else
                {
                    ResultLabel.Text = "Erreur";
                    return;
                }
                break;
        }
        ResultLabel.Text = resultat.ToString();
        HistoryLabel.Text = $"{premierNombre} {operateur} {deuxiemeNombre} = {resultat}";
    }
}