using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippingDemo
{
    class PolylineClass
    {
        public int m_pointCounts ;
        public PointClass[] m_p;

        public PolylineClass(PointClass[] p)
        {
            m_pointCounts = p.Length;
            m_p = p;
        }
        
    }
}
