using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CinemachineVirtualCamera followCam;
    public CinemachineFreeLook spiningCam;
    public bool startRotating = false;
    [SerializeField]
    private GameObject Character;
    private Animator characterAnimator;
    public static bool isListEmpty = false;
   
    private void Awake()
    {
         if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
      characterAnimator = Character.GetComponent<Animator>();
    }
    private void Update()
    {
        if (startRotating)
        {
            RotateCam();
        }
    }
    public void OnLevelComplete(int count)
    {
       
        if(CollectablesScript.finishLineCrossed && count <= 1)
        { 
            StopPlayerMovement();
            PlayAnimation("Dancing");
            SwitchCam();
            startRotating = true;
            StartCoroutine(UiManager.instance.OnlevelComplete());
        }
        else if (count <= 1)
        {
            StopPlayerMovement();
            PlayAnimation("Fall");
            StartCoroutine (UiManager.instance.onLevelFail()) ;
        }
        
    }
    public void onMaxStageReached()
    {
        StopPlayerMovement();
        PlayAnimation("Dancing");
        SwitchCam();
        startRotating = true;
        StartCoroutine(UiManager.instance.OnlevelComplete());
    }
   
   
    public void OnMaxlevelScore(bool isMaxScore)
    {
        if (isMaxScore)
        {
            StopPlayerMovement();
            PlayAnimation("Dancing");
            SwitchCam();
            startRotating = true; 
        }
    }
    private void PlayAnimation(string animationName)
    {
        
            characterAnimator.Play(animationName);
      
    }
    public void SwitchCam()
    {
       
        followCam.gameObject.SetActive(false);
        spiningCam.gameObject.SetActive(true);
    }
    public void RotateCam()
    {
        spiningCam.m_XAxis.Value += 0.3f;
    }
    private void StopPlayerMovement()
    {
        PlayerMovementController.instance.forwardMovingspeed = 0;
        PlayerMovementController.instance.horizontalMovementSpeed = 0;
    }

}
