using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera fppCamera;
    public Camera tppOverviewCamera;

    public float mouseSensitivity = 300f;
    public Transform playerBody;

    private float xRotation = 0f;
    private bool isFPP = true;

    void Start()
    {
        fppCamera.gameObject.SetActive(true);
        tppOverviewCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFPP = !isFPP;
            fppCamera.gameObject.SetActive(isFPP);
            tppOverviewCamera.gameObject.SetActive(!isFPP);
        }

        if (isFPP)
            FPP_Control();
        else
            TPP_OverviewFollow();
    }

    void FPP_Control()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        fppCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void TPP_OverviewFollow()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Vector3 offset = new Vector3(0, 10f, -10f);
        tppOverviewCamera.transform.position = playerBody.position + offset;
        tppOverviewCamera.transform.LookAt(playerBody);
    }
}
