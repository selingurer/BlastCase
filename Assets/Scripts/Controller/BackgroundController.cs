using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSprite;

    void Start()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        float worldHeight = Camera.main!.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;

        Vector2 spriteSize = backgroundSprite.sprite.bounds.size;

        transform.localScale = new Vector3(
            worldWidth / spriteSize.x,
            worldHeight / spriteSize.y,
            1f
        );
    }

}