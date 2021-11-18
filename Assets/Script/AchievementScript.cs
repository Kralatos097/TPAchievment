using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScript : MonoBehaviour
{
    private Action OnGetAllAchievement;
    
    private bool _getAllAchievement = false;
    private bool _stepForwardThreeTime = false;
    private bool _stepForwardFiveTime = false;
    private bool _stepTenTime = false;
    private bool _playerDeath = false;
    private bool _playerRespawn = false;

    private const int _nbAchievement = 7;
    private int _countAchievement = 0;
    
    private int _stepForwardCount;
    private int _stepCount;
    
    private void Start()
    {
        OnGetAllAchievement += delegate
        {
            if(!_getAllAchievement)
            {
                Debug.Log("Bien joué ! Tu as eu tous les succés !");
                _getAllAchievement = true;
            }
        };
        
        MovementScript.OnStepForward += delegate
        {
            _stepForwardCount++;
            _stepCount++;
            
            StepAchievement();
        };
        
        MovementScript.OnStep += delegate
        {
            _stepCount++;
            
            StepAchievement();
        };
        
        RespawnScript.OnPlayerRespawn += delegate(Vector3 vector3)
        {
            if(!_playerRespawn)
            {
                Debug.Log("Le Player est réapparue ici : " + vector3);
                _playerRespawn = true;
                CheckAllAchievement();
            }
        };
        
        DeathZoneScript.OnPlayerDestroy += delegate(Vector3 vector3)
        {
            if (!_playerDeath)
            {
                Debug.Log("Le Player est mort ici : " + vector3);
                _playerDeath = true;
                CheckAllAchievement();
            }
        };
        
        ButtonScript.OnSpawnPrefab += delegate
        {
            
        };

        DeathZoneScript.OnSphereDestroy += delegate
        {

        };
    }

    private void StepAchievement()
    {
        if(_stepForwardCount >= 3 && !_stepForwardThreeTime)
        {
            _stepForwardThreeTime = true;
            Debug.Log("Step Forward Three Time");
            CheckAllAchievement();
        }

        if(_stepForwardCount >= 5 && !_stepForwardFiveTime)
        {
            _stepForwardFiveTime = true;
            Debug.Log("Step Forward Five Time");
            CheckAllAchievement();
        }

        if(_stepCount >= 10 && !_stepTenTime)
        {
            _stepTenTime = true;
            Debug.Log("Step Ten Time");
            CheckAllAchievement();
        }

        
    }

    private void CheckAllAchievement()
    {
        _countAchievement++;
        
        if(_countAchievement >= _nbAchievement)
        {
            OnGetAllAchievement.Invoke();
        }
    }
}
