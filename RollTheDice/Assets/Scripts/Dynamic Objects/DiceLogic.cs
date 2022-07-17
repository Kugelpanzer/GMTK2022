using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GMTK2020
{
    public enum key
    {
        w,
        a,
        s,
        d
    }
    public class DiceLogic
    {
        public int top=3;
        private int topCurr=0;
        public int front=1;
        private int frontCurr=0;
        public int bottom=4;
        private int bottomCurr=0;
        public int bottom2=6;
        public int bottom2Curr=0;
        public int left=5;
        private int leftCurr=0;
        public int right=2;
        private int rightCurr=0;


        private void SetCurr()
        {
            topCurr = top;
            frontCurr = front;
            bottomCurr = bottom;
            bottom2Curr = bottom2;
            leftCurr = left;
            rightCurr = right;
        }

    
        public int Move(key k)
        {
            SetCurr();
            switch (k)
            {
                case key.w:

                    front = bottomCurr;
                    top = frontCurr;
                    bottom2 = topCurr;
                    bottom = bottom2Curr;
                    
                    break;
                case key.s:
                    front = topCurr;
                    top = bottom2Curr;
                    bottom2 = frontCurr;
                    bottom = bottomCurr;
                    break;
                case key.a:
                    front = rightCurr;
                    right = bottom2Curr;
                    left = frontCurr;
                    bottom2 = leftCurr;
                    break;
                case key.d:
                    front = leftCurr;
                    right = frontCurr;
                    left = bottom2Curr;
                    bottom2 = rightCurr;
                    break;
            }
         Debug.Log(bottom2);
        return front;
        }
    }
}
