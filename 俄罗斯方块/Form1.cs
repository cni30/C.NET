using Tetris;

namespace 俄罗斯方块
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer m_timer;      //定时器
        Canvas m_canvas;    //画布模型
        Graphics m_picturegra;  //画布
        Graphics m_nextpicgra;  //用于显示下一个砖块的画布
        float m_itemxlength;
        float m_itemylength;
        bool m_isrun;

        public Form1()
        {
            InitializeComponent();
            this.Text = "俄罗斯方块";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //设置窗体边框

            pictureBox1.BorderStyle = BorderStyle.FixedSingle;      //设置图片边框
            pictureBox1.Focus();            //获取焦点

            label1.Font = new Font("微软雅黑", 8);
            label1.Text = "游戏说明：\n   通过方向键控制砖块。\n   向上键：变形\n   向左键：左移\n   向下键：下移\n   向右键：右移";

            label2.AutoSize = true;

            label2.Text = "当前分数：0分";

            m_picturegra = pictureBox1.CreateGraphics();               //在pictureBox1上绘图
            m_canvas = new Canvas();                                  //创建画布
            m_itemxlength = pictureBox1.Width / m_canvas.m_columns;  //X长=  pictureBox1宽/画布列
            m_itemylength = pictureBox1.Height / m_canvas.m_rows;   //Y长=  pictureBox1高/画布行

            pictureBox2.Size = new Size((int)m_itemxlength * 5, (int)m_itemylength * 5);
            m_nextpicgra = pictureBox2.CreateGraphics();  //将下一个要出现的方块绘在pictureBox2上

            m_isrun = false;        //初始时未运行

            m_timer = new System.Windows.Forms.Timer();
            m_timer.Interval = 500;             //定时5秒
            m_timer.Enabled = false;
            m_timer.Tick += new EventHandler(m_timer_Tick);
        }

        void m_timer_Tick(object sender, EventArgs e)
        {
            if (m_canvas.Run() == true)
            {
                Draw();
                DrawNext();
                DrawScore();
            }
            else
            {
                m_timer.Enabled = false;
                if (m_canvas.m_score >= 100)
                {
                    MessageBox.Show("游戏结束！胜利！");
                }
                else
                {
                    MessageBox.Show("游戏结束！失败！");
                }
            }
        }

        private void Draw()
        {
            //初始化画布
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);      //新建一个Bitmap位图，创建画布
            Graphics gb = Graphics.FromImage(canvas);       //在canvas上创建一个Graphics类型的可编辑图层，用以显示图像   

            for (int i = 0; i < m_canvas.m_rows; i++)       //遍历行
            {
                for (int j = 0; j < m_canvas.m_columns; j++)        //遍历列
                {
                    if (m_canvas.m_arr[i, j] == 0)      //利用二维数组表示图像，为0表示无，为1表示需要显示一个方块
                    {
                        continue;
                    }
                    else
                    {
                        DrawItem(gb, i, j);             //绘制方块
                    }
                }
            }
            pictureBox1.BackgroundImage = canvas;
            pictureBox1.Refresh();      //刷新
        }

        private void DrawItem(Graphics gb, int row, int column)     //画当前方块
        {
            float xpos = column * m_itemxlength - 1;        //左x坐标
            float ypos = row * m_itemylength - 1;           //右x坐标
            gb.FillRectangle(Brushes.Blue, xpos, ypos, m_itemxlength - 2, m_itemylength - 2);       //画一个蓝色填充矩形
        }

        private void DrawNext()         //画下一个要出现的方块
        {
            pictureBox2.Refresh();      //刷新
            m_canvas.DrawNewxBrick(m_nextpicgra, m_itemxlength, m_itemylength);     //绘制下一个要出现的方块
        }

        private void DrawScore()        //得分
        {
            string temp = "当前分数：" + m_canvas.m_score.ToString() + "分";
            label2.Text = temp;         //在label2打印当前分数
        }

        protected override bool ProcessDialogKey(Keys keyData)      //重载方法，用于捕获方向键
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                return false;       //若键已由控件处理，则为true，否则为false
            }
            return base.ProcessDialogKey(keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (m_isrun == true)
            {
                if (key == Keys.Up)     //按上键
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickUp();     //旋转方块
                    Draw();                 //画出新图像
                }
                if (key == Keys.Left)       //按左键
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickLeft();   //左移
                    Draw();
                }
                if (key == Keys.Right)      //按右键
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickRight();  //右移
                    Draw();
                }
                if (key == Keys.Down)       //按下键
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickDown();   //下移
                    Draw();
                }
            }
        }

        private void Btn_NewGame_Click_1(object sender, EventArgs e)        //”开始“按钮
        {
            m_isrun = false;        //若未开始运行
            m_timer.Stop();         //重置计时器

            m_canvas = new Canvas();//新建画布

            m_isrun = true;         //开始运行
            m_timer.Start();        //开启计时器
        }

        private void Btn_Stop_Click_1(object sender, EventArgs e)           //“暂停”按钮
        {
            m_isrun = false;        //停止运行
            m_timer.Stop();         //停止计时器
        }

        private void Btn_Continue_Click_1(object sender, EventArgs e)       //“继续”按钮
        {
            m_isrun = true;         //开始运行
            m_timer.Start();        //开始计时器
        }

        private void Btn_Quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (m_canvas.Run() == true)
            {
                //pictureBox1.Refresh();
                Draw();
                DrawNext();
                DrawScore();
            }
            else
            {
                m_timer.Enabled = false;
                if (m_canvas.m_score >= 100)
                {
                    MessageBox.Show("游戏结束！胜利！");
                }
                else
                {
                    MessageBox.Show("游戏结束！失败！");
                }
            }
        }
    }

}
