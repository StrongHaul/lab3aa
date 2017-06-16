using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]        // позволяет изменять значение переменной в юнити
    private float speed = 5f;

    [SerializeField] private float lookspeed = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float xMow = Input.GetAxisRaw("Horizontal");
        float zMow = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right * xMow;
        Vector3 movVer = transform.forward * zMow;
        Vector3 velocity = (movHor + movVer).normalized * speed;
        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookspeed;
        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookspeed;
        motor.RotateCam(camRotation);
    }
}
