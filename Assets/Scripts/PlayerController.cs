using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float accelerationSpeed = 45f;
    [SerializeField] float slowDownSpeed = 7f;
    [SerializeField] Transform cameraPosition;
    [SerializeField] Camera mainCamera;
    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float cameraSmooth = 4f;
    [SerializeField] GameObject crosshairTexture;

    private float pitchChangeRate = 0.1f;
    private float pitch = 1;

    private float speed;
    private Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!FindObjectOfType<AudioManager>().IsPlaying("Music"))
            FindObjectOfType<AudioManager>().Play("Music");
        FindObjectOfType<AudioManager>().Play("Engine");
        
        if (crosshairTexture == null)
            crosshairTexture = GameObject.FindGameObjectWithTag("Crosshair");
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        //Press W to accelerate
        if (Input.GetKey(KeyCode.W))
        {
            speed = Mathf.Lerp(speed, accelerationSpeed, Time.time * 3);

            pitch += pitchChangeRate;
            if (pitch > 1.5f)
                pitch = 1.5f;
            FindObjectOfType<AudioManager>().SetPitch("Engine", pitch);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = Mathf.Lerp(speed, slowDownSpeed, Time.time * 3);

            pitch -= pitchChangeRate;
            if (pitch < 0.5f)
                pitch = 0.5f;
            FindObjectOfType<AudioManager>().SetPitch("Engine", pitch);
        }
        else
        {
            speed = Mathf.Lerp(speed, normalSpeed, Time.time * 3);

            if (pitch > 0.4f && pitch < 1f)
                pitch += pitchChangeRate;
            if (pitch > 1f && pitch < 1.6f)
                pitch -= pitchChangeRate;
            FindObjectOfType<AudioManager>().SetPitch("Engine", pitch);
        }
      
        Vector3 moveDirection = new Vector3(0, 0, speed);
        moveDirection = transform.TransformDirection(moveDirection);
        r.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        //------------------------
        //     Camera follow
        //------------------------
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition.position, Time.deltaTime * cameraSmooth);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, cameraPosition.rotation, Time.deltaTime * cameraSmooth);

        //------------------------
        //     Ship Rotation
        //------------------------
        //A and D to roll ship, mouse to change direction
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotationSpeed, Input.GetAxis("Mouse X") * rotationSpeed, -Input.GetAxis("Horizontal") * rotationSpeed) * 1000 * Time.deltaTime, Space.Self);
        //Update crosshair texture
        if (crosshairTexture)
        {
            crosshairTexture.transform.position = mainCamera.WorldToScreenPoint(transform.position + transform.forward * 100);//used so that it only moves on the canvas
        }
    }
}