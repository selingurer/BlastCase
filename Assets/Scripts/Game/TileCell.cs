namespace Game
{
    using UnityEngine;

    namespace Game.Grid
    {
        [System.Serializable]
        public class TileCell
        {
            public int Row;         
            public int Col;         
            public Vector2 WorldPos; 
            public GameObject OccupiedObject; // Bu hücrede hangi obje var?

            public TileCell(int row, int col, Vector2 worldPos)
            {
                Row = row;
                Col = col;
                WorldPos = worldPos;
                OccupiedObject = null;
            }

            public bool IsEmpty()
            {
                return OccupiedObject == null;
            }
        }
    }

}