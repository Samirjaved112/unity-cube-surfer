using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collected"))
        {
           // StackController.Instance.RemoveCube(collision.gameObject);
        }
    }
}
