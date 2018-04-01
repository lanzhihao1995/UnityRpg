using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Topdown_Kit.Script.MVC {
    class AppFacade : Facade{
        private static AppFacade _instance;

        public static AppFacade Instance {
            get {
                if(_instance == null ) {
                    _instance = new AppFacade();
                }
                return _instance;
            }
        }

    }
}
