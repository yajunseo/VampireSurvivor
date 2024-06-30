using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector2 playerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        int dirX = GameManager.instance.player.inputVec.x > 0 ? 1 : -1;
        int dirY = GameManager.instance.player.inputVec.y > 0 ? 1 : -1;

        switch(transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                    transform.Translate(Vector3.right * dirX * 40);

                else if (diffY > diffX)
                    transform.Translate(Vector3.up * dirY * 40);

                break;

            case "Enemy":
                break;
        }
    }
}
