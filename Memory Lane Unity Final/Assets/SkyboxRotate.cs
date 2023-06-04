using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour {

    public float RotateSpeed = 1.1f;

    // Update is called once per frame
    void Update() {
        RenderSettings.skybox.SetFloat ("_Rotation", Time.time * RotateSpeed);
    }
}