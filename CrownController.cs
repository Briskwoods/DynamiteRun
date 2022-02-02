using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CrownController : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_playerCrown;

    public List<GameObject> m_enemyRunners;
    public List<GameObject> m_runnerCrowns;

    [SerializeField] private Transform finishLine;

    private float playerdistance;
    private List<float> runnerdistance;
    public List<GameObject> AllCharacter = new List<GameObject>();
    public TextMeshProUGUI Position;
    public TextMeshProUGUI Position_suffix;

    private void Start()
    {
        m_enemyRunners = CodeManager.Instance.RunnerObjects_.m_RunnerObjects;
        m_runnerCrowns = CodeManager.Instance.RunnerObjects_.m_RunnerCrowns;
        runnerdistance = CodeManager.Instance.RunnerObjects_.m_RunnerDistance;

        AllCharacter = m_enemyRunners.ToList();
        AllCharacter.Add(m_player);

        Invoke("Search", 0.01f);        
        InvokeRepeating("RepeatCheckPosition", 0.01f, 0.01f);
    }

    //Evans - an easier way to getting the position of all characters that will allow us to name 1st, 2nd etc positions on the UI
    public void RepeatCheckPosition()
    {
        if (finishLine)
        {
            List<GameObject> newList = AllCharacter.OrderByDescending(e => (finishLine.position - e.transform.position).z).Reverse().ToList();
            AllCharacter = newList;

            int pos = AllCharacter.IndexOf(m_player) + 1;
            Position.SetText(pos.ToString());
            Position_suffix.SetText(GetOrdinalSuffix(pos));


            for (int i = 0; i < AllCharacter.Count(); i++)
            {
                AllCharacter[i].GetComponent<CrownObject>().m_crown.SetActive(false);
            }

            AllCharacter[0].GetComponent<CrownObject>().m_crown.SetActive(true);

        }
    }

    //Evans - This allows us after we have  gotten the player pos above, to get the suffix of the position (th, st, rd etc)
    private string GetOrdinalSuffix(int num)
    {
        string number = num.ToString();
        if (number.EndsWith("11")) return "th";
        if (number.EndsWith("12")) return "th";
        if (number.EndsWith("13")) return "th";
        if (number.EndsWith("1")) return "st";
        if (number.EndsWith("2")) return "nd";
        if (number.EndsWith("3")) return "rd";
        return "th";
    }

    // Update is called once per frame
    void Update()
    {
        //if(finishLine) { playerdistance = Vector3.Distance(m_player.transform.position, finishLine.position); }
           
        //for(int i = 0; i<m_enemyRunners.Count; i++)
        //{

        //    if (finishLine) { runnerdistance[i] = Vector3.Distance(m_enemyRunners[i].transform.position, finishLine.position); }   

        //    switch (playerdistance < runnerdistance[i])
        //    {
        //        case true:
        //            m_playerCrown.SetActive(true);
        //            m_runnerCrowns[i].SetActive(false);
        //            break;
        //        case false:
        //            m_playerCrown.SetActive(false);
        //            m_runnerCrowns[i].SetActive(true);
        //            break;
        //    }


        //    if (i + 1 < runnerdistance.Count)
        //    {
        //        switch (runnerdistance[i] < runnerdistance[i + 1])
        //        {
        //            case true:
        //                m_runnerCrowns[i].SetActive(true);
        //                m_runnerCrowns[i + 1].SetActive(false);
        //                break;
        //            case false:
        //                m_runnerCrowns[i].SetActive(false);
        //                m_runnerCrowns[i + 1].SetActive(true);
        //                break;
        //        }
        //    }
        //}
    }

    void Search()
    {
        finishLine = GameObject.Find("EndGoal").transform;
    }
}
