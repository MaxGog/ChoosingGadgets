using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ChoosingGadgets.Behaviors;

public class RadioButtonCheckedBehavior : Behavior<RadioButton>
{
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RadioButtonCheckedBehavior));

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(RadioButtonCheckedBehavior));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    protected override void OnAttachedTo(RadioButton bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.CheckedChanged += OnCheckedChanged;
    }

    protected override void OnDetachingFrom(RadioButton bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.CheckedChanged -= OnCheckedChanged;
    }

    private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Command != null && e.Value && Command.CanExecute(CommandParameter))
        {
            Command.Execute(CommandParameter);
        }
    }
}