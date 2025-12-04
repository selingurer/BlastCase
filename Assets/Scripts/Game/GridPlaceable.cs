using System;
using UnityEngine;

namespace Game
{
    public class GridPlaceable : MonoBehaviour, IGridPlaceable
    {
        [SerializeField] private GridPlaceableType gridPlaceableType;

        public virtual GridPlaceableType Type
        {
            get => gridPlaceableType;
        }
    }
}