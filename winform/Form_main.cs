using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform
{
    public partial class Form_main : Form
    {
        private int time;
        private int markOfMine;
        private int nRow;//行数
        private int nCol;//列数
        private int nMine;  //全部地雷数

        private const int MAX_COL = 64;
        private const int MAX_ROW = 32;
        private int[,] numOfMine = new int[MAX_ROW, MAX_COL];// -1_Boo, & 1-8
        private int[,] stateOfCell = new int[MAX_ROW, MAX_COL];// 1-已打开 2-雷标记 3-问号

        private Point MouseFocus;
        private bool mouseLeft;
        private bool mouseRight;

        private bool startTimeer;

        public int nROW//c# 属性
        {
            get { return nRow; }
            set { nRow = value; }
        }

        public int nCOL
        {
            get { return nCol; }
            set { nCol = value; }
        }

        public int nMINE
        {
            get { return nMine; }
            set { nMine = value; }
        }

            

        public Form_main()
        {
            InitializeComponent();

            nRow = Properties.Settings.Default.nRow;//settings中设置的默认值
            nCol = Properties.Settings.Default.nCol;
            nMine = Properties.Settings.Default.nMine;

            StartGame();
        }

        private void StartGame()
        {
            markOfMine = nMine;
            MouseFocus.X = MouseFocus.Y = -1;

            MineLabel.Text = markOfMine.ToString();
            timeLabel.Text = "0";
            computeCell();
            updateFormSize();
            this.Refresh();
        }

        private void Form_main_Paint(object sender, PaintEventArgs e)//绘制图形
        {
            paintGame(e.Graphics);
        }

        private void updateFormSize()
        {
            int w = this.Width - this.ClientSize.Width;//除去中间内容区其它标题栏等的总宽度
            int h = this.Height - this.ClientSize.Height +
                menuStrip_main.Height + tableLayoutPanel_main.Height;
            this.Width = nCol * 32 - 2 + 20 + w;
            this.Height = nRow * 32 - 2 + 20 + h;
        }

        private void Form_main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > 10 && e.Y > menuStrip_main.Height + tableLayoutPanel_main.Height)//在游戏区域内
            {
                int c = (e.X - 10) / 32;//行数 从0开始
                int r = (e.Y - menuStrip_main.Height - tableLayoutPanel_main.Height) / 32;
                MouseFocus.X = c;
                MouseFocus.Y = r;
            }
            else
            {
                MouseFocus.X = nCol;
                MouseFocus.Y = nRow;
            }

            this.Refresh();
        }

        private void paintGame(Graphics graph)
        {
            int X = 10;
            int Y = menuStrip_main.Height + tableLayoutPanel_main.Height + 10;
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    Rectangle Rect = new Rectangle(X + j * 32, Y + i * 32, 30, 30);
                    if (stateOfCell[i, j] == 0)//未点击过
                    {
                        if (j == MouseFocus.X && i == MouseFocus.Y)//鼠标悬停
                            graph.FillRectangle(Brushes.SkyBlue, Rect);
                        else
                            graph.FillRectangle(Brushes.CadetBlue, Rect);
                    }
                    else if (stateOfCell[i, j] == 1)//已点开
                    {
                        Brush brush = Brushes.CadetBlue;
                        String number = "";

                        graph.FillRectangle(Brushes.Lavender, Rect);//背景
                        switch (numOfMine[i, j])
                        {
                            case 0: brush = Brushes.AliceBlue; number = ""; break;
                            case 1: brush = Brushes.Gray; number = numOfMine[i, j].ToString(); break;
                            case 2: brush = Brushes.Chocolate; number = numOfMine[i, j].ToString(); break;
                            case 3: brush = Brushes.Blue; number = numOfMine[i, j].ToString(); break;
                            case 4: brush = Brushes.DarkViolet; number = numOfMine[i, j].ToString(); break;
                            case 5: brush = Brushes.Green; number = numOfMine[i, j].ToString(); break;
                            case 6: brush = Brushes.DarkBlue; number = numOfMine[i, j].ToString(); break;
                            case 7: brush = Brushes.Black; number = numOfMine[i, j].ToString(); break;
                            case 8: brush = Brushes.DarkOrange; number = numOfMine[i, j].ToString(); break;
                            case -1: brush = Brushes.DarkRed; number = "Bo"; break;
                        }
                        graph.DrawString(number, new Font("Consolas", 16), brush, X + j * 32 + 5, Y + i * 32);

                    }

                    else if (stateOfCell[i, j] == 2)//标记雷
                    {
                        graph.FillRectangle(Brushes.CadetBlue, Rect);
                        graph.DrawString("☢", new Font("Consolas", 18), Brushes.DarkRed, X + j * 32, Y + i * 32);
                    }

                    else if (stateOfCell[i, j] == 3)//标问号
                    {
                        graph.FillRectangle(Brushes.CadetBlue, Rect);
                        graph.DrawString("？", new Font("Consolas", 22), Brushes.DarkOrchid, X + j * 32, Y + i * 32);
                    }
                    else if (stateOfCell[i, j] == 4)//点到的地雷背景色
                    {
                        graph.FillRectangle(Brushes.Brown, Rect);
                        graph.DrawString("Bo", new Font("Consolas", 16), Brushes.DarkRed , X + j * 32 + 5, Y + i * 32);


                    }
                }
            }
        }

        private void computeCell()
        {
            int[] dr = new int[] { -1, -1, -1, 1, 1, 1, 0, 0 };
            int[] dc = new int[] { 0, 1, -1, 0, 1, -1, -1, 1 };

            Array.Clear(numOfMine, 0, numOfMine.Length);
            Array.Clear(stateOfCell, 0, stateOfCell.Length);
            Random rd = new Random();
            for(int i = 0, c, r; i < nMine; )
            {
                c = rd.Next(nCol);
                r = rd.Next(nRow);
                if (numOfMine[r, c] != -1)
                {
                    numOfMine[r, c] = -1;
                    i++;
                }
            }

            for(int i = 0; i < nRow; i++)
                for(int j = 0; j < nCol; j++)
                {
                    if(numOfMine[i, j] != -1)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            int row, col;
                            row = i + dr[k];
                            col = j + dc[k];
                            if (row < 0 || col < 0 || row >= nRow || col >= nCol)
                                continue;
                            if (numOfMine[row, col] == -1)
                                numOfMine[i, j]++;
                        }
                    }
                }
        }

        private void Form_main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseLeft = true;
            else if (e.Button == MouseButtons.Right)
                mouseRight = true;
        }

        private void Form_main_MouseUp(object sender, MouseEventArgs e)
        {
            if(mouseLeft && mouseRight)
            {

            }//Something to be done
            else if(mouseLeft)
            {
                if (startTimeer == false)//计时开始
                {
                    while (numOfMine[MouseFocus.Y, MouseFocus.X] == -1)//若第一次就点击到雷
                        computeCell();

                    startTimeer = true;
                    timer.Start();
                    
                }

                if (numOfMine[MouseFocus.Y, MouseFocus.X] == 0)//无雷区
                {
                    dfs(MouseFocus.Y, MouseFocus.X);
                }
                else if(numOfMine[MouseFocus.Y, MouseFocus.X] == -1)//点到地雷
                {
                    stateOfCell[MouseFocus.Y, MouseFocus.X] = 4;
                    LostGame();//Lost
                }
                else
                {
                    stateOfCell[MouseFocus.Y, MouseFocus.X] = 1;//
                }
            }
            else if(mouseRight)
            {
                int state = stateOfCell[MouseFocus.Y, MouseFocus.X];
                if (state == 0)
                {
                    stateOfCell[MouseFocus.Y, MouseFocus.X] = 2;
                    MineLabel.Text =  (--markOfMine).ToString();
                }
                else if (state == 2)
                {
                    stateOfCell[MouseFocus.Y, MouseFocus.X] = 3;
                    MineLabel.Text =  (++markOfMine).ToString();
                }
                else if (state == 3)
                    stateOfCell[MouseFocus.Y, MouseFocus.X] = 0;
            }

            this.Refresh();
            WinGame();
            mouseLeft = mouseRight = false;
        }

        private void dfs(int r, int c)
        {
            stateOfCell[r, c] = 1;//1 stand for have been visit
            int[] dr = new int[] { -1, 0, 0, 1 };
            int[] dc = new int[] { 0, 1, -1, 0 };
            for(int i = 0, row, col; i < 4; i++)
            {
                row = r + dr[i];
                col = c + dc[i];
                if (row < 0 || col < 0 || row >= nRow || col >= nCol)
                    continue;
                if (row >= 0 && row < nRow && col >= 0 && col < nCol
                    && stateOfCell[row, col] == 0)
                {
                    if (numOfMine[row, col] == 0)
                        dfs(row, col);
                    else
                        stateOfCell[row, col] = 1;
                }  
            }
        }



        private void WinGame()
        {
            int Count = 0;
            for (int i = 0; i < nRow; i++)
                for (int j = 0; j < nCol; j++)
                    if (stateOfCell[i, j] == 0 ||
                        stateOfCell[i, j] == 2 ||
                            stateOfCell[i, j] == 3)
                        Count++;
            if (Count == nMine)
            {
                timer.Stop();
                DialogResult result = MessageBox.Show("你赢了！ 是否重新开始？", "游戏结束",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    StartGame();
            }

        }

        private void LostGame()
        {
            for (int i = 0; i < nRow; i++)
                for (int j = 0; j < nCol; j++)
                    if (numOfMine[i, j] == -1)
                        stateOfCell[i, j] = 1;
            
            timer.Stop();
            this.Refresh();

            DialogResult result = MessageBox.Show("你输了！ 是否重新开始？", "游戏结束",
                    MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                StartGame();
        }

        private void startAgain_Click(object sender, EventArgs e)
        {
            startTimeer = false;
            time = 0;
            timeLabel.Text = "0";
            timer.Stop();
            markOfMine = nMine;
            MineLabel.Text = markOfMine.ToString();
            
            computeCell();

            this.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)//开始计时
        {
            timeLabel.Text = (++time).ToString();
        }

        //菜单栏
        private void 初级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            初级ToolStripMenuItem.Checked = true;
            中级ToolStripMenuItem.Checked = false;
            高级ToolStripMenuItem.Checked = false;
            SettingToolStripMenuItem.Checked = false;
            nCol = 10;
            nRow = 10;
            markOfMine = nMine = 15;
            StartGame();
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            初级ToolStripMenuItem.Checked = false;
            中级ToolStripMenuItem.Checked = true;
            高级ToolStripMenuItem.Checked = false;
            SettingToolStripMenuItem.Checked = false;
            nCol = 20;
            nRow = 15;
            markOfMine = nMine = 40;
            StartGame();
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            初级ToolStripMenuItem.Checked = false;
            中级ToolStripMenuItem.Checked = false;
            高级ToolStripMenuItem.Checked = true;
            SettingToolStripMenuItem.Checked = false;
            nCol = 30;
            nRow = 20;
            markOfMine = nMine = 75;
            StartGame();
        }
        private void Setting_Click(object sender, EventArgs e)//自定义
        {
            Form_Setting Setting = new Form_Setting(this);
            Setting.ShowDialog();//信息交流
            初级ToolStripMenuItem.Checked = false;
            中级ToolStripMenuItem.Checked = false;
            高级ToolStripMenuItem.Checked = false;
            SettingToolStripMenuItem.Checked = true;
            StartGame();
        }
    }
}
