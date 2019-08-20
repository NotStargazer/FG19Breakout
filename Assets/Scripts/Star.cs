using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CircleCollider2D))]
public class Star : MonoBehaviour
{
    public LayerMask reactToLayer;
    [Tooltip("Whenever a target is nearby, the pulse speed will increase with the value bellow.")]
    public float pulseSpeedModIncrease;

    private List<GameObject> activeThreatObjects = new List<GameObject>();

    CircleCollider2D awareness;
    PulseColor pulse;
    void Awake()
    {
        awareness = GetComponent<CircleCollider2D>();
        Assert.IsNotNull(awareness, $"Missing circle collider component on gameObject {gameObject.name}");
        pulse = GetComponent<PulseColor>();
        Assert.IsNotNull(awareness, $"Missing PulseColor script on gameObject {gameObject.name}");
    }

    private void Start()
    {
        GameMode.instance.OnStarsAdded();
    }

    private void OnDestroy()
    {
        GameMode.instance.OnStarsRemoved();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activeThreatObjects.Add(collision.gameObject);
        UpdateTarget();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activeThreatObjects.Remove(collision.gameObject);
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (activeThreatObjects.Count > 0)
        {
            SetFasterBlink();
        }
        else
        {
            SetSlowerBlink();
        }
    }

    public void SetFasterBlink()
    {
        if (!(pulse.speedMod > pulseSpeedModIncrease))
            pulse.speedMod += pulseSpeedModIncrease;
    }

    public void SetSlowerBlink()
    {
        if ((pulse.speedMod > pulseSpeedModIncrease))
            pulse.speedMod -= pulseSpeedModIncrease;
    }
}
