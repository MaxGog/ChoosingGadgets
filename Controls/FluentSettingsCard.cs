using Microsoft.Maui.Controls;

namespace ChoosingGadgets.Controls;

public class FluentSettingsCard : ContentView
{
    public static readonly BindableProperty HeaderProperty =
        BindableProperty.Create(nameof(Header), typeof(string), typeof(FluentSettingsCard), 
        default(string), propertyChanged: OnHeaderChanged);
    
    public static readonly BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(View), typeof(FluentSettingsCard), 
        null, propertyChanged: OnContentChanged);
    
    private readonly Label _headerLabel;
    private readonly ContentView _contentContainer;
    private readonly Frame _cardFrame;

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    
    public new View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
    
    public FluentSettingsCard()
    {
        T GetResource<T>(string key, T defaultValue = default)
        {
            if (Application.Current.Resources.TryGetValue(key, out var resource) && resource is T typedResource)
            {
                return typedResource;
            }
            return defaultValue;
        }

        _headerLabel = new Label
        {
            Style = GetResource<Style>("SubtitleTextStyle"),
            TextColor = GetResource<Color>("SystemBaseMediumColor", Colors.Black),
            Margin = new Thickness(0, 0, 0, 12)
        };
        
        _contentContainer = new ContentView();
        
        var cardLayout = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto }
            },
            Padding = new Thickness(16),
            BackgroundColor = GetResource<Color>("SystemAltHighColor", Colors.White),
            MinimumHeightRequest = 50
        };
        
        cardLayout.Add(_headerLabel, 0, 0);
        cardLayout.Add(_contentContainer, 0, 1);
        
        _cardFrame = new Frame
        {
            Content = cardLayout,
            CornerRadius = 8,
            HasShadow = false,
            BorderColor = GetResource<Color>("SystemListLowColor", Colors.LightGray),
            BackgroundColor = Colors.Transparent,
            Padding = 0
        };
        
        base.Content = _cardFrame;
    }
    
    private static void OnHeaderChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FluentSettingsCard card && newValue is string header)
        {
            card._headerLabel.Text = header;
        }
    }
    
    private static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FluentSettingsCard card && newValue is View content)
        {
            card._contentContainer.Content = content;
        }
    }
}