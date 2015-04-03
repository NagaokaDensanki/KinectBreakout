using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectBreakeOut
{
    class Arm
    {
        double x1, x2, y1, y2;

        //線の座標をセット
        public void SetPostion(double xa,double ya,double xb,double yb) {
            x1 = xa>xb?xa:xb;
            x2 = xa > xb ? xb : xa;
            y1 = ya > yb ? ya : yb;
            y2 = ya > yb ? yb : ya;
        }


        //当たっているかどうか
        bool IsHIts(double x,double y,double speedx,double speedy) {
            double A1 = (y2 - y1) / (x1 - x2), A2 = -speedy / speedx, E1 = (y2 - y1) / (x1 - x2) * x1 + y1, E2 = -speedy / speedx;
            double crossx=(E1-E2)/(A1-A2);
            //二本の直線の交点

            bool result = (crossx < x1 && crossx > x2);

            return  result;

            /*
            double d = y - (y1 - y2) / (x1 - x2) * x + (y1 - y2) / (x1 - x2) * x1 - y1 ;
            d = d > 0 ? d : -d;
            d /= Math.Sqrt(1 + (y1 - y2) / (x1 - x2) * (y1 - y2) / (x1 - x2));
            if(d>Math.Sqrt(speedx*speedx+speedy+speedy)){
                return false;
            }
             */
        }

        //反射
        public void Reflection(double x, double y, double speedx, double speedy)
        {
            if (IsHIts(x,y,speedx,speedy)==false)
            {
                return;
            }
        }
    }
}
