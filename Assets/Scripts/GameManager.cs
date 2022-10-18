using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool start = false;
    public float speed = 2;
    public GameObject Col;
    public Renderer sceneBg;

    public GameObject mainMenu;
    public GameObject menuGameOver;
    public GameObject rock1;
    public GameObject rock2;

    public List<GameObject> Cols;
    public List<GameObject> Obs;
    // Start is called before the first frame update
    void Start()
    {
        //Crear Mapa
        for (int i = 0; i < 21; i++)
        {
            Cols.Add(Instantiate(Col , new Vector2(-10 + i,-3) , Quaternion.identity));
        }

        //Crear Piedras
        Obs.Add(Instantiate(rock1, new Vector2(14 , -2), Quaternion.identity));
        Obs.Add(Instantiate(rock2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        
        if (start && gameOver)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start && gameOver == false)
        {
            mainMenu.SetActive(false);
            sceneBg.material.mainTextureOffset = sceneBg.material.mainTextureOffset + new Vector2(0.025f, 0) * Time.deltaTime;
            
            for (int i = 0; i < Cols.Count; i++)
            {
                if (Cols[i].transform.position.x <= -10)
                {
                    Cols[i].transform.position = new Vector3(10, -3, 0);
                }

                Cols[i].transform.position = Cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
           
            for (int i = 0; i < Obs.Count; i++)
            {
                if (Obs[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    Obs[i].transform.position = new Vector3(randomObs, -2, 0);
                }

                Obs[i].transform.position = Obs[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
}
