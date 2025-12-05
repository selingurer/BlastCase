namespace Game
{
    using ScriptableObject;
    using UnityEngine;

    public class Balloon : GoalBase, IGridPlaceable
    {
        public override GoalType GoalType { get => goalType; }
    }
}