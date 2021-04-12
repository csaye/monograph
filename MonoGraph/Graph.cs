using Microsoft.Xna.Framework;

namespace MonoGraph
{
    public class Graph
    {
        public Graph() { }

        const int m = 1;
        const int b = 0;

        public void Draw(Game1 game)
        {
            // Draw axes
            Rectangle xAxis = new Rectangle(0, Drawing.Height / 2, Drawing.Width, 1);
            Drawing.DrawRect(xAxis, Color.Gray, game);
            Rectangle yAxis = new Rectangle(Drawing.Width / 2, 0, 1, Drawing.Height);
            Drawing.DrawRect(yAxis, Color.Gray, game);

            // For each position along the x axis
            for (int gridX = 0; gridX < Drawing.GridWidth; gridX++)
            {
                int x = gridX - (Drawing.GridWidth / 2); // Calculate x
                int y = m * x + b; // Calculate y

                int rectX = gridX * Drawing.Grid; // Calculate rect x
                int rectY = (-y * Drawing.Grid) + (Drawing.Height / 2); // Calculate rect y

                // If y not within screen range, continue
                if (rectY < 0 || rectY >= Drawing.Height) continue;

                // Draw rect
                Rectangle rect = new Rectangle(rectX, rectY, Drawing.Grid, Drawing.Grid);
                Drawing.DrawRect(rect, Color.Black, game);
            }
        }
    }
}
