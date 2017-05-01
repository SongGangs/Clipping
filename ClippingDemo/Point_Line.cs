using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class Point_Line
    {

        /// <summary>
        /// 点与线的关系
        /// </summary>
        /// <param name="point"></param>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <returns> -1 点在线左侧
        /// 1 点在线右侧
        /// 10 点在线的延长线上
        /// 3 点在线上 </returns>
        public int Point_Line_Relation(PointClass point, PolylineClass polyline)
        {
            PointClass startpoint = new PointClass(polyline.m_p[0].X, polyline.m_p[0].Y);
            PointClass endpoint = new PointClass(polyline.m_p[polyline.m_pointCounts - 1].X, polyline.m_p[polyline.m_pointCounts - 1].Y);
            double m = point.X * (startpoint.Y - endpoint.Y) - point.Y * (startpoint.X - endpoint.X) + (startpoint.X * endpoint.Y + startpoint.Y * endpoint.X);
            if (m > 0)
                return -1;
            else if (m < 0)
                return 1;
            else if (m == 0)
            {
                if (((point.X < startpoint.X) && (point.X < endpoint.X)) || ((point.X > startpoint.X) && (point.X > endpoint.X)) || ((point.Y > startpoint.Y) && (point.Y > endpoint.Y)) || ((point.Y < startpoint.Y) && (point.Y < endpoint.Y)))
                    return 0;
                else
                    return 10;
            }
            else
                return 100;
        }



    }
}
