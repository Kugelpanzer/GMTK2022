using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GMTK2020
{

    public class Dice
    {
        public class Side
        {
            public Dictionary<string, Side> sideDict = new Dictionary<string, Side>();
            public Dictionary<int, string> valueDict = new Dictionary<int, string>();
        }
    }
}
