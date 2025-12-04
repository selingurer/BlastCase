namespace Game
{
    public enum GridPlaceableType
    {
        Blue = 0,
        Green = 1,
        Red = 2,
        Yellow = 3,
        Purple = 4,
        Balloon = 5,
        Rocket = 6
    }
    public interface IGridPlaceable
    {
        public GridPlaceableType Type { get; }
    }
}