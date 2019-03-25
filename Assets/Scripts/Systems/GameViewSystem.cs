using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.AspectContainer;

public class GameViewSystem : MonoBehaviour, IAspect{

    //underscore means private member field, variable which stores value for the public property
    IContainer _container;
    ActionSystem actionSystem;

    public IContainer container
    {
        get
        {
            //IF there is no container initialized, use specialized factory class to create one, and add 
            //GameViewSystems as one of it's components
            if(_container == null)
            {
                _container = GameFactory.Create();
                _container.AddAspect(this);
            }
            return _container;
        }

        set
        {
            _container = value;
        }
    }
 
    void Awake()
    {
        container.Awake();
        actionSystem = container.GetAspect<ActionSystem>();
    }

    void Start()
    {
        Temp_SetupSinglePlayer();
        container.ChangeState<PlayerIdleState>();
    }

    void Update()
    {
        actionSystem.Update();
    }

    void Temp_SetupSinglePlayer()
    {
        var match = container.GetMatch();
        match.players[0].controlMode = ControlModes.User;
        match.players[1].controlMode = ControlModes.AI;

        for (int i = 0; i < 10; i++)
        {
            var card = new Card();
            card.zone = Zones.Deck;
            card.ownerIndex = 0;
            match.players[0].deck.Add(card);
        }

        for (int i = 0; i < 10; i++)
        {
            var card = new Card();
            card.zone = Zones.Deck;
            card.ownerIndex = 1;
            match.players[1].deck.Add(card);
        }
    }
}
