using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // public Transform t;
    public Rigidbody rb;
    public Camera cam;

    public float turnSpeed = 50f;
    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 10.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 0.001f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 0.10f;        // Max Acceleration
    public float _MinAcc = -0.10f;       // Min Acceleration

    private GameObject test;
    private void Start()
    {
        test = GameObject.Find("tabPanel");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Debug.Log("aaa");
            if (!test.activeInHierarchy) test.SetActive(true);
        }
        else
        {
            if (test.activeInHierarchy) test.SetActive(false);
        }

        if (Input.GetMouseButton(0)) // augmente l'accélération
        {
            if (_Acc <= _MaxAcc) _Acc += _AccSpeed;
            else _Acc = _MaxAcc;
            _Velocity += _Acc;
            if (_Velocity > _MaxVelocity)
            {
                _Velocity = _MaxVelocity;
                _Acc = 0;
            }
        }

        if (Input.GetMouseButton(1)) //diminue l'accélération
        {
            if (_Acc >= _MinAcc) _Acc -= _AccSpeed;
            else _Acc = _MinAcc;
            _Velocity += _Acc;
            if (_Velocity < 0)
            {
                _Velocity = 0;
                _Acc = 0;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // déplacements haut bas gauche droite
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.down, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) // stop
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //zoom up 
        {
            cam.transform.Translate(0, 0, 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // zoom down
        {
            cam.transform.Translate(0, 0, -1);
        }

        transform.Translate(0, 0, _Velocity * Time.deltaTime, Space.Self);
    }

    public Transform getPlayerPos()
    {
        return transform;
    }
    private void OnCollisionEnter(Collision c)
    {
        Debug.Log("collision avec"+c.collider.name);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger avec" + other.name);
    }

    private void OnCollisionExit(Collision c)
    {
        Debug.Log("sortie");
    }
}