using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public float speed;
}

public enum State
{
    Stand,
    Run,
    Dead
}

public abstract class Player : MonoBehaviour
{
    public State state = State.Stand;
    public PlayerData playerData = new PlayerData();

    [SerializeField] protected List<Sprite> standSP;
    [SerializeField] protected List<Sprite> runSP;
    [SerializeField] protected List<Sprite> deadSP;

    protected SpriteRenderer spriteRenderer;
    Animation anim;
    [HideInInspector] public float x;
    [HideInInspector] public float y;

    public abstract void Initalize();
    void Update()
    {
        Debug.Log(state);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 ve2 = new Vector3(x, y, 0f);
        transform.position += ve2 * Time.deltaTime * playerData.speed;

        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((x != 0 || y != 0) && state != State.Run)
        {
            state = State.Run;
            GetComponent<SpriteAnimation>().SetSprite(runSP, 0.1f);

        }
        else if (x == 0 && y == 0 && state != State.Stand)
        {
            state = State.Stand;
            GetComponent<SpriteAnimation>().SetSprite(standSP, 0.1f);
        }
    }
}