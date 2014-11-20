namespace Caliburn.Micro.Nested.Conductors.Framework
{
    using System;

    public interface IWorkspaceProvider
    {
        T Make<T>() where T : IOperationWorkspace;
    }

    public class WorkspaceProvider : IWorkspaceProvider
    {
        public T Make<T>() where T : IOperationWorkspace
        {
            return Activator.CreateInstance<T>();
        }
    }
}