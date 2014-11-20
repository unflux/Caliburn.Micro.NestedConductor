namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class MainWindowViewModel : Conductor<IWorkspace>.Collection.OneActive
    {
        public MainWindowViewModel(IEnumerable<IWorkspace> workspaces)
        {
            this.Items.AddRange(workspaces);
            this.DisplayName = "MainWindow";
            this.Display();
        }

        private void Display()
        {
            var @vm = this.Items.FirstOrDefault(e => e.GetType() == typeof (ContainerViewModel));
            this.ActivateItem(@vm);
        }
    }
}