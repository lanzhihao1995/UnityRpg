using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {

    public static LoginController Login { get; private set; }
    public static MainUIController MainUI { get; private set; }


    public static void Init() {
        Login = new LoginController();
        MainUI = new MainUIController();
    }


	//public GameController() {
 //       login = new LoginController();
 //   }
}
