using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace ScriptableObject
{
    using UnityEngine;

    [Serializable]
    public struct LevelGoalsConfig
    {
        public GoalType Type;
        public int GoalCount;
    }

    public enum GoalType
    {
        BlueCube = 0,
        RedCube = 1,
        PupleCube = 2,
        YellowCube = 3,
        GreenCube = 4,
        Balloon = 5,
    }

    [CreateAssetMenu(menuName = "ScriptableObject/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public List<LevelGoalsConfig> LevelGoals;
        public int MovesCount;
        public int LevelID;
    }
}