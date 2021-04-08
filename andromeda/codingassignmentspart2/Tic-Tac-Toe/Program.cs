using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public enum State { undecided, X, O, };
    public class Position
    {
        public int Row { get; }
        public int Column { get; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
    public class Board
    {
        private State[,] state;
        public State NextTurn { get; private set; }
        public Board()
        {
            state = new State[3, 3];
            NextTurn = State.X;
        }
        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }
        public bool SetState(Position position,State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Column] != State.undecided) return false;
            state[position.Row, position.Column] = newState;
            SwitchNextTurn();
            return true;
        }
        private void SwitchNextTurn()
        {
            if (NextTurn == State.X) NextTurn = State.O;
            else NextTurn = State.X;
        }
    }
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForWin(board, State.X)) return State.X;
            if (CheckForWin(board, State.O)) return State.O;
             return State.undecided;
        }
        private bool CheckForWin(Board board,State player)
        {
            for (int row=0; row<3;row++)
            
        }
    }
}
