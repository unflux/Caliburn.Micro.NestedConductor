namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Collections.ObjectModel;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class ContainerViewModel : Workspace, IHandle<AddNestedConductor>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly INestedConductorProvider nestedConductorProvider;

        private ObservableCollection<NestedConductorViewModel> nestedConductorCollection;

        public ContainerViewModel(IEventAggregator eventAggregator, INestedConductorProvider nestedConductorProvider)
        {
            this.eventAggregator = eventAggregator;
            this.nestedConductorProvider = nestedConductorProvider;
            this.Name = "Container";
        }

        public ObservableCollection<NestedConductorViewModel> NestedConductorCollection
        {
            get { return this.nestedConductorCollection; }
            set
            {
                this.nestedConductorCollection = value;
                this.NotifyOfPropertyChange();
            }
        }

        public void Handle(AddNestedConductor message)
        {
            this.NestedConductorCollection.Add(message.Workspace);
        }

        public void AddNestedConductor()
        {
            var @new = this.nestedConductorProvider.Make();
            if (Equals(this.NestedConductorCollection, null))
            {
                this.NestedConductorCollection = new ObservableCollection<NestedConductorViewModel>();
            }
            this.NestedConductorCollection.Add(@new);
        }
    }

    public class AddNestedConductor
    {
        public NestedConductorViewModel Workspace { get; set; }
    }
}