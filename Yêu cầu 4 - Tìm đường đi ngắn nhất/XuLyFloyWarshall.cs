using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_4___Tìm_đường_đi_ngắn_nhất
{
	internal class XuLyFloyWarshall
	{
		private const int INF = 99999;
		public static int[,] ReadAdjacencyList(string filePath)
		{
			string[] lines = File.ReadAllLines(filePath);
			int numVertices = int.Parse(lines[0]);
			int[,] adjacencyMatrix = new int[numVertices, numVertices];

			for (int i = 0; i < numVertices; i++)
			{
				for (int j = 0; j < numVertices; j++)
				{
					adjacencyMatrix[i, j] = INF!;
				}
			}

			for (int i = 1; i < lines.Length; i++)
			{
				string[] vertices = lines[i].Split(' ');
				for (int n = 1; n < vertices.Length; n++)
				{
					if (n % 2 != 0)
					{
						adjacencyMatrix[i - 1, int.Parse(vertices[n])] = int.Parse(vertices[n + 1]);
					}
				}
			}
			return adjacencyMatrix;
		}


		public static void printSolution(int[,] dist, int[,] next, int V)
		{
			Console.WriteLine("Duong di ngan nhat tu moi dinh den cac dinh con lai kem theo trong so:");
			for (int i = 0; i < V; ++i)
			{
				Console.WriteLine($"\nDuong di xuat phat tu {i}:");
				for (int j = 0; j < V; ++j)
				{
					if (i != j && dist[i, j] != INF)
					{
						Console.Write($"{i} ");
						int u = i;
						while (u != j)
						{
							u = next[u, j];
							Console.Write($"-> {u} ");
						}
						Console.WriteLine($": {dist[i, j]}");
					}
				}
			}
		}

		public static void floydWarshall(int[,] graph, int V)
		{
			int[,] dist = new int[V, V];
			int[,] next = new int[V, V];
			for (int i = 0; i < V; ++i)
			{
				for (int j = 0; j < V; ++j)
				{
					dist[i, j] = graph[i, j];
					if (graph[i, j] != INF && i != j)
						next[i, j] = j;
					else
						next[i, j] = -1;
				}
			}

			for (int k = 0; k < V; ++k)
			{
				for (int i = 0; i < V; ++i)
				{
					for (int j = 0; j < V; ++j)
					{
						if (dist[i, k] + dist[k, j] < dist[i, j])
						{
							dist[i, j] = dist[i, k] + dist[k, j];
							next[i, j] = next[i, k];
						}
					}
				}
			}
			printSolution(dist, next, V);
		}
	}
}
