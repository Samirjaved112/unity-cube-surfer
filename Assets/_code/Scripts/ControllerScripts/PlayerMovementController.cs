 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController instance;
    [SerializeField]
    public float horizontalMovementSpeed;
    [SerializeField]
    private float horizontalLimit;
    private float horizontalValue;
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    public PathCreator pathCreator;
    public float forwardMovingspeed ;
    public float distanceTravelled;
    public GameObject Player;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        Application.targetFrameRate = 60;  
    }

    public void Update()
    {
       
        if (UiManager.isGameStart)
        {
            distanceTravelled += forwardMovingspeed * Time.deltaTime;
            ForwardMovement();
            SetHorizontalMovement();
        }
       
        GetHorizontalValue();
        
    }
    private void ForwardMovement()
    {
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

    }
    public float GetHorizontalValue()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
        return horizontalValue;
    }
   
    public void SetHorizontalMovement()
    {
        float targetPositionX = Player.transform.localPosition.x + GetHorizontalValue() * horizontalMovementSpeed * Time.deltaTime;
         targetPositionX = Mathf.Clamp(targetPositionX, -horizontalLimit, horizontalLimit);
        Vector3 targetPosition = new Vector3(targetPositionX,Player.transform.localPosition.y,Player.transform.localPosition.z);
       Player.transform.localPosition = Vector3.SmoothDamp(Player.transform.localPosition, targetPosition, ref velocity, smoothTime);
     
    }
   
}

