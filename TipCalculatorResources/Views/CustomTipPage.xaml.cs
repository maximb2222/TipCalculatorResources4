using Microsoft.Maui.Controls;

namespace TipCalculatorResources.Views;

public partial class CustomTipPage : ContentPage
{
    public CustomTipPage()
    {
        InitializeComponent();
        billInput.TextChanged += OnTextChanged;
        tipPercentSlider.ValueChanged += OnSliderChanged;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Calculate();
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        Calculate();
    }

    private void Calculate()
    {
        if (double.TryParse(billInput.Text, out double bill))
        {
            double percent = tipPercentSlider.Value;
            double tip = bill * percent / 100;
            double total = bill + tip;

            tipValue.Text = tip.ToString("F2");
            totalOutput.Text = total.ToString("F2");
        }
        else
        {
            tipValue.Text = "0.00";
            totalOutput.Text = "0.00";
        }
    }
}