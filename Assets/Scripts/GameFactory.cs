﻿using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;

public static class GameFactory
{
    public static Container Create()
    {
        Container game = new Container();

        //now add Aspects - i.e. systems implementing IAspect interface
        //State Machine handles states of the game, and transitions between them.
        game.AddAspect<StateMachine>();

        return game;
    }
}