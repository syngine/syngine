
namespace Syngine.Input
{
    public interface IInputSubscription
    {
        bool Enabled { get; }

        IInputAction Action { get; }

        bool Unsubscribe();
    }
}