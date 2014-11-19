namespace Caliburn.Micro.Nested.Conductors.ViewModels
{
    using System.Diagnostics;
    using Caliburn.Micro.Nested.Conductors.Framework;

    public class AnyViewModel : Workspace
    {
        public AnyViewModel()
        {
            this.Name = "AnyView";
        }

        protected override void OnActivate()
        {
            Debug.WriteLine("*********** AnyView activating ***********");
            base.OnActivate();
        }
    }
}