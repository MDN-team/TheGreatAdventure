using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TheGreatAdventure
{
    public partial class GameView
    {
        public class Zombie
        {
            public Image ZombieImg = new Bitmap(Image.FromFile(@"../../Zombie.png"), 200, 350);
            private int speed;
            private static Timer zombieStepInterval = new Timer();

            public int X, Y;

            public Zombie(int x, int y)
            {
                speed = 50;
                X = x;
                Y = y;
            }

            public void Move()
            {
                var to = FindBestStepToPlayer();
                X += speed * to.X;
                Y += speed * to.Y;
            }
            
            static IEnumerable<Point> Steps(Point from)
            {
                yield return new Point(from.X - 1, from.Y);
                yield return new Point(from.X + 1, from.Y);
                yield return new Point(from.X, from.Y - 1);
                yield return new Point(from.X, from.Y + 1);
            }

            static IEnumerable<Point> ValidSteps(Point pos) =>
                Steps(pos).Where(x => map.IsOnMap(pos.X, pos.Y));

            private Point FindBestStepToPlayer()
            {
                var visited = new HashSet<Point>();
                var queue = new Queue<WayTracker<Point>>();
                queue.Enqueue(new WayTracker<Point>(new Point(X, Y)));
                visited.Add(new Point(X, Y));
                var result = new WayTracker<Point>(new Point(X, Y));
                while (queue.Count != 0)
                {
                    var current = queue.Dequeue();

                    foreach (var step in ValidSteps(current.Value))
                    {
                        if (visited.Contains(step)) continue;
                        var next = new WayTracker<Point>(step, current);
                        visited.Add(step);
                        queue.Enqueue(next);
                        if (step == new Point(player.X, player.Y))
                        {
                            result = next;
                            break;
                        }
                    }
                }

                var list = result.ToList();
                list.Reverse();
                var endPoint = list.FirstOrDefault();

                return new Point(endPoint.X - X, endPoint.Y - Y);
            }
        }

        public class WayTracker<T> : IEnumerable<T>
        {
            public readonly T Value;
            public readonly WayTracker<T> Previous;
            
            public WayTracker(T value, WayTracker<T> previous = null)
            {
                Value = value;
                Previous = previous;
            }
            public IEnumerator<T> GetEnumerator()
            {
                yield return Value;
                var pathItem = Previous;
                while (pathItem != null)
                {
                    yield return pathItem.Value;
                    pathItem = pathItem.Previous;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}