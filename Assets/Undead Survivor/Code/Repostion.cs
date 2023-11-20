using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repostion : MonoBehaviour
{

    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }    

        Vector3 PlayerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(PlayerPos.x - myPos.x);
        float diffY = Mathf.Abs(PlayerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY) //두 오브젝트의 거리 차이에서 x축이 y축보다 크면 수평 이동
                {
                    transform.Translate(Vector3.right * dirX * 40);
                } else if (diffX < diffY) //두 오브젝트의 거리 차이에서 y축이 x축보다 크면 수직 이동
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                
                break;

            case "Enemy":
                if(coll.enabled) {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}
