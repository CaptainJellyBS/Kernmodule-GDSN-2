using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLoopingEnemy : TurnActor
{
    GridMovement mover;
    public Vector2[] directions;
    public float damage;
    int currentDirection = 0;
    
    protected override void Start()
    {
        mover = GetComponent<GridMovement>();
        base.Start();
    }

    public override IEnumerator Act()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            yield return new WaitForSeconds(0.25f);
        }

        while (true)
        {
            if (mover.Move(directions[currentDirection]))
            {
                yield return null;
                break;
            }
            if(CanAttack(directions[currentDirection]))
            {
                yield return StartCoroutine(Attack(directions[currentDirection]));
                break;
            }
            currentDirection++; currentDirection %= directions.Length;

            yield return null;
        }

        if(GetComponent<Renderer>().isVisible)
        {
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator Attack(Vector2 dir)
    {
        //play attack animation here
        yield return null;
        if (!GridManager.Instance.IsWithinBounds(mover.GridPosition + dir)) { yield break; }

        foreach (GridObject g in GridManager.Instance.grid[(int)mover.GridPosition.x + (int)dir.x, (int)mover.GridPosition.y + (int)dir.y])
        {
            g.GetComponent<Damagable>()?.TakeDamage(damage);
        }
    }

    bool CanAttack(Vector2 dir)
    {
        if (!GridManager.Instance.IsWithinBounds(mover.GridPosition + dir)) { return false; }

        return !GridManager.Instance.grid[(int)mover.GridPosition.x + (int)dir.x, (int)mover.GridPosition.y + (int)dir.y].TrueForAll(obj => !obj.GetComponent<Damagable>());
    }
}
