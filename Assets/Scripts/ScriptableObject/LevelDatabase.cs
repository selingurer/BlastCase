namespace ScriptableObject
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "ScriptableObject/LevelDatabase")]
    public class LevelDatabase : ScriptableObject
    {
        public List<LevelConfig> Levels;
    }
}