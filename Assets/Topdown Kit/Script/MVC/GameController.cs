using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {

    private static LoginController login;

    public static LoginController Login {
        get {
            if(login == null ) {
                login = new LoginController();
            }
            return login;
        }
    }


	//public GameController() {
 //       login = new LoginController();
 //   }
}
