using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour
{
    private Action OnGetAllAchievement;
    
    private bool _getAllAchievement = false;
    private bool _stepForwardThreeTime = false;
    private bool _stepForwardFiveTime = false;
    private bool _stepTenTime = false;
    private bool _playerDeath = false;
    private bool _playerDeathThree = false;
    private bool _playerRespawn = false;
    private bool _mmeSphereSpawn = false;
    private bool _mmeSphereDeath = false;
    private bool _mmeSphereDeathThree = false;

    private int _nbAchievement = 10;
    private int _countAchievement = 0;
    
    private int _stepForwardCount;
    private int _stepCount;
    private int _mmeSphereDeathCount = 0;
    private int _playerDeathCount = 0;

    public Text AchievementText;
    
    private void Start()
    {
        OnGetAllAchievement += delegate
        {
            if(!_getAllAchievement)
            {
                AchievementText.text = "Bien joué ! Tu as eu tous les succés !";
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
                AchievementText.text = ("Le Player est réapparue ici : " + vector3);
                _playerRespawn = true;
                CheckAllAchievement();
            }
        };
        
        DeathZoneScript.OnPlayerDestroy += delegate(Vector3 vector3)
        {
            _playerDeathCount++;
            if (!_playerDeath)
            {
                AchievementText.text = ("Le Player est mort ici : " + vector3);
                _playerDeath = true;
                CheckAllAchievement();
            }

            if(_playerDeathCount >= 3 && !_playerDeathThree)
            {
                AchievementText.text = ("Stop it!");
                _playerDeathThree = true;
                CheckAllAchievement();
            }
        };
        
        ButtonScript.OnSpawnPrefab += delegate
        {
            if (!_mmeSphereSpawn)
            {
                AchievementText.text = ("Mme Sphere vient d'apparaitre");
                _mmeSphereSpawn = true;
                CheckAllAchievement();
            }
        };

        DeathZoneScript.OnSphereDestroy += delegate
        {
            _mmeSphereDeathCount++;
            if(!_mmeSphereDeath)
            {
                AchievementText.text = ("Mme Sphere est morte");
                _mmeSphereDeath = true;
                CheckAllAchievement();
            }

            if (_mmeSphereDeathCount >= 3 && !_mmeSphereDeathThree)
            {
                AchievementText.text = ("Mme Sphere est morte ... encore");
                _mmeSphereDeathThree = true;
                CheckAllAchievement();
            }
        };
    }

    private void StepAchievement()
    {
        if(_stepForwardCount >= 3 && !_stepForwardThreeTime)
        {
            _stepForwardThreeTime = true;
            AchievementText.text = ("Step Forward Three Time");
            CheckAllAchievement();
        }

        if(_stepForwardCount >= 5 && !_stepForwardFiveTime)
        {
            _stepForwardFiveTime = true;
            AchievementText.text = ("Step Forward Five Time");
            CheckAllAchievement();
        }

        if(_stepCount >= 10 && !_stepTenTime)
        {
            _stepTenTime = true;
            AchievementText.text = "Step Ten Time";
            CheckAllAchievement();
        }

        
    }

    private void CheckAllAchievement()
    {
        _countAchievement++;
        
        if(_countAchievement >= _nbAchievement-1)
        {
            OnGetAllAchievement.Invoke();
        }
        Invoke(nameof(AchievementUpdate), 2);
    }

    private void AchievementUpdate()
    {
        AchievementText.text = "";
    }
}
