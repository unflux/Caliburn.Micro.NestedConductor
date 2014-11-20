namespace Caliburn.Micro.Nested.Conductors.Framework
{
    public interface IOperationConductor
    {
    }

    public class OperationConductor : Conductor<IOperationWorkspace>.Collection.OneActive, IOperationConductor
    {
        protected readonly IWorkspaceProvider WorkspaceProvider;

        protected OperationConductor(IWorkspaceProvider workspaceProvider)
        {
            this.WorkspaceProvider = workspaceProvider;
        }
    }

    public class OperationWorkspace : Screen, IOperationWorkspace
    {
    }

    public interface IOperationWorkspace
    {
    }
}