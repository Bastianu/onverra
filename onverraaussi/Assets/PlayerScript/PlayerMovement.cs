using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform t;
    public Rigidbody rb;
    public Canvas myCanvas;
    public TextMesh tm;
    public Camera cam;

    public float turnSpeed = 50f;

    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 25.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 0.001f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 0.10f;        // Max Acceleration
    public float _MinAcc = -0.10f;       // Min Acceleration


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_Acc <= _MaxAcc)
                _Acc += _AccSpeed;
            else
                _Acc = _MaxAcc;

            _Velocity += _Acc;
        }

        if (Input.GetMouseButton(1))
        {
            if (_Acc >= _MinAcc)
                _Acc -= _AccSpeed;
            else
                _Acc = _MinAcc;

            _Velocity += _Acc;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            t.Rotate(new Vector3(1, 0, 0), -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            t.Rotate(new Vector3(-1, 0, 0), -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            t.Rotate(new Vector3(0, 0, -1), -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            t.Rotate(new Vector3(0, 0, 1), -turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            cam.transform.Translate(0, 0, 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            cam.transform.Translate(0, 0, -1);
        }

        if (_Velocity > _MaxVelocity)
        {
            _Velocity = _MaxVelocity;
            _Acc = 0;
        }

        else if (_Velocity < 0)
        {
            _Velocity = 0;
            _Acc = 0;
        }

        transform.Translate(new Vector3(0, 1, 0) * _Velocity * Time.deltaTime);

        updateSpatialPos(t.position.x, t.position.y, t.position.z);
    }

    void updateSpatialPos(float x, float y, float z)
    {
        tm.text = "x = " + x + " y = " + y + " z =" + z;
        tm.text += "\nspeed = " + _Velocity;
    }

    private void OnCollisionEnter(Collision c)
    {

       /* myCanvas.gameObject.SetActive(true);
        myCanvas.GetComponent<Text>().text = "collision :" + c.collider.ToString();*/
        Debug.Log("collsion");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        _Velocity = 0;
        
    }

    private void OnCollisionExit(Collision c)
    {
        Debug.Log("sortie");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        _Velocity = 0;
    }
}