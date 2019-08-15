using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerInput : MonoBehaviour
{
    //private
    Camera playerCamera;
    private Flipper leftFlipper;
    private Flipper rightFlipper;

    const string leftFlipperName = "Left Flipper";
    //public

    #region Unity
    void Awake()
    {
        playerCamera = Camera.main;
        leftFlipper = GetFlipper(leftFlipperName);
        Assert.IsNotNull(leftFlipper, "Could not find child: " + leftFlipperName);
    }

    void Update()
    {
        leftFlipper.isFlipped = Input.GetButton(leftFlipperName);
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
