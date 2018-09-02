using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeStopEnter : MonoBehaviour
{
    private void Start() {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
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
