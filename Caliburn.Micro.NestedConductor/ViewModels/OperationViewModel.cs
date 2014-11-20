namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Diagnostics;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class OperationViewModel : OperationWorkspace
    {
        private static int count;

        public OperationViewModel()
        {
            count = count + 1;
            this.DisplayName = "OperationView " + count;
            Debug.WriteLine("*********** Creating OperationView {0} ***********", count);
        }

        protected override void OnActivate()
        {
            Debug.WriteLine("*********** Activating OperationView {0} ***********", count);
            base.OnActivate();
        }
    }
}