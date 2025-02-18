using System.Windows.Input;

namespace Emotocool;

public partial class MainPage : ContentPage
{
    int count = 0;
    
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs args)
    {
        EmoCanvas.RedAlpha = Convert.ToInt32(RedSlider.Value);
        EmoCanvas.YellowAlpha = Convert.ToInt32(YellowSlider.Value);
        EmoCanvas.GreenAlpha = Convert.ToInt32(GreenSlider.Value);
        EmoCanvas.CyanAlpha = Convert.ToInt32(CyanSlider.Value);
        EmoCanvas.BlueAlpha = Convert.ToInt32(BlueSlider.Value);
        EmoCanvas.MagentaAlpha = Convert.ToInt32(MagentaSlider.Value);
        EmoteView.Invalidate();
    }
}