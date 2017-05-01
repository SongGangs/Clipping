using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class Line_Line
    {
        /*
        /// <summary>
        /// 线与线的位置关系 是否相交
        /// </summary>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        /// <returns>返回true为相交</returns>
        public static bool Line_Line_Relation(PolylineClass pl1,PolylineClass pl2)
        {
            int[] flag = new int[4];
            int k=0;
            Point_Line P_L=new Point_Line();
            for (int i = 0; i < pl1.m_pointCounts; i++)
            {
                flag[k]=P_L.Point_Line_Relation(pl1.m_p[i], pl2);
                k++;
            }
            for (int i = 0; i < pl2.m_pointCounts; i++)
            {
                flag[k] = P_L.Point_Line_Relation(pl2.m_p[i], pl1);
                k++;
            }
            if (flag[0]*flag[1] <= 0 && flag[2]*flag[3] <= 0)
            {
                return true;
            }
            else
                return false;
        }
        */

        /// <summary>
        /// 判断两条线是否相交
        /// </summary>
        /// <param name="a">线段1起点坐标</param>
        /// <param name="b">线段1终点坐标</param>
        /// <param name="c">线段2起点坐标</param>
        /// <param name="d">线段2终点坐标</param>
        /// <param name="intersection">相交点坐标</param>
        /// <returns>是否相交 0:两线平行  -1:不平行且未相交  1:两线相交</returns>
        public static PointClass GetIntersection(PolylineClass pl1, PolylineClass pl2)
        {
            PointClass a = pl1.m_p[0];
            PointClass b = pl1.m_p[pl1.m_pointCounts - 1];
            PointClass c = pl2.m_p[0];
            PointClass d = pl2.m_p[pl2.m_pointCounts - 1];
            double x = ((b.X - a.X)*(c.X - d.X)*(c.Y - a.Y) - c.X*(b.X - a.X)*(c.Y - d.Y) +
                              a.X*(b.Y - a.Y)*(c.X - d.X))/((b.Y - a.Y)*(c.X - d.X) - (b.X - a.X)*(c.Y - d.Y));
            double y = ((b.Y - a.Y)*(c.Y - d.Y)*(c.X - a.X) - c.Y*(b.Y - a.Y)*(c.X - d.X) +
                              a.Y*(b.X - a.X)*(c.Y - d.Y))/((b.X - a.X)*(c.Y - d.Y) - (b.Y - a.Y)*(c.X - d.X));
            return new PointClass(x, y);
        }

        public static bool Line_Line_Relation(PolylineClass pl1, PolylineClass pl2)
        {
            PointClass a = pl1.m_p[0];
            PointClass b = pl1.m_p[pl1.m_pointCounts - 1];
            PointClass c = pl2.m_p[0];
            PointClass d = pl2.m_p[pl2.m_pointCounts - 1];
            if ((b.Y - a.Y) * (c.X - d.X) - (b.X - a.X) * (c.Y - d.Y) == 0)
            {
                return false;//平行
            }
            double x, y;
            x = ((b.X - a.X) * (c.X - d.X) * (c.Y - a.Y) - c.X * (b.X - a.X) * (c.Y - d.Y) + a.X * (b.Y - a.Y) * (c.X - d.X)) / ((b.Y - a.Y) * (c.X - d.X) - (b.X - a.X) * (c.Y - d.Y));
            y = ((b.Y - a.Y) * (c.Y - d.Y) * (c.X - a.X) - c.Y * (b.Y - a.Y) * (c.X - d.X) + a.Y * (b.X - a.X) * (c.Y - d.Y)) / ((b.X - a.X) * (c.Y - d.Y) - (b.Y - a.Y) * (c.X - d.X));
            if ((x - a.X) * (x - b.X) <= 0 && (x - c.X) * (x - d.X) <= 0 && (y - a.Y) * (y - b.Y) <= 0 && (y - c.Y) * (y - d.Y) <= 0)
            {
                return true; //'相交
            }
            else
            {
                return false; //'相交但不在线段上
            }
        }

/*
        //一下并没有用
        private double point_distance(PolylineClass polyline)
        {

            PointClass p1 = new PointClass(polyline.m_p[0].X, polyline.m_p[0].Y);
            PointClass p2 = new PointClass(polyline.m_p[polyline.m_pointCounts - 1].X, polyline.m_p[polyline.m_pointCounts - 1].Y);
            double l = Math.Sqrt((p1.X - p2.X)*(p1.X - p2.X) + (p1.Y - p2.Y)*(p1.Y - p2.Y));
            return l;
        }
        private double getc(double a, double b, double d)
        {
            double c= (a + b + d)/2;
            return c;
        }
        private double geteare(double c,double a,double b,double d)
        {
            double s= Math.Sqrt(c * (c - a) * (c - b) * (c - d));
            return s;
        }
*/

    }
}
