using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeStopEnter : MonoBehaviour
{
    public LayerMask wallLayerMask;
    private void Start() {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = false;
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
            transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = true;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnterEnemy = true;
            transform.parent.gameObject.GetComponent<EnemyAITeste>().enemyEntered = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = false;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnterEnemy = false;
        }
    }
}
