using UnityEngine;

public class PointGain : MonoBehaviour
{
    [SerializeField]
    GameLogic gamemanager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            WhichWall whichwall = collision.GetComponent<WhichWall>();
            gamemanager.ResetGame(whichwall.wall_no); 
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
