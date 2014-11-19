namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class MainWindowViewModel : Conductor<IWorkspace>.Collection.OneActive
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IWindowManager windowManager;

        public MainWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator,
            IEnumerable<IWorkspace> workspaces)
        {
            this.windowManager = windowManager;
            this.eventAggregator = eventAggregator;
            this.Items.AddRange(workspaces);
            var @vm = this.Items.FirstOrDefault(e => e.Name == "Container");
            this.ActivateItem(@vm);
        }
    }
}