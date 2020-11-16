using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : TurnActor
{
    GridMovement mover;
    public HealthBar healthBar;
    public float damage;
    public int maxHp;
    public static Player Instance { get; private set; }
    public AudioSource punch;
    public AudioSource takeDamage;

    private void Awake()
    {
        Instance = this;
    }
    protected override void Start()
    {
        mover = GetComponent<GridMovement>();
        base.Start();
        healthBar.maxConcreteHPValue = maxHp;
    }

    public override IEnumerator Act()
    {
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            if (Input.GetKeyDown(KeyCode.W)) 
            { if (mover.Move(Vector2.up)) { break; }
            else
                { yield return StartCoroutine(Attack(Vector2.up)); break; }

            }
            if (Input.GetKeyDown(KeyCode.S)) 
            { 
                if (mover.Move(Vector2.down)) { break; }
                else
                { yield return StartCoroutine(Attack(Vector2.down)); break; }
            }
            if (Input.GetKeyDown(KeyCode.A)) 
            { 
                if (mover.Move(Vector2.left)) { break; }
                else
                { yield return StartCoroutine(Attack(Vector2.left)); break; }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (mover.Move(Vector2.right)) { break; }
                else
                { 
                    yield return StartCoroutine(Attack(Vector2.right)); break; 
                }
            }
            yield return null;
        }
        initiative += TurnManager.Instance.GetLastActorInitiative();
        yield return null;
    }

    IEnumerator Attack(Vector2 dir)
    {
        //play attack animation here
        yield return null;
        if(!GridManager.Instance.IsWithinBounds(mover.GridPosition + dir)) { yield break; }

        punch.Play();
        foreach(GridObject g in GridManager.Instance.grid[(int)mover.GridPosition.x + (int)dir.x, (int)mover.GridPosition.y + (int)dir.y])
        {
            g.GetComponent<Damagable>()?.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        healthBar.ConcreteHPValue -= damage;
        takeDamage.Play();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.Instance.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Win"))
        {
            GameManager.Instance.Win();
        }
    }
}
