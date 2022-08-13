using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    protected override void UpdateAction()
    {
        base.UpdateAction();

        Vector3 direction = new Vector3(targetX - transform.position.x, targetY - transform.position.y, 0).normalized;
        transform.position += Constants.BASE_ENEMY_SPEED * Time.deltaTime * direction;
    }
}
