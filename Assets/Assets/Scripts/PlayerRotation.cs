using Bran;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float mouseSens = 1f;
    [SerializeField] private float upDownRange = 80.0f;
    private float verticalRotation;

    private InputReader input;

    private Camera mainCamera;

    private void Start()
    {
        input = InputReader.Instance;
    }

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    public void Rotation()
    {
        float mouseXRotation = input.LookInput.x * mouseSens;
        transform.Rotate(0, mouseXRotation, 0);


        verticalRotation -= input.LookInput.y * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

}
