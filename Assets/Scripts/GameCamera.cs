using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static GameCamera instance;

    [System.NonSerialized] public CameraShake cameraShake;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            cameraShake = GetComponent<CameraShake>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
