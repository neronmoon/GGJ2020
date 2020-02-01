using System;
using DefaultEcs;

namespace Source.Common.Extensions {
    public static class WorldExtension {
        public static Entity? FindOne(this World world, Func<EntitySetBuilder, EntitySetBuilder> predicate) {
            return predicate.Invoke(world.GetEntities()).AsSet().First();
        }
    }
}