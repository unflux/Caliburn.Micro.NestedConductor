namespace Caliburn.Micro.Nested.Conductors.Framework
{
    using Caliburn.Micro.Nested.Conductors.ViewModels;

    public interface INestedConductorProvider
    {
        NestedConductorViewModel Make();
    }

    public class NestedConductorProvider : INestedConductorProvider
    {
        private readonly IWorkspaceProvider operationWorkspaceProvider;

        public NestedConductorProvider(IWorkspaceProvider operationWorkspaceProvider)
        {
            this.operationWorkspaceProvider = operationWorkspaceProvider;
        }

        public NestedConductorViewModel Make()
        {
            return new NestedConductorViewModel(this.operationWorkspaceProvider);
        }
    }
}