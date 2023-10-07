using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EscapeBox : MonoBehaviour
{

    private GameObject _playerTarget = null;

    bool isActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();


        if (player) _playerTarget = player.gameObject;



    }


    public bool IsActivated
    {
        get { return isActivated; }
        set { isActivated = value; }
    }


    public void OnTriggerEnter(Collider other)
    {
        //if escapebox is activated and player collides,  complete the level

        if (isActivated == true)
        {
    
  

            if (_playerTarget == null)
                return;
           

            if (other.gameObject == _playerTarget)
            {
          
                CompleteLevel();
            }

        }
    }

    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) //if last level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //load first level (reset the game)
        }
        else //if first level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next level
        }
    }

}
