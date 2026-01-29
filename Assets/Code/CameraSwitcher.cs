using UnityEngine;
using UnityEngine.InputSystem;

public class CameraModeSwitcher : MonoBehaviour
{
    public Transform pivot;

    [Header("Offsets")]
    public Vector3 thirdPersonOffset = new Vector3(0, 0, -6);
    public Vector3 firstPersonOffset = Vector3.zero;

    public float smoothSpeed = 10f;

    bool isFirstPerson = false;
    Vector3 currentOffset;

    void Start()
    {
        currentOffset = thirdPersonOffset;
    }

    // 🔥 CALLED BY INPUT SYSTEM
    void OnSwitchCamera()
    {
        isFirstPerson = !isFirstPerson;
        currentOffset = isFirstPerson ? firstPersonOffset : thirdPersonOffset;
        Debug.Log("CAMERA SWITCH");
        isFirstPerson = !isFirstPerson;
        currentOffset = isFirstPerson ? firstPersonOffset : thirdPersonOffset;
    }

    void LateUpdate()
    {
        if (!pivot) return;

        Vector3 desiredPos = pivot.position + pivot.rotation * currentOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(pivot);
    }
}
