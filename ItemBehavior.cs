using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
   
    public GameBehaviour gameManager;
    
 
    void OnCollisionEnter(Collision collision)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            
            gameManager.Items += 1;
            gameManager.PrintLootReport();

        }
    }
}