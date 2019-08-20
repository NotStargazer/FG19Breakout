using System;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerInput : MonoBehaviour
{
    //private
    Camera playerCamera;
    Flipper leftFlipper;
    Flipper rightFlipper;

    const string leftFlipperName = "Left Flipper";
    const string rightFlipperName = "Right Flipper";
    //public
    public float cameraShakeDecay;

    #region Unity
    void Awake()
    {
        playerCamera = Camera.main;
        leftFlipper = GetFlipper(leftFlipperName);
        rightFlipper = GetFlipper(rightFlipperName);
        Assert.IsNotNull(leftFlipper, "Could not find child: " + leftFlipperName);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        float xPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        leftFlipper.isFlipped = Input.GetButton(leftFlipperName);
        rightFlipper.isFlipped = Input.GetButton(rightFlipperName);
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion

    private Flipper GetFlipper(string flipperName)
    {
        //Transform flipperTransform = transform.Find(flipperName);
        //Assert.IsNotNull(flipperTransform, "Could not find flipper with name: " + flipperName);
        //Flipper flipper = flipperTransform.GetComponent<Flipper>();
        //Assert.IsNotNull(flipper, "Could not find flipper script in gameObject: " + flipperName);

        return transform.Find(flipperName)?.GetComponent<Flipper>();
    }
}
