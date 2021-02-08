using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float pushForce;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(Input.touches.Length > 0)
        {
            if (Input.GetTouch(0).position.x < Camera.main.WorldToScreenPoint(transform.position).x)
            {
                movementVector.x--;
            }
            if (Input.GetTouch(0).position.x > Camera.main.WorldToScreenPoint(transform.position).x)
            {
                movementVector.x++;
            }
            if (Input.GetTouch(0).position.y < Camera.main.WorldToScreenPoint(transform.position).y)
            {
                movementVector.z--;
            }
            if (Input.GetTouch(0).position.y > Camera.main.WorldToScreenPoint(transform.position).y)
            {
                movementVector.z++;
            }
        }
        rb.AddForce(movementVector * pushForce);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
    }
}
