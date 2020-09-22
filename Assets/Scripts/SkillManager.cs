using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject skillPrefab;
    GameObject[] skills;
    Vector3 skillPos;
    int skillIndex = 0;
    float time;
    void Start()
    {
        CreateSkill(5);
        time = (Time.time + 3) + 1; // Time.time + 3 = sürenin başladığı zaman
    }

    void Update()
    {
        if (!GameManager.gameOver && !GameManager.baslangic)
        {
            SpawnSkill();
        }
    }

    public void SpawnSkill()
    {
        if (Time.time > time)
        {
            float randomTime = Random.Range(0.5f, 1.1f);

            float randomTransform = Random.Range(0, 4); // about index for random spawn
            float randomX = Random.Range(-9f, 9f); // about top y = 6 about bot -6
            float randomY = Random.Range(-5f, 5f); // about right x = 9.5 about left -9.5

            switch (randomTransform)
            {
                case 0:
                    skillPos = new Vector2(randomX, 6); // top spawn
                    break;

                case 1:
                    skillPos = new Vector2(randomX, -6); // bot spawn
                    break;

                case 2:
                    skillPos = new Vector2(9.5f, randomY); // right spawn
                    break;

                case 3:
                    skillPos = new Vector2(-9.5f, randomY); // left spawn
                    break;
            }

            skills[skillIndex].SetActive(true);
            skills[skillIndex].transform.position = skillPos;
            skills[skillIndex].GetComponent<SkillScript>().isReactive = true;
            skillIndex++;

            if (skillIndex == skills.Length)
            {
                skillIndex = 0;
            }

            time = Time.time + randomTime;
        }
    }
    private void CreateSkill(int amount)
    {
        skills = new GameObject[amount];

        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = Instantiate(skillPrefab);
            skills[i].SetActive(false);
        }
    }
}
