using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -30;
    public LogicManager logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.isGameOver)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        
    }
}
