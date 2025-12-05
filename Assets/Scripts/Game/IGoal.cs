using ScriptableObject;
using UnityEngine;

namespace Game
{
    public interface IGoal
    {
    }

    public abstract class GoalBase : MonoBehaviour, IGoal
    {
        [SerializeField] public GoalType goalType;

        public abstract GoalType GoalType { get; }
    }
}