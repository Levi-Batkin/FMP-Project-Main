using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoringSystem : MonoBehaviour
{
    public float scorenum;
    public float scorenum1;
    public AudioSource collect;
    private Ray ray;
    private RaycastHit hit;
    public GameObject vases, vases1, vases2, vases3, vases4;
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
        if (Input.GetKeyDown("e"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform == transform)
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
