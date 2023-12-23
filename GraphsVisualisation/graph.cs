using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsVisualisation
{
    public class Graph
    {
        public class GraphNode
        {
            public int x;
            public int y;
            public int id;

            public GraphNode(int id)
            {
                this.id = id;
                //coordinations initialization?
                x = 0;
                y = 0;
            }

        }
        public class Edge
        {
            public GraphNode From;
            public GraphNode To;

            public Edge(GraphNode from, GraphNode to)
            {
                From = from;
                To = to;
            }
        }
        public List<Edge> EdgeList;
        public List<GraphNode> NodeList;

        public Graph()
        {
            EdgeList = new List<Edge>();
            NodeList = new List<GraphNode>();
        }

        public void AddNode(GraphNode newNode)
        {
            //Checking if there already is node with this id
            foreach (GraphNode node in NodeList)
            {
                if (node.id == newNode.id)
                {
                    throw new Exception("Уже есть узел с таким id");
                }
            }
            NodeList.Add(newNode);
        }

        public void AddEdge(int from, int to)
        {
            //Finding "From" Node and "To" Node

            GraphNode fromNode = null;
            GraphNode toNode = null;

            foreach (GraphNode node in NodeList)
            {
                if (node.id == from) fromNode = node;
                if (node.id == to) toNode = node;
            }
            if (fromNode == null || toNode == null)
            {
                throw new Exception("Нет нужных узлов!");
            }
            Edge newEdge = new Edge(fromNode, toNode);
            EdgeList.Add(newEdge);
        }

        public void PrintEdgeToTextBox(TextBox tb)
        {
            foreach (Edge edge in EdgeList)
            {
                tb.AppendText(edge.From.id + " to " + edge.To.id + "\r\n");
            }

        }
        public int MaxMultiplicity(TextBox tb)
        {
            int maxMultiplicity = 0;
            Edge maxMultEdge = null;
            Dictionary<Edge, int> multiplicity = new Dictionary<Edge, int>();
            foreach (Edge edge in EdgeList)
            {
                multiplicity[edge] = EdgeList.Count(SuchAnEdge => SuchAnEdge.From == edge.From && SuchAnEdge.To == edge.To);
            }
            //Поиск максимальной кратности среди всех ребер
            foreach(var mult in multiplicity)
            {
                if (mult.Value > maxMultiplicity)
                {
                    maxMultiplicity = mult.Value;
                    maxMultEdge = mult.Key;
                }
            }
            tb.Text = $"Максимальную кратность {maxMultiplicity} имеет ребро {maxMultEdge.From.id} -> {maxMultEdge.To.id}";
            return maxMultiplicity;
        }

        public void SaveToFile(StreamWriter writer)
        {
            foreach(GraphNode node in NodeList)
            {
                writer.WriteLine(node.id);
            }
            writer.WriteLine("$");
            foreach(Edge edge in EdgeList)
            {
                writer.WriteLine(edge.From.id + " " + edge.To.id);
            }
            writer.WriteLine("$");

        }
        public static Graph LoadFromFile(StreamReader reader)
        {
            Graph loadedGraph = new Graph();
            string current = reader.ReadLine();
            while (current != "$")
            {
                loadedGraph.AddNode(new GraphNode(Convert.ToInt32(current)));
                current = reader.ReadLine();
            }
            current = reader.ReadLine();
            string[] mas = new string[2];
            while (current != "$")
            {
                mas = current.Split();
                loadedGraph.AddEdge(Convert.ToInt32(mas[0]), Convert.ToInt32(mas[1]));
                current = reader.ReadLine();
            }
            return loadedGraph;

        }
    }
}
