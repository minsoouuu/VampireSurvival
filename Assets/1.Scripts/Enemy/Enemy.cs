using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float damage;
    public float hp;
}

public enum States
{
    Stand,
    Run,
    Hit
}

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private List<Sprite> runSprites;
    [SerializeField] private List<Sprite> deadSprites;
    [SerializeField] private List<Sprite> hitSprites;
    Player player;
    public EnemyData enemyData = new EnemyData();
    States state = new States();
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        state = States.Stand;
    }

    public abstract void Init();

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.Translate(Vector3.left * Time.deltaTime * enemyData.speed);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * enemyData.speed);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        if (player.transform.position.y < transform.position.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime * enemyData.speed);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }

        if ((transform.position.x != 0 || transform.position.y != 0) && state != States.Run)
        {
            state = States.Run;
            GetComponent<SpriteAnimation>().SetSprite(runSprites, 0.1f);
        }
    }
}
