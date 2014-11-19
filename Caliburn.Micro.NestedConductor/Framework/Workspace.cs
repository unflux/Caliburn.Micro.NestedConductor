namespace Caliburn.Micro.Nested.Conductors.Framework
{
    public interface IWorkspace
    {
        string Name { get; set; }
    }

    public class Workspace : Screen, IWorkspace
    {
        public string Name { get; set; }
    }
}