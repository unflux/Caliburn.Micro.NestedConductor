namespace Caliburn.Micro.Nested.Conductors.Framework
{
    using System.Collections.Generic;
    using Caliburn.Micro.Nested.Conductors.ViewModels;

    public interface INestedConductorProvider
    {
        NestedConductorViewModel Make();
    }

    public class NestedConductorProvider : INestedConductorProvider
    {
        public IEnumerable<IWorkspace> Workspaces { get; set; }

        public NestedConductorViewModel Make()
        {
            return new NestedConductorViewModel(this.Workspaces);
        }
    }
}