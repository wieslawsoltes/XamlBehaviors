using System.Reactive.Disposables;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Xaml.Interactivity;

namespace Avalonia.Xaml.Interactions.Custom;

/// <summary>
/// 
/// </summary>
public class PointerExitedTrigger : RoutedEventTriggerBase
{
    /// <summary>
    /// 
    /// </summary>
    public bool MarkAsHandled { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposables"></param>
    protected override void OnAttached(CompositeDisposable disposables)
    {
        if (AssociatedObject is InputElement element)
        {
            var disposable = element.AddDisposableHandler(
                InputElement.PointerExitedEvent, 
                OnPointerExited, 
                EventRoutingStrategy);
            disposables.Add(disposable);
        }
    }

    private void OnPointerExited(object? sender, PointerEventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }

        e.Handled = MarkAsHandled;
        Interaction.ExecuteActions(AssociatedObject, Actions, e);
    }
}
