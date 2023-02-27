using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandExample
{

    public struct Position
    {
        public static Position Create(int x, int y)
        {
            if (x > Settings.MaxSize || y > Settings.MaxSize) throw new Exception("maxSize exceeded");

            return new Position(x, y);
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            Position pos1 = (Position)obj;

            return pos1.X == X && pos1.Y == Y;
        }
    }



    public abstract class BaseEntity
    {

        protected readonly int _id;

        public int Id => _id;
        protected BaseEntity(Position position)
        {
            Position = position;
        }

        public Position Position { get; protected set; }


    }

    public class Stone : BaseEntity
    {


        public Stone(Position position) : base(position) { }

        public override string ToString()
        {
            return $"{nameof(Stone)} {Position.X} {Position.Y}";
        }
    }


    //public interface IMoveAble
    //{

    //    public void MoveTo(int deltaX, int deltaY);
    //}

    public class Human : BaseEntity
    {

        public Human(Position position) : base(position) { }


        public void MoveTo(int deltaX, int deltaY)
        {

            Position = new Position(Position.X + deltaX, Position.X + deltaY);
        }

        public override string ToString()
        {
            return $"{nameof(Human)} {Position.X} {Position.Y}";
        }
    }


    public class Horse : BaseEntity
    {

        public Horse(Position position) : base(position) { }


        public void MoveTo(int deltaX, int deltaY)
        {

            Position = new Position(Position.X + deltaX, Position.X + deltaY);
        }

        public override string ToString()
        {
            return $"{nameof(Human)} {Position.X} {Position.Y}";
        }
    }

    public struct Settings
    {

        public const int MaxSize = 3;
    }

    public interface IMoveCommand
    {

        void Move(int x, int y);

        void Undo();
    }

    public class MoveHumanCommand : IMoveCommand
    {


        private Human _human;
        private Position _positionDelta;

        public MoveHumanCommand(Human human)
        {
            _human = human;
        }

        public void Move(int x, int y)
        {

            //  _position = _positionDelta.;

            _human.MoveTo(x, y);


        }

        public void Undo()
        {

            _human.MoveTo(_human.Position.X - 1, _human.Position.Y - 1);
        }

    }


    public class Game
    {


        private static int _counter = 0;

        protected readonly bool canAdd = true;

        protected readonly List<BaseEntity> _entities = new List<BaseEntity>();

        public virtual IReadOnlyCollection<BaseEntity> Entities => _entities;

        public void AddEntity(BaseEntity entity)
        {

            if (!_entities.Any(x => x.Position.Equals(entity.Position)))

                _entities.Add(entity);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var entity in _entities)
            {

                sb.AppendLine(entity.ToString());
            }
            return sb.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();


            Human h1 = new Human(Position.Create(1, 2));

            var command = new MoveHumanCommand(h1);

            game.AddEntity(h1);

            command.Move(1, 1);

            Console.Write(game);

            command.Undo();

            Console.Write(game);

            Console.ReadKey();

            //game.AddEntity(new Human(Position.Create(1, 1)));

            //game.AddEntity(new Stone(Position.Create(2, 3)));

            //game.AddEntity(new Stone(Position.Create(3, 3)));

            //Console.Write(game);

            //h1.MoveTo(2, 2);

            //Console.Write(game);

            Console.ReadKey();
        }
    }
}
