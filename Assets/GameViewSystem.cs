using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.AspectContainer;

public class GameViewSystem : MonoBehaviour, IAspect{

    //underscore means private member field, variable which stores value for the public property
    IContainer _container;

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
    
}
