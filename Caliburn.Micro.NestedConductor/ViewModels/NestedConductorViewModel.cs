namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class NestedConductorViewModel : Conductor<IWorkspace>.Collection.OneActive
    {
        public NestedConductorViewModel(IEnumerable<IWorkspace> workspaces)
        {
            this.Items.AddRange(workspaces);
            this.ActivateItem(this.Items.FirstOrDefault(e => e.Name == "AnyView"));
        }
    }
}