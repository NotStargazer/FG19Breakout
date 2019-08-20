using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bricks : MonoBehaviour
{
    [Tooltip("Should we cause the camera to shake if the ball hits this brick?")]
    public bool causeCameraShake = false;
    SpriteRenderer sprite;

    void Awake()
    {
     
    }
}
