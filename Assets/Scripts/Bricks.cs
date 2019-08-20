using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    //Public
    [Tooltip("Should we cause the camera to shake if the ball destroys this brick?")]
    public bool causeCameraShake = false;
    public bool isBreakable = true;
    [Tooltip("Should we create a new ball when the ball destryos this brick?")]
    public bool spawnBallOnBreak = false;
    [Tooltip("Number of sprites = number of hits the brick can take")]
    public List<Sprite> sprites = new List<Sprite>();

    public static int bricksDestroyed = 0;

    //Private
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "Failed to find SpriteRenderer component");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBreakable)
        {
            return;
        }

        if (sprites.Count > 0)
        {
            sprites.RemoveAt(0);
            if (sprites.Count > 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                if (causeCameraShake)
                {
                    GameCamera.instance.cameraShake.Shake();
                }
                bricksDestroyed++;
                if (spawnBallOnBreak)
                {
                    Instantiate(GameMode.instance.ballPrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}
