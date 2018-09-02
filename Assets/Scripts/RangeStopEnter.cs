using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeStopEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RangeStop"))
        {
            transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<EnemyAITeste>().StopEnter = false;
    }
}
