using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour
{
    public float minZoom = 20f;
    public float maxZoom = 80f;
    public float speed = 0.01f;
    public float swipeResist = 100f;
    private CinemachineVirtualCamera vcam;

    private float prevMagnitude = 0;
    private int touchCoount = 0;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        //mouse scroll
        var scrollAction = new InputAction("Scroll", binding: "<Mouse>/scroll");
        scrollAction.Enable();
        scrollAction.performed += ctx => CameraZoom(ctx.ReadValue<Vector2>().y * speed);

        //pinch gensture
        var touch0Contact = new InputAction(
            type: InputActionType.Button,
            binding: "<Touchscreen>/touch0/press"
            );
        touch0Contact.Enable();
        var touch1Contact = new InputAction(
            type: InputActionType.Button,
            binding: "<Touchscreen>/touch1/press"
            );
        touch1Contact.Enable();

        var touch0pos = new InputAction(
            type: InputActionType.Value,
            binding: "<Touchscreen>/touch0/position"
            );
        touch0pos.Enable();
        var touch1pos = new InputAction(
            type: InputActionType.Value,
            binding: "<Touchscreen>/touch1/position"
            );
        touch1pos.Enable();

        touch0Contact.performed += _ =>
        {
            touchCoount++;
        };
        touch1Contact.performed += _ => touchCoount++;
        touch0Contact.canceled += _ =>
        {
            touchCoount--;
            prevMagnitude = 0;
        };
        touch1Contact.canceled += _ =>
        {
            touchCoount--;
            prevMagnitude = 0;
        };

        touch1pos.performed += _ =>
        {
            if (touchCoount < 2)
                return;
            var magnitude = (touch0pos.ReadValue<Vector2>() - touch1pos.ReadValue<Vector2>()).magnitude;
            if (prevMagnitude == 0)
            {
                prevMagnitude = magnitude;
            }
            var diff = magnitude - prevMagnitude;
            prevMagnitude = magnitude;
            CameraZoom(-diff * speed);

        };
    }

    private void CameraZoom(float increment)
    {
        vcam.m_Lens.FieldOfView = Mathf.Clamp(vcam.m_Lens.FieldOfView + increment, minZoom, maxZoom);
    }

}
