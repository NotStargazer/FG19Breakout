using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PulseColor : MonoBehaviour
{
    public Gradient gradient;
    public float speedMod;

    SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, $"Missing sprite renderer component on {gameObject.name}");
    }

    private void Update()
    {
        spriteRenderer.color = gradient.Evaluate(Mathf.PingPong(Time.time * speedMod, 1f));
    }
}
