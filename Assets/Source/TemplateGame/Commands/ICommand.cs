using DefaultEcs;

namespace Source.TemplateGame.Commands
{
    public interface ICommand
    {
        bool CheckConstraints(Entity entity);
        void Apply(Entity entity);
    }
}