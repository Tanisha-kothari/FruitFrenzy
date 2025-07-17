using TMPro;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
//-7.49->7.5
//Good Apple
{
    public float moveSpeed = 10;
    float xInput;
    public int score = 0;
    public int winScore = 2;
    public TextMeshProUGUI txt;
    public GameObject winText;
    void Start()
    {
    }
    void Update()
    {
        //wraps
        if(transform.position.x < -7.49f)
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }
        else if(transform.position.x > 7.5f)
        {
            transform.position = new Vector2(-7.49f, transform.position.y);
        }

        
    }
    private void FixedUpdate()
    {
        
            xInput = Input.GetAxis("Horizontal");
            transform.Translate(xInput * moveSpeed, 0f, 0f);
        
        if (score >= winScore)
        {
            winText.SetActive(true);
            Application.Quit();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Good Apple")
        {
            score = score + 1;
            Destroy(collision.gameObject);
            txt.text = score.ToString();
        }
        else if (collision.tag == "Bad Apple")
        {
            score = score - 1;
            Destroy(collision.gameObject);
            txt.text = score.ToString();
        }

    }
}
