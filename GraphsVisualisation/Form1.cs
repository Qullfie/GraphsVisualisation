using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static GraphsVisualisation.Graph;
namespace GraphsVisualisation
{
    public partial class Form1 : Form
    {
        Graph graph = new Graph();
        Dictionary<GraphNode, Point> nodePositions;

        GraphNode selectedNode;
        Point mouseOffset;
        public Form1()
        {
            InitializeComponent();

            nodePositions = new Dictionary<GraphNode, Point>();
            UpdateNodePositions();
            DoubleBuffered = true;//Двойная буферизация
        }

        private void UpdateNodePositions()
        {
            int nodeSpacing = 100;
            int currentX = 50;

            nodePositions.Clear();

            foreach (var node in graph.NodeList)
            {
                nodePositions[node] = new Point(currentX, Height / 2);
                currentX += nodeSpacing;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //graph.AddNode(new GraphNode(1));
            //graph.AddNode(new GraphNode(2));
            //graph.AddNode(new GraphNode(3));

            //graph.AddEdge(1, 2);
            //graph.AddEdge(2, 3);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(1, 3);
            UpdateNodePositions();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addNodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(addNodeTB.Text);
                GraphNode newNode = new GraphNode(id);
                try
                {
                    graph.AddNode(newNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Random rand = new Random();
                int rand_x = rand.Next(0, MainPictureBox.Width);
                int rand_y = rand.Next(0, MainPictureBox.Height);
                nodePositions[newNode] = new Point(rand_x, rand_y);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формт ввода");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void addEdgeBtn_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(fromTB.Text);
            int to = Convert.ToInt32(toTB.Text);
            try
            {
                graph.AddEdge(from, to);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (var buffer = new Bitmap(ClientSize.Width, ClientSize.Height))
            {
                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(BackColor);
                    DrawGraph(g);
                }

                e.Graphics.DrawImage(buffer, 0, 0);
            }
        }

        private void DrawGraph(Graphics g)
        {
            foreach (Edge edge in graph.EdgeList)
            {
                Point startPoint = nodePositions[edge.From];
                Point endPoint = nodePositions[edge.To];
                Color arrowColor = Color.Gray;

                //Вычисление количества таких же дуг
                if (graph.EdgeList.Count(SuchAnEdge => SuchAnEdge.From == edge.From && SuchAnEdge.To == edge.To) > 1) arrowColor = Color.SaddleBrown;

                DrawArrow(g, startPoint, endPoint, arrowColor);
            }

            foreach (var nodePosition in nodePositions)
            {
                DrawNode(g, nodePosition.Value, nodePosition.Key.id.ToString());
            }
        }
        private void DrawNode(Graphics g, Point position, string text)
        {
            int nodeSize = 30;
            g.FillEllipse(Brushes.LightBlue, position.X - nodeSize / 2, position.Y - nodeSize / 2, nodeSize, nodeSize); //?
            g.DrawEllipse(Pens.Black, position.X - nodeSize / 2, position.Y - nodeSize / 2, nodeSize, nodeSize);
            g.DrawString(text, Font, Brushes.Black, position.X - 5, position.Y - 8);
        }

        private void DrawArrow(Graphics g, Point startPoint, Point endPoint, Color arrowColor)
        {
            Pen pen = new Pen(arrowColor);
            pen.Width = 2;

            // Вычисляем угол наклона линии
            float angle = (float)(Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X) * 180 / Math.PI);

            // Вычисляем координаты конца линии с отступом от узла
            float arrowSize = 10;
            float endX = endPoint.X - arrowSize * (float)Math.Cos(angle * Math.PI / 180);
            float endY = endPoint.Y - arrowSize * (float)Math.Sin(angle * Math.PI / 180);


            //Рисуем линию
            g.DrawLine(pen, startPoint, new Point((int)endX, (int)endY));

            //Рисуем стрелку

            AdjustableArrowCap arrowCap = new AdjustableArrowCap(arrowSize, arrowSize, true);
            pen.CustomEndCap = arrowCap;
            g.DrawLine(pen, startPoint, new Point((int)endX, (int)endY));

        }
        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var nodePosition in nodePositions)
            {
                Rectangle nodeRect = new Rectangle(nodePosition.Value.X - 15, nodePosition.Value.Y - 15, 30, 30);

                if (nodeRect.Contains(e.Location))
                {
                    selectedNode = nodePosition.Key;
                    mouseOffset = new Point(e.X - nodePosition.Value.X, e.Y - nodePosition.Value.Y);
                    break;
                }
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedNode != null)
            {
                nodePositions[selectedNode] = new Point(e.X - mouseOffset.X, e.Y - mouseOffset.Y);
                Invalidate(); // Перерисовываем форму
            }
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selectedNode = null;
        }
        private void maxMultBtn_Click(object sender, EventArgs e)
        {
            graph.MaxMultiplicity(maxMultTB);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string filename = "C:\\Users\\User\\source\\repos\\GraphsVisualisation\\graph.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                try
                {
                    graph.SaveToFile(writer);
                    MessageBox.Show("граф успешно сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            string filename = "C:\\Users\\User\\source\\repos\\GraphsVisualisation\\graph.txt";
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    graph = new Graph();
                    graph = Graph.LoadFromFile(reader);
                    UpdateNodePositions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}