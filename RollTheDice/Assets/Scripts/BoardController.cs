using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance;

        public int GridSizeX, GridSizeY;

        private void Awake ()
        {
            if ( Instance == null ) Instance = this;
        }

        // Start is called before the first frame update
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}
