using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class PointClass
    {
        //private double m_x;
        //private double m_y;

        //public double x
        //{
        //    get { m_x = x;
        //        return m_x;
        //    }
        //    set { x = value; }
        //}

        //public double y
        //{
        //    get
        //    {
        //        m_y = y;
        //        return m_x;
        //    }
        //    set { y = value; }
        //}

        public double X;
        public double Y;

        public PointClass(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }
        public PointClass(double x,double y)
        {
            X = x;
            Y = y;
        }


    }
}
