using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public float m_speed = 1.0f;                 
    public float m_initialSpeed = 0f;

    [SerializeField] private Animator m_runnerAnim;

    public Vector3 target;
    public Transform[] AllWayPoints;
    int counter = 0;

    [SerializeField] private Rigidbody m_StickToThrow;
    [SerializeField] private Transform m_throwPoint;
    [SerializeField] private float m_throwDelay = 1f;
    [SerializeField] private float Force = 100f;
    [SerializeField] private float m_throwHeight = 100f;

    [Range(1,20)]
    [SerializeField] private int m_difficultyRange = 1;


    [Range(1, 20)]
    [SerializeField] private int m_numberToGuess = 1;

    public int m_guessedNumber;

    private bool playerSeen;                                            // Set to true or false when enemy detects player

    [SerializeField] private Transform m_lineOfSightStart;              // Where the enemies Line of sight begins
    [SerializeField] private Transform m_lineOfSightEnd;                // Where the enemies Line of sight ends

    [SerializeField] private LayerMask m_RunnerLayer;                   // Declare the player layer for Runner detection.

    public bool m_hasThrown = false;
    bool StopLoop = true;
    public bool RandomiseTarget_Bool = false;
    public bool Right = true;
    public bool AlwaysFast = false;

    void Start()
    {
        target = AllWayPoints[counter].position;
        RandomiseTarget();

        m_initialSpeed = m_speed;

        //random speed
        if (!AlwaysFast) { m_speed = m_speed + Random.Range(-20, 20); } else { m_speed = 108; }
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = m_speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 20f && counter < AllWayPoints.Length - 1)
        {
            counter++;
            target = AllWayPoints[counter].position;

            if (!RandomiseTarget_Bool && (counter == 1 || counter == 2))
               { StabilizeTarget(); } else {  RandomiseTarget(); }
        }

        playerSeen = Physics.Linecast(m_lineOfSightStart.position, m_lineOfSightEnd.position, m_RunnerLayer);

        if (playerSeen) { playerSeen = StopLoop; }

        switch (playerSeen)
        {
            case true:
                StopLoop = false;
                StartCoroutine(CheckAfterDelay(m_throwDelay));
                break;
            case false:
                break;
        }


    }

    public void RandomiseTarget()
    {
        target = target + new Vector3(Random.Range(-60, 60), 0f, Random.Range(-60, 60));
    }

    public void StabilizeTarget()
    {
        if (Right)
        {
            target = target + new Vector3(Random.Range(-60, -40), 0f, Random.Range(-60, -40));
        }
        else
        {
            target = target + new Vector3(Random.Range(40, 60), 0f, Random.Range(40, 60));
        }
    }


    public void Throw()
    {
        switch (!m_hasThrown)
        {
            case true:
                m_hasThrown = true;
                StartCoroutine(DelayAfterThrow(m_throwDelay));
                break;
            case false:
            break;
        }
    }

    public void CheckIfCanThrow()
    {
        m_guessedNumber = Random.Range(0, m_difficultyRange + 1);


        switch (m_guessedNumber == m_numberToGuess)
        {
            case true:
                Throw();
                break;
            case false:
                break;
        }
    }

    public int GuessNumber()
    {
        m_guessedNumber = Random.Range(1, m_difficultyRange);
        return m_guessedNumber;
    }

    IEnumerator CheckAfterDelay(float delay)
    {
        CheckIfCanThrow();
        yield return new WaitForSeconds(delay);
        StopLoop = true;
    }

    // Delay before throwing again Coroutine
    IEnumerator DelayAfterThrow(float seconds)
    {

        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        m_StickToThrow = Instantiate(m_StickToThrow, m_throwPoint.transform.position, m_throwPoint.transform.rotation); // Instantiate Stick to throw at hand position        
        m_StickToThrow.AddForce((m_StickToThrow.transform.forward + new Vector3(0, m_throwHeight, 0)) * Force, ForceMode.Impulse);// Add force in the Z direction (forward)        
        m_StickToThrow.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite 
        m_StickToThrow = CodeManager.Instance.StickToThrow_; // Control Variable
        m_hasThrown = false;
    }
}
