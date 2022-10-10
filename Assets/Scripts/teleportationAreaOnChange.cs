using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
public class teleportationAreaOnChange : TeleportationArea
{
    public int id;
    public teleportController tpcontroller;
    
      public void teleporting()
      {
        tpcontroller.changecurrent(id);
      }

      protected override void OnSelectExited(SelectExitEventArgs args)
      {
       
         base.OnSelectExited(args);
      }
}
