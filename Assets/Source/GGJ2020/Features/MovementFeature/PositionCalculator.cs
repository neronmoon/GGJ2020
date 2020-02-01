using UnityEngine;

namespace Source.GGJ2020.Features.MovementFeature {
    public class PositionCalculator {
        public static Vector3 Calculate(Vector2Int pos) {
            return new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0f);
        }
    }
}