using System;
using ScriptableObject;
using UnityEngine;

namespace Controller
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GridPlaceableData gridPlaceableData;
        
        private Game.Cube[,] grid;

        private void CreateGrid()
        {
        }

        private void UpdateGrid()
        {
        }
    }
}