namespace _15PuzzleDotNet
{
    public class Node : ICloneable
    {
        public List<int> Puzzle { get; set; }
        public Node? Parent { get; set; }
        public string Move { get; set; }
        private int _cost { get; set; }

        public Node(List<int> puzzle, Node? parent = null, string move = "")
        {
            this.Puzzle = puzzle;
            this.Parent = parent;
            this.Move = move;
            this._cost = 0;
        }

        public bool LessThen(Node other)
        {
            return _cost < other._cost;
        }

        public void SetCost(List<int> goalState)
        {
            int count = 0;
            for (int i = 0; i < Puzzle.Count; i++)
            {
                if (Puzzle[i] != goalState[i])
                    count += i;
            }

            _cost = count;
        }

        public object Clone()
        {
            return new Node(this.Puzzle.ConvertAll(p => p), this.Parent?.Clone() as Node, this.Move);
        }
    }
}
