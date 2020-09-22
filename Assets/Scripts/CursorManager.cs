using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject cursorPrefab;
    PlayerScript playerScript;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (!GameManager.gameOver && !GameManager.baslangic)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject cursor = Instantiate(cursorPrefab, playerScript.mousePos, Quaternion.identity);
            cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0);
        }
    }
}
