using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;

    public float rotationLimit;
    public float currentRotationX;

    Camera mainCamera;
    Rigidbody rid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rid = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();
        CameraRotation();
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        rid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    private void PlayerRotation()
    {
        float rotationY = Input.GetAxisRaw("Mouse X");

        Vector3 playerRotationY = new Vector3(0f, rotationY, 0f) * mouseSensitivity;

        rid.MoveRotation(transform.rotation * Quaternion.Euler(playerRotationY));
    }

    private void CameraRotation()
    {
        float rotationX = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = rotationX * mouseSensitivity;
        currentRotationX -= cameraRotationX;
        currentRotationX = Mathf.Clamp(currentRotationX, -rotationLimit, rotationLimit);

        mainCamera.transform.localEulerAngles = new Vector3(currentRotationX, 0f, 0f);
    }
}
