using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    [SerializeField] Collider2D _collison = null;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector2 playerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;

        int dirX = playerDir.x > 0 ? 1 : -1;
        int dirY = playerDir.y > 0 ? 1 : -1;

        switch(transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                    transform.Translate(Vector3.right * dirX * 40);

                else if (diffY > diffX)
                    transform.Translate(Vector3.up * dirY * 40);

                break;

            case "Enemy":
               
                if (_collison.enabled)
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));

                break;
        }
    }
}
