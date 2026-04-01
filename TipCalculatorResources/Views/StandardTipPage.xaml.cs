using Microsoft.Maui.Controls;

namespace TipCalculatorResources.Views;

public partial class StandardTipPage : ContentPage
{
    private Color colorNavy = Colors.Navy;
    private Color colorSilver = Colors.Silver;

    public StandardTipPage()
    {
        InitializeComponent();
        billInput.TextChanged += OnBillTextChanged;
    }

    private void OnBillTextChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(billInput.Text, out double bill))
        {
            double tip = bill * 0.15;
            double total = bill + tip;

            tipOutput.Text = tip.ToString("F2");
            totalOutput.Text = total.ToString("F2");
        }
        else
        {
            tipOutput.Text = "0.00";
            totalOutput.Text = "0.00";
        }
    }

    private void OnLight(object sender, EventArgs e)
    {
        Resources["fgColor"] = colorNavy;
        Resources["bgColor"] = colorSilver;
    }

    private void OnDark(object sender, EventArgs e)
    {
        Resources["fgColor"] = colorSilver;
        Resources["bgColor"] = colorNavy;
    }
    private async void OnCustomCalculator(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomTipPage());
    }
}