using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFireEnter : MonoBehaviour {

    private void Start() {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().FireEnter = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
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
