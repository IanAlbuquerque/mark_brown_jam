using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFollowEnter : MonoBehaviour {

    private void Start() {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = false;
    }
}
