using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;

    private bool CanPlaceMonster()
    {
        return monster == null;
    }


    void OnMouseUp()
    {

        if (CanPlaceMonster())
        {

            monster = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);


        }
        else if (CanUpgradeMonster())
        {
            monster.GetComponent<MonsterData>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            // TODO: ???????? ??????
        }
    }

    private bool CanUpgradeMonster()
    {
        if (monster != null)
        {
            MonsterData monsterData = monster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
