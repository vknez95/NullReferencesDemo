using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class ViewLocator: ServiceLocator<ICommandResult, IView>
    {
    }
}
