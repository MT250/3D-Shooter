using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float mouseSensitivity = 5f;
    [SerializeField]
    private float cameraRotationXLimit = 85f;

    private float currentCameraRotationX = 0f;


    [Header("Components")]
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Camera camera;


	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
	}
	
	void Update () {
        //Calculate WASD
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * movementSpeed;
        //Apply velocity
        rigidbody.MovePosition(rigidbody.position + _velocity * Time.deltaTime);

        //Calculate Mouse
        float _yRot = Input.GetAxisRaw("Mouse X");
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * mouseSensitivity;
        float _cameraRotation = _xRot * mouseSensitivity;
        //Apply rotation
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(_rotation));

        currentCameraRotationX -= _cameraRotation;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationXLimit, cameraRotationXLimit);

        camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
	}
}
