﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Snake
    {
        #region Fields

        private readonly int _elementSize;
        private double _speed = 4;

        #endregion

        #region Properties

        public SnakeElement TailBackup { get; set; }

        public List<SnakeElement> Elements { get; set; }

        public MovementDirection MovementDirection { get; set; }

        public SnakeElement Head => Elements.Any() ? Elements[0] : null;

        #endregion

        #region Ctor

        public Snake(int elementSize)
        {
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }

        #endregion

        #region Methods

        internal void UpdateMovementDirection(MovementDirection up)
        {
            switch (up)
            {
                case MovementDirection.Up:
                    if (MovementDirection != MovementDirection.Down)
                        MovementDirection = MovementDirection.Up;
                    break;
                case MovementDirection.Left:
                    if (MovementDirection != MovementDirection.Right)
                        MovementDirection = MovementDirection.Left;
                    break;
                case MovementDirection.Down:
                    if (MovementDirection != MovementDirection.Up)
                        MovementDirection = MovementDirection.Down;
                    break;
                case MovementDirection.Right:
                    if (MovementDirection != MovementDirection.Left)
                        MovementDirection = MovementDirection.Right;
                    break;
            }
        }

        internal void Grow()
        {
            //for (int i = 0; i < 5; i++)
            //{

            var newElement = new SnakeElement(_elementSize)
            {
                X = TailBackup.X,
                Y = TailBackup.Y
            };


            Elements.Add(newElement);
            //}
        }

        public bool CollisionWithSelf()
        {
            SnakeElement source = Head;
            if (source != null)
            {
                foreach (var target in Elements)
                {
                    if (!target.IsHead)
                    {
                        if (target.X == source.X && target.Y == source.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal void PositionFirstElement(double x, double y, MovementDirection initialDirection)
        {
            Elements.Add(new SnakeElement(_elementSize)
            {
                X = x,
                Y = y,
                IsHead = true
            });
            MovementDirection = initialDirection;
        }

        internal void MoveSnake()
        {
            SnakeElement head = Elements[0];
            SnakeElement tail = Elements[Elements.Count - 1];

            TailBackup = new SnakeElement(_elementSize)
            {
                X = tail.X,
                Y = tail.Y
            };

            head.IsHead = false;
            tail.IsHead = true;

            tail.X = head.X;
            tail.Y = head.Y;

            switch (MovementDirection)
            {
                case MovementDirection.Right:
                    tail.X += _speed;
                    //tail.BorderThickness = new Microsoft.UI.Xaml.Thickness(0, 0, 5, 0);

                    break;
                case MovementDirection.Left:
                    tail.X -= _speed;
                    //tail.BorderThickness = new Microsoft.UI.Xaml.Thickness(5, 0, 0, 0);

                    break;
                case MovementDirection.Up:
                    tail.Y -= _speed;
                    //tail.BorderThickness = new Microsoft.UI.Xaml.Thickness(0, 5, 0, 0);

                    break;
                case MovementDirection.Down:
                    tail.Y += _speed;
                    //tail.BorderThickness = new Microsoft.UI.Xaml.Thickness(0, 0, 0, 5);

                    break;
                default:
                    break;
            }            

            Elements.RemoveAt(Elements.Count - 1);
            Elements.Insert(0, tail);
        }

        #endregion
    }

    public enum MovementDirection
    {
        Right,
        Left,
        Up,
        Down
    }
}
