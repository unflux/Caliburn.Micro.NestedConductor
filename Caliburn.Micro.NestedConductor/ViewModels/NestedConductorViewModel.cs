﻿namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Diagnostics;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class NestedConductorViewModel : OperationConductor
    {
        private static int count;

        public NestedConductorViewModel(IWorkspaceProvider workspaceProvider)
            : base(workspaceProvider)
        {
            count = count + 1;
            this.DisplayName = "NestedConductorView " + count;
            Debug.WriteLine("*********** Creating NestedConductorView {0} ***********", count);
        }

        private void Display()
        {
            var @vm = this.WorkspaceProvider.Make<OperationViewModel>();
            this.ActivateItem(@vm);
        }

        protected override void OnActivate()
        {
            Debug.WriteLine("*********** Activating NestedConductorView {0} ***********", count);
            this.Display();
            base.OnActivate();
        }
    }
}