namespace Syngine.Graphics
{
    public interface IAnimation
    {
        PlayMode Mode { get; }

        PlayState State { get; }

        void Stop();

        void Pause();

        void Play();
    }
}