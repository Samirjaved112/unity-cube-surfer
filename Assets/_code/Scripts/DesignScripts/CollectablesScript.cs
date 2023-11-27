using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public static bool finishLineCrossed= false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && gameObject.CompareTag("Collected"))
        {
           
           StackController.Instance.StackCubes(collision.gameObject);
           collision.transform.gameObject.tag = "Collected";
        }
        else if (collision.gameObject.CompareTag("Hurdle"))
        {
           
            StackController.Instance.RemoveCube(gameObject);
           
        }
       
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {

            finishLineCrossed = true;
        }
        else if (other.gameObject.CompareTag("MaxStage"))
        {
            LevelManager.instance.onMaxStageReached();
        }
    }
}
