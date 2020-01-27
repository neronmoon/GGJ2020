using DefaultEcs;

namespace Source.GGJ2020.Commands
{
    public interface ICommand
    {
        bool CheckConstraints(Entity entity);
        void Apply(Entity entity);
    }
}