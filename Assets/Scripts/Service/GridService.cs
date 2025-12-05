using Game;
using Game.Game.Grid;
using ScriptableObject;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Controller
{
    public class GridService : IStartable
    {
        const float LEFTPADDING = 0.5f;
        const float RIGHTPADDING = 0.5f;
        const float TOPPADDING = 3;
        const float BOTTOMPADDING = 1;

        private GridConfig gridConfig;
        private RectTransform gridRectTransform;
        private SpriteRenderer gridRenderer;
        private SpriteRenderer cubeRenderer;
        private float finalWidth;
        private float finalHeight;
        
        public TileCell[,] Cells;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public float FinalScale { get; private set; }
        
        [Inject]
        public GridService(GridConfig gridConfig,
            RectTransform gridRectTransform, SpriteRenderer gridRenderer)
        {
            this.gridConfig = gridConfig;
            this.gridRectTransform = gridRectTransform;
            this.gridRenderer = gridRenderer;
        }

        public void Start()
        {
            CalculatorGridSize();
            CreateGrid();
        }

        private void CalculatorGridSize()
        {
            if (!gridConfig.GridSizeAuto)
            {
                Vector2 value = new Vector2(gridConfig.GridWith, gridConfig.GridHeight);
                gridRenderer.size = value;
                gridRectTransform.sizeDelta = value;
                return;
            }

            Camera cam = Camera.main;

            float worldHeight = cam.orthographicSize * 2f;
            float worldWidth = worldHeight * Screen.width / Screen.height;

             finalWidth = worldWidth - (LEFTPADDING + RIGHTPADDING);
             finalHeight = worldHeight - (TOPPADDING + BOTTOMPADDING);

            Vector2 finalSize = new Vector2(finalWidth, finalHeight);

            gridRectTransform.sizeDelta = finalSize;
            gridRenderer.size = finalSize;
        }

        private void CreateGrid()
        {
            float cellW = cubeRenderer.bounds.size.x;
            float cellH = cubeRenderer.bounds.size.y;
            
            Cols = Mathf.FloorToInt(finalWidth / cellW);
            Rows = Mathf.FloorToInt(finalHeight / cellH);

            float scaleW = finalWidth / (Cols * cellW);
            float scaleH = finalHeight / (Rows * cellH);
            FinalScale = Mathf.Min(scaleW, scaleH);

            Cells = new TileCell[Rows, Cols];

            float totalW = Cols * cellW * FinalScale;
            float totalH = Rows * cellH * FinalScale;

            float startX = -totalW / 2f + cellW * FinalScale / 2f;
            float startY = -totalH / 2f + cellH * FinalScale / 2f;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    float x = startX + c * cellW * FinalScale;
                    float y = startY + r * cellH * FinalScale;

                    
                    Cells[r, c] = new TileCell(r, c, new Vector3(x, y));
                }
            }
        }


        private void UpdateGrid()
        {
        }
    }
    
}