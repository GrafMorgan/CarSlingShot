using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveController : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField] float maxForce;

    Vector3 safeSpot;

    bool isMoving;


    private void MoveCar(float power, float angle)
    {
        if(rigidbody.velocity.y == 0) safeSpot = transform.position;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        Vector3 moveForce = new Vector3(power * maxForce, 0, 0);
        moveForce = Quaternion.Euler(0, angle, 0) * moveForce;
        rigidbody.AddForce(moveForce, ForceMode.Impulse);

        transform.eulerAngles = new Vector3(0, 90+  angle, 0);
        EventManager.ChangeCarRotation(angle+90);
    }

    private void ReturnToTheSpot()
    {
        transform.position = safeSpot;
        transform.eulerAngles = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        EventManager.OnCarMove.AddListener(MoveCar);

        safeSpot = transform.position;
    }

    void Update()
    {
        EventManager.UpdateCamera(transform.position);
        if(transform.position.y<-3)
        {
            ReturnToTheSpot();
        }
    }
}
