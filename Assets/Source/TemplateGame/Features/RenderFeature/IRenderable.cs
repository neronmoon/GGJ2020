using DefaultEcs;

namespace Source.TemplateGame.Features.RenderFeature
{
    public interface IRenderable
    {
        void LinkTo(Entity entity);
        void SetEntity(Entity entity);
        void LinkTo(EntitySetBuilder builder);
        void Render(Entity entity);
        void OnComponentAdded<T>(T component);
        void OnComponentUpdated<T>(T component);
        void OnComponentRemoved<T>();
    }
}