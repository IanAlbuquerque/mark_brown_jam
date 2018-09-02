using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFollowEnter : MonoBehaviour {

    public LayerMask wallLayerMask;

    private void Start() {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var posParent = new Vector2(this.transform.parent.position.x,
                                    this.transform.parent.position.y);
        var posCollision = new Vector2(collision.transform.position.x,
                                       collision.transform.position.y);
        var dir = posCollision - posParent;                                
        RaycastHit2D hit = Physics2D.Raycast(posParent + dir.normalized * 0.3f,
                                    dir.normalized,
                                    dir.magnitude,
                                    wallLayerMask);
        if (collision.gameObject.CompareTag("hero") && hit.collider == null)
        {
            this.
            transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().FollowEnter = false;
    }
}
