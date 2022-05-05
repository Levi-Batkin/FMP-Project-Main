using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoringSystem : MonoBehaviour
{
    private float scorenum, scorenum1, scorenums, scorenums1, scoresnums, scoresnums1;
    [Header("Audio Source")] 
    public AudioSource collect;
    private Ray ray;
    private RaycastHit hit;
    [Header("Vase Progress Bar Objects")] 
    public GameObject vases, vases1, vases2, vases3, vases4; // Objects in Quest Menu - Vases
    [Header("Stones Progress Bar Objects")] 
    public GameObject stones, stones1, stones2, stones3, stones4; // Objects in Quest Menu - Stones
    [Header("Clocks Progress Bar Objects")] 
    public GameObject clocks, clocks1, clocks2, clocks3, clocks4; // Objects in Quest Menu - Clocks
    [Header("Quest Completion Objects")] 
    public GameObject Quest1Complete, Quest2Complete, Quest3Complete; // Objects for the Quest Completion - UI Canvas
    // Start is called before the first frame update
    void Start()
    {
        vases.SetActive(true);
        vases1.SetActive(false);
        vases2.SetActive(false);
        vases3.SetActive(false);
        vases4.SetActive(false);
        stones.SetActive(true);
        stones1.SetActive(false);
        stones2.SetActive(false);
        stones3.SetActive(false);
        stones4.SetActive(false);
        clocks.SetActive(true);
        clocks1.SetActive(false);
        clocks2.SetActive(false);
        clocks3.SetActive(false);
        clocks4.SetActive(false);
        Quest1Complete.SetActive(false);
        Quest2Complete.SetActive(false);
        Quest3Complete.SetActive(false);
        
    }
    private IEnumerator Quest1Completed()
    {
        Quest1Complete.SetActive(true);
        yield return new WaitForSeconds(3);
        Quest1Complete.SetActive(false);
    }
    private IEnumerator Quest2Completed()
    {
        Quest2Complete.SetActive(true);
        yield return new WaitForSeconds(3);
        Quest2Complete.SetActive(false);
    }
    private IEnumerator Quest3Completed()
    {
        Quest3Complete.SetActive(true);
        yield return new WaitForSeconds(3);
        Quest3Complete.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.green);
        if (Input.GetKeyDown("e"))
        {
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
            {
                if (hit.transform.tag == "collectable")
                {
                    collect.Play();
                    scorenum1 = PlayerPrefs.GetFloat("vases");
                    scorenum = scorenum1 + 1f;
                    PlayerPrefs.SetFloat("vases", scorenum);
                    Destroy(hit.transform.gameObject);
                    
                    if( scorenum > 0 )
                    {
                        vases.SetActive(false);
                        vases1.SetActive(false);
                        vases2.SetActive(false);
                        vases3.SetActive(false);
                        vases4.SetActive(false);
                    }
                    
                    if (scorenum == 1f)
                    {
                        vases1.SetActive(true);
                    }
                    if (scorenum == 2f)
                    {
                        vases2.SetActive(true);
                    }
                    if (scorenum == 3f)
                    {
                        vases3.SetActive(true);
                    }
                    if (scorenum == 4f)
                    {
                        vases4.SetActive(true);
                        StartCoroutine(Quest1Completed());
                        scorenum++;
                    }
                }
                if (hit.transform.tag == "collectable2")
                {
                    collect.Play();
                    scorenums1 = PlayerPrefs.GetFloat("stones");
                    scorenums = scorenums1 + 1f;
                    PlayerPrefs.SetFloat("stones", scorenums);
                    Destroy(hit.transform.gameObject);
                    
                    if( scorenums > 0 )
                    {
                        stones.SetActive(false);
                        stones1.SetActive(false);
                        stones2.SetActive(false);
                        stones3.SetActive(false);
                        stones4.SetActive(false);
                    }
                    
                    if (scorenums == 1f)
                    {
                        stones1.SetActive(true);
                    }
                    if (scorenums == 2f)
                    {
                        stones2.SetActive(true);
                    }
                    if (scorenums == 3f)
                    {
                        stones3.SetActive(true);
                    }
                    if (scorenums == 4f)
                    {
                        stones4.SetActive(true);
                        StartCoroutine(Quest2Completed());
                        scorenums++;
                    }
                }
                if (hit.transform.tag == "collectable3")
                {
                    collect.Play();
                    scoresnums1 = PlayerPrefs.GetFloat("clocks");
                    scoresnums = scoresnums1 + 1f;
                    PlayerPrefs.SetFloat("clocks", scoresnums);
                    Destroy(hit.transform.gameObject);
                    
                    if( scoresnums > 0 )
                    {
                        clocks.SetActive(false);
                        clocks1.SetActive(false);
                        clocks2.SetActive(false);
                        clocks3.SetActive(false);
                        clocks4.SetActive(false);
                    }
                    
                    if (scoresnums == 1f)
                    {
                        clocks1.SetActive(true);
                    }
                    if (scoresnums == 2f)
                    {
                        clocks2.SetActive(true);
                    }
                    if (scoresnums == 3f)
                    {
                        clocks3.SetActive(true);
                    }
                    if (scoresnums == 4f)
                    {
                        clocks4.SetActive(true);
                        StartCoroutine(Quest3Completed());
                        scoresnums++;
                    }
                }
            }
        }
    }

}
