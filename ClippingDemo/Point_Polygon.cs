using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class Point_Polygon
    {
        /// <summary>
        /// 射线算法
        /// </summary>
        /// <param name="pnt1"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static bool PointInFences(PointClass pnt1, PolygonClass polygon)
        {

            int j = 0, cnt = 0;
            PointClass[] fencePnts = polygon.m_p;
            for (int i = 0; i < fencePnts.Length; i++)
            {

                j = (i == fencePnts.Length - 1) ? 0 : j + 1;

                if ((fencePnts[i].Y != fencePnts[j].Y) && (((pnt1.Y >= fencePnts[i].Y) && (pnt1.Y < fencePnts[j].Y)) || ((pnt1.Y >= fencePnts[j].Y) && (pnt1.Y < fencePnts[i].Y))) && (pnt1.X < (fencePnts[j].X - fencePnts[i].X)*(pnt1.Y - fencePnts[i].Y)/(fencePnts[j].Y - fencePnts[i].Y) + fencePnts[i].X))
                    cnt++;

            }

            return (cnt % 2 > 0) ? true : false;

        }

    }
}
