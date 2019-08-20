using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeMagnitude;

    private Vector3 originalPosition;
    private Coroutine shakeRoutine;
    public bool IsShaking { get { return shakeRoutine == null ? false : true; } }

    private void Awake()
    {
        originalPosition = transform.position;
    }

    public void Shake()
    {
        shakeRoutine = StartCoroutine(PerformShake());
    }

    public void StopShake()
    {
        if (shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
        }
    }

    IEnumerator PerformShake()
    {
        transform.position = originalPosition;
        float elapsedTime = shakeDuration;

        while (elapsedTime > 0)
        {
            Vector3 xy = Random.insideUnitSphere;

            transform.position = (originalPosition + xy * elapsedTime/shakeDuration);

            elapsedTime -= Time.deltaTime;

            yield return null;
        }
        transform.position = originalPosition;
    }
}