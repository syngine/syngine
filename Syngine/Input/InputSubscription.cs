namespace Syngine.Input
{
    public class InputSubscription : IInputSubscription
    {
        public bool Enabled
        {
            get
            {
                return Action.Enabled;
            }
            set
            {
                Action.Enabled = value;
            }
        }

        public IInputAction Action { get; internal set; }

        public bool Unsubscribe()
        {
            return Action.Remove();
        }
    }
}