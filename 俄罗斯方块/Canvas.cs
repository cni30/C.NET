namespace Tetris

{
    class Canvas        //定义画布
    {
        public int m_rows;
        public int m_columns;
        public int[,] m_arr;
        public int m_score;     //分数
        private Brick m_curBrick = null;
        private Brick m_nextBrick = null;
        private int m_height;    //当前高度

        public Canvas()
        {//20行20列，画布，积累高度，得分先初始化为0
            m_rows = 20;
            m_columns = 20;
            m_arr = new int[m_rows, m_columns];
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    m_arr[i, j] = 0;
                }
            }
            m_score = 0;
            m_height = 0;
        }

        //定时器  砖块定时下降或无法下降时生成新的砖块
        public bool Run()
        {
            //判断是否为空
            lock (m_arr)
            {
                if (m_curBrick == null && m_nextBrick == null)      //初始状态，无当前且无下一个
                {
                    m_curBrick = Bricks.GetBrick();     //当前方块
                    m_nextBrick = Bricks.GetBrick();    //下一个方块
                    m_nextBrick.RandomShape();          //从0-6中随机选个方块
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1); //设置方块出现位置
                    SetArrayValue();        //呈现方块
                }
                else if (m_curBrick == null)                        //
                {
                    m_curBrick = m_nextBrick;               //将呈现的下一个方块替换当前方块
                    m_nextBrick = Bricks.GetBrick();        //接着生成下一个方块
                    m_nextBrick.RandomShape();              //还是从0-6里面随机给个方块样式
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1);        //方块出现位置
                    SetArrayValue();        //呈现方块
                }
                else
                {
                    if (m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)       //若能下移
                    {
                        ClearCurBrick();        //先清除当前方块的值
                        m_curBrick.DropMove();  //下移方块
                        SetArrayValue();        //呈现方块
                    }
                    else
                    {
                        m_curBrick = null;      //已经到底，当前方块已结束
                        SetCurHeight();         //计算当前高度
                        ClearRow();             //判断有无填满的行，进行消除和加分操作
                    }
                }
                if (m_score >= 100)             //如果得分已满，则游戏通关
                    return false;
                if (m_height < m_rows)          //当前高度是否未触顶
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 根据清除当前砖块在m_arr中的值
        /// </summary>
        private void ClearCurBrick()
        {
            int centerX = m_curBrick.m_center.X;        //获取当前方块中心X坐标
            int centerY = m_curBrick.m_center.Y;        //获取当前方块中心Y坐标
            for (int i = 0; i < m_curBrick.m_needfulRows; i++)              //遍历行
            {
                for (int j = 0; j < m_curBrick.m_needfulColumns; j++)       //遍历列
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 0;        //清除当前砖块的值
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据当前砖块设置m_arr的值
        /// </summary>
        public void SetArrayValue()
        {
            int centerX = m_curBrick.m_center.X;
            int centerY = m_curBrick.m_center.Y;
            for (int i = 0; i < m_curBrick.m_needfulRows; i++)
            {
                for (int j = 0; j < m_curBrick.m_needfulColumns; j++)
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 1;        //重新设置当前砖块位置
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 判断当前有没有填满的行，有则消除、加分
        /// </summary>
        private void ClearRow()
        {
            int clearrows = 0;
            for (int i = m_rows - m_height; i < m_rows; i++)        //从已经有方块的行开始遍历行
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)         //遍历列
                {
                    if (m_arr[i, j] == 0)                   //为1表示有方块，0表示没有方块
                    {
                        isfull = false;                     //未满
                        break;
                    }
                }
                if (isfull == true)                         //这一行的每一列都为1，则满
                {
                    clearrows++;                            //
                    m_score++;                              //得分+1
                    for (int k = 0; k < m_columns; k++)
                    {
                        m_arr[i, k] = 0;                    //满则消行
                    }
                }
            }
            for (int i = m_rows - 1; i > m_rows - m_height - 1; i--)        //开始遍历倒数第2到r-h行
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 1)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull == true)
                {
                    int n = i;
                    for (int m = n - 1; m > m_rows - m_height - 2; m--)
                    {
                        if (n == 0)
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = 0;
                            }
                        }
                        else
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = m_arr[m, k];      //下挪一位
                            }
                            n--;
                        }
                    }
                }
            }
            m_height -= clearrows;          //原高度减去消去高度
        }

        /// <summary>
        /// 计算当期高度      
        /// </summary>
        private void SetCurHeight()
        {
            for (int i = 0; i < m_rows; i++)        //遍历行
            {
                for (int j = 0; j < m_columns; j++) //遍历列
                {
                    if (m_arr[i, j] == 1)
                    {
                        m_height = m_rows - i;
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// 左移
        /// </summary>
        public void BrickLeft()
        {
            lock (m_arr)        //lock保证上下左右操作互为互斥段，同一时间内只允许一个操作运行
            {
                if (m_curBrick != null && m_curBrick.CanLeftMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.LeftMove();
                    SetArrayValue();
                }
            }
        }

        /// <summary>
        /// 右移
        /// </summary>
        public void BrickRight()
        {
            lock (m_arr)        //lock保证上下左右操作互为互斥段，同一时间内只允许一个操作运行
            {
                if (m_curBrick != null && m_curBrick.CanRightMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.RightMove();
                    SetArrayValue();
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        public void BrickDown()
        {
            lock (m_arr)        //lock保证上下左右操作互为互斥段，同一时间内只允许一个操作运行
            {
                if (m_curBrick != null && m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.DropMove();
                    SetArrayValue();
                }
            }
        }

        /// <summary>
        /// 变形
        /// </summary>
        public void BrickUp()
        {
            lock (m_arr)        //lock保证上下左右操作互为互斥段，同一时间内只允许一个操作运行
            {
                if (m_curBrick != null && m_curBrick.CanTransform(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.Transform();
                    SetArrayValue();
                }
            }
        }

        //
        public void DrawNewxBrick(Graphics gra, float itemwidth, float itemheight)
        {
            int[,] arr = new int[5, 5]  {{0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0}};
            switch (m_nextBrick.m_needfulColumns)
            {
                case 2:     //需要两列时
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    break;
                case 3:     //需要三列时
                    for (int i = 1, m = 0; i < 4; i++, m++)
                    {
                        for (int j = 1, n = 0; j < 4; j++, n++)
                        {
                            arr[i, j] = m_nextBrick.m_range[m, n];
                        }
                    }
                    break;
                case 5:      //当前方块已经落地
                    arr = m_nextBrick.m_range;
                    break;
                default:
                    return;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        gra.FillRectangle(Brushes.Gray, j * itemwidth, i * itemheight, itemwidth - 2, itemheight - 2);      //画出下一个方块
                    }
                }
            }
        }
    }
}
