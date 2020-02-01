using System;
using DefaultEcs;

namespace Source.Common.Extensions
{
    public static class EntitySetExtension
    {
        public static Entity? First(this EntitySet set)
        {
            if (set.Count > 0) {
                return set.GetEntities()[0];
            }

            return null;
        }
    }
}