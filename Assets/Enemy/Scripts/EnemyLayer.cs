using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayer : MonoBehaviour
{
    public LayerMask Enemy;
    public Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((Enemy.value & (1 << collision.gameObject.layer)) > 0)
        {
            // This is an enemy in the same layer
            // Do something here
            Physics2D.IgnoreCollision(col, collision);

        }
        else
        {
            // This is not an enemy in the same layer
            // Allow the enemy to pass through
            Physics2D.IgnoreCollision(col, collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((Enemy.value & (1 << collision.gameObject.layer)) > 0)
        {
            // This is an enemy in the same layer
            // Undo the ignore collision
            Physics2D.IgnoreCollision(col, collision, false);
        }
    }
}
