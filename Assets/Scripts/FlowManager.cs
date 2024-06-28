using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public static FlowManager Instance {get; private set;}
    List<GameObject> training1 = new List<GameObject>();
    List<GameObject> training2 = new List<GameObject>();
    List<GameObject> training3 = new List<GameObject>();
    [Serializable]public enum TrainingStates {training1, training2, training3}
    [Serializable]public enum RoleState {pilot, copilot, asistant}
    public TrainingStates trainingStates;
    public RoleState roleState;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start() {
        //CallReferences();

    }
    void CheckMoment()
    {
        //Reviso en que role está seleccionando
        switch (roleState)
        {
            case RoleState.pilot:
            //Revisa en que training va el usuario
            switch (trainingStates)
            {
                case TrainingStates.training1:
                    //Recorro lista de los gameobjects del training correspondiente y los activo
                    for (int i = 0; i < training1.Count; i++)
                    {
                        training1[i].SetActive(true);
                    }
                    //Recorro lista de los gameobjects del training que no corresponde y los desactivo
                    for (int i = 0; i < training2.Count; i++)
                    {
                        training1[i].SetActive(false);
                    }

                break;
                case TrainingStates.training2:
                    //Todo lo que debe ir activado si empiezo en trining 1

                break;
            }
            break;
            
        //Reviso en que role está seleccionando
            case RoleState.copilot:
            break;
            
        //Reviso en que role está seleccionando
            case RoleState.asistant:
            break;
        }
    }
    void CallReferences()
    {
        GameObject[] gameObjectsTraining1 = GameObject.FindGameObjectsWithTag("training1");

        for (int i = 0; i < gameObjectsTraining1.Length; i++)
        {
            training1.Add(gameObjectsTraining1[i]);
        }
    }

    public void SelectRole(int role)
    {
        switch (role)
        {
            case 0:
                roleState = RoleState.pilot;
            break;
            case 1:
                roleState = RoleState.copilot;
            break;
            case 2:
                roleState = RoleState.asistant;
            break;
        }
    }    
    public void SelectTraining(int training)
    {
        switch (training)
        {
            case 0:
                GameObject.FindAnyObjectByType<FlowManager>().trainingStates = TrainingStates.training1;
            break;
            case 1:
                GameObject.FindAnyObjectByType<FlowManager>().trainingStates = TrainingStates.training2;
            break;
            case 2:
                GameObject.FindAnyObjectByType<FlowManager>().trainingStates = TrainingStates.training3;
            break;
        }
    }    

}
