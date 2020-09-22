using System.Collections;
using UnityEngine;

public class SkillScript : MonoBehaviour
{
    GameObject player;
    float speed = 12f;
    float direction;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public bool isReactive = true;
    void Update()
    {
        if (isReactive)
        {
            SetDir();
            StartCoroutine(SetActive(false));

            isReactive = false;
        }
        Movement();
    }

    public void SetDir()
    {
        var dir = Camera.main.WorldToScreenPoint(player.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
        direction = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    IEnumerator SetActive(bool setActive)
    {
        yield return new WaitForSeconds(2);

        gameObject.SetActive(setActive);
    }

    public void Movement()
    {
        float cosSin = direction * (Mathf.PI / 180);

        transform.rotation = Quaternion.AngleAxis(direction - 90, Vector3.forward);
        transform.position += new Vector3(speed * Mathf.Cos(cosSin), speed * Mathf.Sin(cosSin), transform.position.z) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
