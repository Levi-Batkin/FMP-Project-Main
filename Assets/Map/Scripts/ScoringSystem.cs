using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoringSystem : MonoBehaviour
{
    private float scorenum;
    private float scorenum1;
    public AudioSource collect;
    private Ray ray;
    private RaycastHit hit;
    [Header("Vase Progress Bar Objects")] 
    
    public GameObject vases, vases1, vases2, vases3, vases4; // Objects in Quest Menu
    // Start is called before the first frame update
    void Start()
    {
        vases.SetActive(true);
        vases1.SetActive(false);
        vases2.SetActive(false);
        vases3.SetActive(false);
        vases4.SetActive(false);
        
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
                    if (scorenum == 1f)
                    {
                        vases.SetActive(false);
                        vases1.SetActive(true);
                        vases2.SetActive(false);
                        vases3.SetActive(false);
                        vases4.SetActive(false);
                    }
                    if (scorenum == 2f)
                    {
                        vases.SetActive(false);
                        vases1.SetActive(false);
                        vases2.SetActive(true);
                        vases3.SetActive(false);
                        vases4.SetActive(false);
                    }
                    if (scorenum == 3f)
                    {
                        vases.SetActive(false);
                        vases1.SetActive(false);
                        vases2.SetActive(false);
                        vases3.SetActive(true);
                        vases4.SetActive(false);
                    }
                    if (scorenum == 4f)
                    {
                        vases.SetActive(false);
                        vases1.SetActive(false);
                        vases2.SetActive(false);
                        vases3.SetActive(false);
                        vases4.SetActive(true);
                    }
                }
            }
        }
    }

}