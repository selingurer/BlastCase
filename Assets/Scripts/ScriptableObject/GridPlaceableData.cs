using System;
using System.Collections.Generic;
using Game;

namespace ScriptableObject
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "GridPlaceableData", menuName = "ScriptableObject/GridPlaceableData")]
    public class GridPlaceableData : ScriptableObject
    {
      public  List<GridPlaceable> gridPlaces = new List<GridPlaceable>();

    }
}