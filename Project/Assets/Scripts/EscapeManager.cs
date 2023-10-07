using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{
    [SerializeField]
    GameObject _escapeTemplate;
    [SerializeField]
    EscapeGameMode _escapeGameMode = null;

  
    bool _queenKilled = false;

    Eggs[] _eggs;
    int _eggsAlive = 0;

    private void Awake()
    {
       //store eggs
         _eggs = FindObjectsOfType<Eggs>();


        if (_eggs == null)
            return;

        _eggsAlive = _eggs.Length;


    
    }


    private void Update()
    {


        if(_eggsAlive == 0 && _queenKilled == true) //if no eggs left and queen is dead
        {
            //spawn the escape and create the escapegamemode
            SpawnEscape();

            Instantiate(_escapeGameMode, transform.position, transform.rotation);


            //get HUD
            HUD hud = FindObjectOfType<HUD>();

            if (hud == null)
                return;

            //show the ESCAPE! message on screen
            hud.ShowEscapeText = true;


            Destroy(gameObject);
            
        }

  

    }

    public void RemoveEgg()
    {
        --_eggsAlive;
       
    }

    private void SpawnEscape()
    {
        //activate the escapebox

        EscapeBox escapeBox = FindObjectOfType<EscapeBox>();
        if (escapeBox == null)
            return;

        escapeBox.IsActivated = true;

       
    }


    public bool QueenKilled
    {
        get { return _queenKilled; }
        set { _queenKilled = value; }
    }


}
