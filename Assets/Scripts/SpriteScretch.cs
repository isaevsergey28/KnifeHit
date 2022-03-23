using UnityEngine;

public class SpriteScretch : MonoBehaviour
{
    void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHeight = topRightCorner.y * 2;

        var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHeight / spriteSize.y;

        transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
    }
}