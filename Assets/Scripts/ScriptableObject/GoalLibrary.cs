namespace ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "ScriptableObject/GoalLibrary")]
    public class GoalLibrary : ScriptableObject
    {
        public List<GoalPrefabPair> Prefabs;

        private Dictionary<GoalType, GameObject> _dict;

        public GameObject GetPrefab(GoalType type)
        {
            if (_dict == null)
            {
                _dict = new Dictionary<GoalType, GameObject>();
                foreach (var p in Prefabs)
                    _dict[p.Type] = p.Prefab;
            }

            return _dict[type];
        }
    }

    [Serializable]
    public struct GoalPrefabPair
    {
        public GoalType Type;
        public GameObject Prefab;
    }
}