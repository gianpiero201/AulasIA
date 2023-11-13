using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleDotNet
{
    public class GameSolution
    {
        private List<int> _goalState = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

        public List<Node>? SolvePuzzle(Node initialNode)
        {
            List<Node> openSet = new List<Node>();
            List<Node> closedSets = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText("./treino.json")) ?? new List<Node>();

            initialNode.SetCost(_goalState);

            openSet.Add(initialNode);

            while (openSet.Count > 0)
            {
                Node? currentNode = openSet.ElementAt(0);
                openSet.RemoveAt(0);

                if (currentNode.Puzzle == _goalState)
                {
                    List<Node> path = new List<Node>();

                    while (currentNode != null)
                    {
                        path.Add(currentNode);
                        currentNode = currentNode.Parent;
                    }
                    return path;
                }

                closedSets.Add(currentNode);
                ResultStore(currentNode);


                (int, int)[] moves = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

                foreach (var (dx, dy) in moves)
                {
                    int x = currentNode.Puzzle.IndexOf(0) / 4 + dx;
                    int y = currentNode.Puzzle.IndexOf(0) % 4 + dy;

                    if (0 <= x && x < 4 && 0 <= y && y < 4)
                    {
                        Node newPuzzle = currentNode.Clone() as Node;

                        newPuzzle.Puzzle[currentNode.Puzzle.IndexOf(0)] = newPuzzle.Puzzle[x * 4 + y];
                        newPuzzle.Puzzle[x * 4 + y] = currentNode.Puzzle[currentNode.Puzzle.IndexOf(0)];

                        if (!closedSets.Contains(newPuzzle))
                        {
                            newPuzzle.Parent = currentNode;
                            newPuzzle.Move = GetMoveKey((dx, dy));
                            newPuzzle.SetCost(_goalState);
                            openSet.Add(newPuzzle);
                        }
                    }
                }

            }

            return null;
        }

        private string GetMoveKey((int,int) move)
        {
            switch (move)
            {
                case (0,1):
                    return Keys.Down;
                case (0, -1):
                    return Keys.Up;
                case (1, 0):
                    return Keys.Right;
                case (-1, 0):
                    return Keys.Left;
                default:
                    return "";
            }
        }

        private void ResultStore(Node data)
        {
            string json = File.ReadAllText("./treino.json");
            List<Node> items = JsonConvert.DeserializeObject<List<Node>>(json) ?? new List<Node>();
            items.Add(data);
            File.WriteAllText("./treino.json", JsonConvert.SerializeObject(items));
        }
    }
}
