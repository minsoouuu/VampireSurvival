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

    [SerializeField] private List<Sprite> standSP;
    [SerializeField] private List<Sprite> runSP;
    [SerializeField] private List<Sprite> deadSP;

    SpriteRenderer spriteRenderer;
    Animation anim;

    public abstract void Initalize();
    void Start()
    {

    spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public virtual void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 ve2 = new Vector3(x, y, 0f);
        transform.position += ve2 * Time.deltaTime * playerData.speed;
        float dir = Mathf.Clamp(x, -1, +1);
        if (dir < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteAnimation>().SetSprite(runSP, 0.1f);
        }
        else if(dir > 0.001f)
        {
           GetComponent<SpriteRenderer>().flipX = false;
        }

        if (transform.position.x > 0)
        {
            
        }
       // GetComponent<SpriteAnimation>().SetSprite(standSP, 0.1f);
    }

    
}