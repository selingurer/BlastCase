namespace Game
{
    using ScriptableObject;
    using UnityEngine;

    public class Cube : GoalBase, IGridPlaceable
    {
        public override GoalType GoalType { get => goalType; }
    }
}