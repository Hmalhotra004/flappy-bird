using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicManager logic;
    public bool birdIsAlive = true;
    public AudioSource flapSfx;
    [SerializeField] private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && !logic.isGameOver)
        {
            animator.SetBool("jump",true);
            flapSfx.Play();
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if (myRigidBody.linearVelocityY < 0)
        {
            animator.SetBool("jump", false);
        }

        if (transform.position.y > 17 || transform.position.y < -15) {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
