namespace ChoosingGadgets.Services;

public class NavigationService
{
    public static Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
    {
        return
            routeParameters != null
                ? Shell.Current.GoToAsync(route, routeParameters)
                : Shell.Current.GoToAsync(route);
    }
}