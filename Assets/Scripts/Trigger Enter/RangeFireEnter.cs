using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFireEnter : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        { 
            this.transform.parent.gameObject.GetComponent<EnemyAITeste>().FireEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        this.transform.parent.gameObject.GetComponent<EnemyAITeste>().FireEnter = false;
    }
}
