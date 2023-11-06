using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuelEnemyScript : MonoBehaviour
{
<<<<<<< HEAD
   [SerializeField] private GameObject Block;
    [SerializeField] private GameObject Attack;
    [SerializeField] private GameObject Parry;

    public Coroutine DuelEnemyRef;
    
=======
    public GameObject Block;
    public GameObject Attack;
    public GameObject Parry;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    int playerHP = 2;
    int enemyHP = 2;

    //Text for instructions, the player's lives, and a time
    //use this 
    public TMP_Text livesText;
    public TMP_Text timerText;
    public TMP_Text enemyLivesText;
    private float gameDuration = 30f;
    private float timer = 0f;
    private bool isRunning = false;

>>>>>>> 37ba136b424cb226bae5955bf882c9bfc4f41795
    // Start is called before the first frame update
    void Start()
    {
        Block.SetActive(false);
        Parry.SetActive(false);
        Attack.SetActive(false);
        InputSystem.DisableDevice(Keyboard.current);

        //Start the coroutine defined below named EnemyCoroutine.
        StartCoroutine(EnemyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyCoroutine()
    {
        int playerHP = 2;
        int enemyHP = 2;
        
        int rand = Random.Range(1, 6);

   
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(rand);

        int rand2 = Random.Range(1, 4);
        if (rand2 == 1)
        {
            StabAttack();
        }
        else if (rand2 == 2)
        {
            HeavyAttack();
        }
        else if (rand2 == 3)
        {
            GuardDown();
        }

        InputSystem.DisableDevice(Keyboard.current);

        if (rand2 == 1)
        {
            if (DidBlock() == true && Block.activeSelf == true)
            {

            }
            else
            {
                playerHP -= 1;
            }
        }
        else if (rand2 == 2)
        {
            if (DidParry() == true && Parry.activeSelf == true)
            {

            }
            else
            {
                playerHP -= 1;
            }
        }
        else if (rand2 == 3)
        {
            if (DidAttack() == true && Attack.activeSelf == true)
            {
                enemyHP -= 1;
            }
            else
            {

            }
        }

        yield return new WaitForSeconds(2);
        InputSystem.DisableDevice(Keyboard.current);


    }

    private void StabAttack()
    {
        if (Block.activeSelf == true)
        {
            Block.SetActive(false);
        }
        else
        {
            Block.SetActive(true);
        }
    }

    private void HeavyAttack()
    {
        if (Parry.activeSelf == true)
        {
            Parry.SetActive(false);
        }
        else
        {
            Parry.SetActive(true);
        }
    }

    private void GuardDown()
    {
        if (Attack.activeSelf == true)
        {
            Attack.SetActive(false);
        }
        else
        {
            Attack.SetActive(true);
        }
    }

    private bool DidBlock()
    {
        bool pressedA = false;
        if (Input.GetKeyDown(KeyCode.A))
        {
            pressedA = true;
        }

        return pressedA;
    }

    private bool DidParry()
    {
        bool pressedF = false;
        if (Input.GetKeyDown(KeyCode.F))
        {
            pressedF = true;
        }

        return pressedF;
    }

    private bool DidAttack()
    {
        bool pressedBar = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressedBar = true;
        }

        return pressedBar;
    }
}
