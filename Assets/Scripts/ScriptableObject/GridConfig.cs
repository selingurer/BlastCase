using UnityEngine.Serialization;

namespace ScriptableObject
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "ScriptableObject/GridConfig")]
    public class GridConfig : ScriptableObject
    {
        [FormerlySerializedAs("GridWeight")] public float GridWith;
        public float GridHeight;
        public bool GridSizeAuto;
    }
}

