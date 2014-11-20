namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class ContainerViewModel : Conductor<NestedConductorViewModel>.Collection.AllActive, IWorkspace
    {
        private readonly INestedConductorProvider nestedConductorProvider;

        public ContainerViewModel(INestedConductorProvider nestedConductorProvider)
        {
            this.nestedConductorProvider = nestedConductorProvider;
            this.DisplayName = "ContainerView";
        }

        public void AddNestedConductor()
        {
            var @new = this.nestedConductorProvider.Make();
            //this.Items.Add(@new);
            this.ActivateItem(@new);
        }
    }
}