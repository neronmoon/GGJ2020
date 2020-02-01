using DefaultEcs;

namespace Source.GGJ2020.Messages {
    public enum MovementType {
        Up, Down, Left, Right
    }
    
    public struct MoveMessage {
        public MovementType Type;
    }
}