using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClippingDemo
{
    public partial class Form1 : Form
    {
        //基本画图
        private Graphics graphics;
        private Bitmap bitmap;
        private Pen pen;
        private Font font;
        private Brush brush;

        private int flag = 0;//1是画线 2是画面

        private List<PointClass> line_pointList = new List<PointClass>();//存放画的线 的点
        private List<PointClass> gon_pointList = new List<PointClass>();//存放画的面 的点

        private List<PointClass> pointList = new List<PointClass>();//存放  裁剪后的  所有点
        private List<PolylineClass> polylineList=new List<PolylineClass>(); //存放 裁剪后的 所有线
        private PointClass flagpoint;

        //交点
        Dictionary<int, PointClass> dictionary = new Dictionary<int, PointClass>();

        public Form1()
        {
            InitializeComponent();
            font = new Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular);
            brush = new SolidBrush(Color.Blue);
        }

       

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (flag == 1)
                {
                    PointClass p = new PointClass(e.X, e.Y - this.Panel_Tools.Height);
                    line_pointList.Add(p);
                    DrawPoint(p, line_pointList.Count);
                    if (line_pointList.Count > 1)
                    {
                        DrawLine(line_pointList);
                    }
                }
                else if (flag == 2)
                {
                    PointClass p = new PointClass(e.X, e.Y - this.Panel_Tools.Height);
                    gon_pointList.Add(p);
                    DrawPoint(p, gon_pointList.Count);
                }
            }
            else
            {
                if (flag == 2 && gon_pointList.Count > 1)
                    DrawPolygon();
            }
        }

        /// <summary>
        /// 画点
        /// </summary>
        /// <param name="p0">PointClass类的点</param>
        /// <param name="i">计数用的</param>
        private void DrawPoint(PointClass p0,int i)
        {
            pen = new Pen(Color.Red, 3);
            float x = (float)p0.X;
            float y = (float)p0.Y + this.Panel_Tools.Height;
            graphics.DrawEllipse(pen, x, y, 1.5f, 1.5f);
            DrawString(x,y,i);
            this.pictureBox1.Image = bitmap;
        }

        private void DrawString(float x,float y,int i)
        {
            graphics.DrawString(i.ToString(), font, brush, x, y);
        }
        private void DrawPoint(PointClass p,Pen pen,int i)
        {
            float x = (float) p.X;
            float y = (float) p.Y + this.Panel_Tools.Height;
            graphics.DrawEllipse(pen, x, y, 1.5f, 1.5f);
            graphics.DrawString(i.ToString(), font, brush, x, y);
            this.pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// 根据数组画线
        /// </summary>
        private void DrawLine(List<PointClass> pl)
        {
            pen=new Pen(Color.Black,1);
            PolylineClass plc = new PolylineClass(pl.ToArray());
            for (int i = 0; i < plc.m_pointCounts-1; i++)
            {
                float x1 = (float)plc.m_p[i].X;
                float y1 = (float)plc.m_p[i].Y + this.Panel_Tools.Height;

                float x2 = (float)plc.m_p[i+1].X;
                float y2 = (float)plc.m_p[i+1].Y + this.Panel_Tools.Height;
                graphics.DrawLine(pen,x1,y1,x2,y2);
            }
            this.pictureBox1.Image = bitmap;
        }
        /// <summary>
        /// 依次传入 两个点 来画线
        /// 用来画裁剪后的线段
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void DrawLine(PointClass p1, PointClass p2)
        {
            pen = new Pen(Color.Red, 1);
            //PolylineClass plc = new PolylineClass(pointList.ToArray());
            //p1 = plc.m_p[plc.m_pointCounts - 1];
            float x1 = (float) p1.X;
            float y1 = (float) p1.Y + this.Panel_Tools.Height;

            float x2 = (float) p2.X;
            float y2 = (float) p2.Y + this.Panel_Tools.Height;
            graphics.DrawLine(pen, x1, y1, x2, y2);
            this.pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// 画面
        /// </summary>
        private void DrawPolygon()
        {
            pen = new Pen(Color.Black, 1);
            PolygonClass pgl = new PolygonClass(gon_pointList.ToArray());
            PointF[] point=new PointF[pgl.NumPoints];
            for (int i = 0; i < pgl.NumPoints ; i++)
            {
                point[i] = new PointF((float)pgl.m_p[i].X, (float)pgl.m_p[i].Y + this.Panel_Tools.Height);
            }
            graphics.DrawPolygon(pen,point);
            this.pictureBox1.Image = bitmap;
        }

      
        
        private void button_polyline_Click(object sender, EventArgs e)
        {
            graphics = Graphics.FromImage(bitmap);
            flag = 1;
            line_pointList.Clear();
        }


        private void button_polygon_Click(object sender, EventArgs e)
        {
            graphics = Graphics.FromImage(bitmap);
            flag = 2;
            gon_pointList.Clear();
        }

        //这里还需要清楚图像
        //还需更改

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
            Form1 f=new Form1();
            f.Show();
            this.Hide();
        }

        private void button_clipping_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
            clip();
        }

        //裁剪方法主体
        private void clip()
        {
            List<PolylineClass>plList=new List<PolylineClass>(); 
            List<PolylineClass>pgList=new List<PolylineClass>();
            //List<PointClass> pc=new List<PointClass>();
            PointClass[] pc1 = line_pointList.ToArray();

            

            PointClass[] pc2 = gon_pointList.ToArray();
            //折线分为线段
            for (int i = 0; i < pc1.Length-1; i++)
            {
                PointClass[] point = new PointClass[2];
                point[0] = pc1[i];
                point[1] = pc1[i + 1];
                plList.Add(new PolylineClass(point));
            }
            //面分为 线段
            for (int i = 0; i < pc2.Length; i++)
            {
                if (i==pc2.Length-1)
                {
                    PointClass[] point = new PointClass[2];
                    point[0] = pc2[i];
                    point[1] = pc2[0];
                    pgList.Add(new PolylineClass(point));
                }
                else
                {
                    PointClass[] point = new PointClass[2];
                    point[0] = pc2[i];
                    point[1] = pc2[i + 1];
                    pgList.Add(new PolylineClass(point));
                }
            }
            int k = -1;
            foreach (var VARIABLE in plList)
            {
               // k++;
                for (int i = 0; i < pgList.Count; i++)
                {
                    k++;
                    if (Line_Line.Line_Line_Relation(VARIABLE, pgList[i]))
                    {
                        //求交点
                        PointClass p = Line_Line.GetIntersection(VARIABLE, pgList[i]);
                        dictionary.Add(k,p);
                    }
                }
            }
            UpdatePoint();
            UpdateLine();
            //UpdateLine2();
            DrawPolygon();
            int jishu = 0;//计数
            foreach (PointClass VARIABLE in pointList)
            {
                DrawPoint(VARIABLE, new Pen(Color.Red, 5), jishu + 1);
                jishu++;
            }

            for (int i = 0; i < polylineList.Count; i++)
            {
                for (int j = 0; j < polylineList[i].m_pointCounts-1; j++)
                {
                    DrawLine(polylineList[i].m_p[j], polylineList[i].m_p[j+1]);
                }
            }

        }
        /// <summary>
        /// 更新裁剪后 所保留的点
        /// </summary>
        private void UpdatePoint()
        {
            int flag = 0;
            PointClass[] pc1 = line_pointList.ToArray(); //所画的线的所有点集合
            PointClass[] pc2 = gon_pointList.ToArray(); //所画的面的所有点集合

            for (int i = 0; i < pc1.Length; i++)
            {
                if (Point_Polygon.PointInFences(pc1[i], new PolygonClass(pc2))) //在多边形内
                {
                    PointClass point = new PointClass(pc1[i].X, pc1[i].Y);
                    pointList.Add(point); //计算出来的最终裁剪点
                    foreach (var s in dictionary.Keys)
                    {
                        if (i == s/pc2.Length)
                        {
                            if (dictionary[s].X != point.X && dictionary[s].Y != point.Y) //避免计算重复点
                            {
                                point = new PointClass(dictionary[s].X, dictionary[s].Y);
                                pointList.Add(point);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var s in dictionary.Keys)
                    {
                        if (i == s/pc2.Length)
                        {
                            PointClass point = new PointClass(dictionary[s].X, dictionary[s].Y);
                            pointList.Add(point);
                            flag++;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 把所有线的顶点和 交点  加到一起
        /// </summary>
        /// <returns>交点+顶点</returns>
        private List<PointClass> AddPoint()
        {
            int flag = 0;
            PointClass[] pc1 = line_pointList.ToArray(); //所画的线的所有点集合
            PointClass[] pc2 = gon_pointList.ToArray(); //所画的面的所有点集合

            List<PointClass> addpoint = new List<PointClass>(); //交点+顶点
            for (int i = 0; i < pc1.Length; i++)
            {
                PointClass point = new PointClass(pc1[i].X, pc1[i].Y);
                addpoint.Add(point); 
                foreach (var s in dictionary.Keys)
                {
                    if (i == s/pc2.Length)
                    {
                        if (dictionary[s]!=point) //避免计算重复点
                        {
                            point = new PointClass(dictionary[s].X, dictionary[s].Y);
                            addpoint.Add(point);
                        }
                    }
                }
            }
            return addpoint;
        }

        /// <summary>
        /// 更新线
        /// </summary>
        private void UpdateLine()
        {
            bool flag = false;//
            PointClass[] pc3 = pointList.ToArray(); //裁剪后的所有点集合

            List<PointClass> addpointlist = AddPoint(); //交点+顶点
            PointClass[] addpoint = addpointlist.ToArray(); //交点+顶点集合
            List<PointClass> pc = new List<PointClass>(); //临时装两个点来成一条线
            for (int i = 0; i < addpoint.Length; i++)
            {
                if (i == 0 && addpoint[i].X == pc3[0].X && addpoint[i].Y == pc3[0].Y)
                {
                    PointClass point = new PointClass(addpoint[i].X, addpoint[i].Y);
                    pc.Add(point);
                }
                else if (i == addpoint.Length - 1 && addpoint[i].X == pc3[pc3.Length - 1].X && addpoint[i].Y == pc3[pc3.Length - 1].Y)
                {
                    PointClass point = new PointClass(addpoint[i].X, addpoint[i].Y);
                    pc.Add(point);
                    polylineList.Add(new PolylineClass(pc.ToArray()));
                }
                else
                {
                    foreach (PointClass p in pc3)
                    {
                        if (p.X == addpoint[i].X && p.Y == addpoint[i].Y)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        polylineList.Add(new PolylineClass(pc.ToArray()));
                        pc = new List<PointClass>();
                        flag = false;
                    }
                    else
                    {
                        PointClass point = new PointClass(addpoint[i].X, addpoint[i].Y);
                        pc.Add(point);
                        flag = false;
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
        }


      
    }

}
