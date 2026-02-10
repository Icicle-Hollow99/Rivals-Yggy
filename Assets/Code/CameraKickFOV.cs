using UnityEngine;

public class CameraFOVKick : MonoBehaviour
{
    public Camera cam;
    public float kickAmount = 5f;
    public float returnSpeed = 10f;

    float baseFOV;

    void Start()
    {
        if (!cam)
            cam = GetComponent<Camera>();

        baseFOV = cam.fieldOfView;
    }

    void Update()
    {
        cam.fieldOfView = Mathf.Lerp(
            cam.fieldOfView,
            baseFOV,
            Time.deltaTime * returnSpeed
        );
    }

    public void Kick()
    {
        cam.fieldOfView = baseFOV + kickAmount;
    }
}
