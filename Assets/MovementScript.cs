using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float pushForce;
    private Rigidbody rb;
    private float startPress;
    private Vector3 startPressPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementVector += GetDragVector();
        rb.AddForce(movementVector * pushForce);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
    }
    Vector3 GetFollowFingerInput()
    {
        Vector3 returnedVector = Vector3.zero;

        if (Input.touches.Length > 0)
        {
            if (Input.GetTouch(0).position.x < Camera.main.WorldToScreenPoint(transform.position).x)
            {
                returnedVector.x--;
            }
            if (Input.GetTouch(0).position.x > Camera.main.WorldToScreenPoint(transform.position).x)
            {
                returnedVector.x++;
            }
            if (Input.GetTouch(0).position.y < Camera.main.WorldToScreenPoint(transform.position).y)
            {
                returnedVector.z--;
            }
            if (Input.GetTouch(0).position.y > Camera.main.WorldToScreenPoint(transform.position).y)
            {
                returnedVector.z++;
            }
        }
        return returnedVector;
    }
    Vector3 GetDragVector()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPress = Time.time;
            startPressPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float timeDifference = Time.time - startPress;
            Vector2 pullStrength = (Input.mousePosition - startPressPosition) / Screen.dpi;
            var worldDirection = Vector3.forward * pullStrength.y + Vector3.right * pullStrength.x;
            Debug.Log("Mouse Up" + worldDirection / timeDifference);
            return worldDirection / timeDifference;
        }
        return Vector3.zero;
    }
}
