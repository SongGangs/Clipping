using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class PolygonClass
    {
        public int NumParts;
        public int NumPoints;
        public PointClass[] m_p;

        public PolygonClass(PointClass[] pc)
        {
            NumPoints = pc.Length;
            NumParts = NumPoints - 1;
            m_p = pc;
        }
    }
}
