using System;

public class Program
{
    const int INF = 99999;

    //Аргументы: матрица смежности, количество вершин
    //Возвращает: матрицу кратчайших вершин, матрицу предшествующих вершин
    public static int[][][] FloydWarshallWithPath(int[][] graph, int V)
    {
        int[][] dist = new int[V][]; //Матрица расстояний
        int[][] next = new int[V][]; //Матрица последовательности узлов

        //Поиск предшествующих вершин
        for (int i = 0; i < V; i++)
        {
            dist[i] = new int[V];
            next[i] = new int[V];
            Array.Copy(graph[i], dist[i], V);
            for (int j = 0; j < V; j++)
            {
                next[i][j] = j;
            }
        }

        //Этап 2 - Поиск кратчайших путей
        for (int k = 0; k < V; k++)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i][k] + dist[k][j] < dist[i][j])
                    {
                        dist[i][j] = dist[i][k] + dist[k][j];
                        next[i][j] = next[i][k];
                    }
                }
            }
        }

        return new int[][][] { dist, next };
    }

    public static void Main(string[] args)
    {
        //Заголовок программы
        Console.WriteLine("Программа, реализующая алгоритм Флойда");

        //Этап 1 - Инициализация D0, S0
        int[][] graph = new int[][] {
            new int[] { 0, 5, 3, INF, INF, INF, INF }, //1
            new int[] { 5, 0, 1, 5, 2, INF, INF }, //2
            new int[] { 3, 1, 0, 7, INF, INF, 12 }, //3
            new int[] { INF, 5, 7, 0, 3, INF, 3 }, //4
            new int[] { INF, 2, INF, 3, 0, 1, INF }, //5
            new int[] { INF, INF, INF, INF, 1, 0, INF }, //6
            new int[] { INF, INF, 12, 3, INF, 4, 0 }, //7
        };

        int V = graph.Length; //Количество узлов
        int[][][] result = FloydWarshallWithPath(graph, V);
        int[][] dist = result[0]; //Матрица расстояний
        int[][] next = result[1]; //Матрица последовательности узлов

        Console.WriteLine("\nМатрица кратчайших путей:");
        Console.WriteLine(" | 1 2 3 4 5 6 7");
        Console.WriteLine("_ _ _ _ _ _ _ _ _");
        for (int i = 0; i < V; i++)
        {
            Console.Write(i + 1 + "| ");
            for (int j = 0; j < V; j++)
            {
                if (dist[i][j] == INF)
                {
                    Console.Write("INF ");
                }
                if (dist[i][j] == 0)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write($"{dist[i][j]} ");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nМатрица предшествующих вершин:");
        Console.WriteLine(" | 1 2 3 4 5 6 7");
        Console.WriteLine("_ _ _ _ _ _ _ _ _");
        for (int i = 0; i < V; i++)
        {
            Console.Write(i + 1 + "| ");
            for (int j = 0; j < V; j++)
            {
                if (i == j)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write($"{next[i][j] + 1} ");
                }
            }
            Console.WriteLine();
        }
    }
}