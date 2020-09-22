using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mousePos;
    Vector3 clickPos;
    public float speed;
    public int can = 100;
    TimeManager timeManager;
    public GameObject Panel;

    void Start()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        clickPos = Vector3.zero;
        Panel.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.gameOver && !GameManager.baslangic)
        {
            Movement();
        }

        HealthtBar();
    }

    public void Movement()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            clickPos = mousePos;
            clickPos.z = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, clickPos, speed * Time.deltaTime);
    }

    public void HealthtBar()
    {
        if (can >= 0)
        {
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(can / 100f, 1);
        }

        if (can <= 60 && can > 20)
        {
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (can <= 20)
        {
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Skill")
        {
            can -= 20;

            if (can == 0)
            {
                Panel.SetActive(true);
                GameManager.gameOver = true;
                timeManager.TimeSave();
            }
        }
    }
}
