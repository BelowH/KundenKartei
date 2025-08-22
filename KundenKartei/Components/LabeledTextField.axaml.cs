using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KundenKartei.Components;

public partial class LabeledTextField : UserControl
{
    
    public static readonly StyledProperty<string> LabelTextProperty =
        AvaloniaProperty.Register<LabeledTextField, string>(nameof(LabelText), "Label:");

    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<LabeledTextField, string>(nameof(Text), string.Empty);

    public static readonly StyledProperty<bool> HasErrorProperty =
        AvaloniaProperty.Register<LabeledTextField, bool>(nameof(HasError), false);

    public static readonly StyledProperty<string> ErrorMessageProperty =
        AvaloniaProperty.Register<LabeledTextField, string>(nameof(ErrorMessage), string.Empty);

    public string LabelText
    {
        get => GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool HasError
    {
        get => GetValue(HasErrorProperty);
        set => SetValue(HasErrorProperty, value);
    }

    public string ErrorMessage
    {
        get => GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }
    
    public LabeledTextField()
    {
        InitializeComponent();
    }
    
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
            
        if (change.Property == HasErrorProperty)
        {
            var textBox = this.FindControl<TextBox>("PART_TextBox");
            if (textBox != null)
            {
                if (HasError)
                    textBox.Classes.Add("error");
                else
                    textBox.Classes.Remove("error");
            }
        }
    }
    
}