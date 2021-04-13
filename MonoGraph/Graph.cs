using Microsoft.Xna.Framework;
using System;

namespace MonoGraph
{
    public class Graph
    {
        public Graph() { }

        // Equation in form c[0]x^0 + c[1] x^1 + ... + c[n - 1] x^(n-1) + c[n] x^n
        private readonly float[] constants = new float[] { 0, 0, 0, 1 };

        // Graph scale
        private const float scale = 0.01f;

        public void Draw(Game1 game)
        {
            // Draw axes
            Rectangle xAxis = new Rectangle(0, Drawing.Height / 2, Drawing.Width, 1);
            Drawing.DrawRect(xAxis, Color.LightGray, game);
            Rectangle yAxis = new Rectangle(Drawing.Width / 2, 0, 1, Drawing.Height);
            Drawing.DrawRect(yAxis, Color.LightGray, game);

            // For each position along the x axis
            for (int gridX = 0; gridX < Drawing.GridWidth; gridX++)
            {
                // Calculate x and y
                float x = (gridX - (Drawing.GridWidth / 2)) * scale;
                float y = 0;
                float nextY = 0;
                for (int power = 0; power < constants.Length; power++)
                {
                    float constant = constants[power];
                    y += constant * (float)Math.Pow(x, power);
                    nextY += constant * (float)Math.Pow(x + scale, power);
                }
                y /= scale;
                nextY /= scale;

                // Calculate height of segment
                float height = (nextY - y) * Drawing.Grid;
                if (Math.Abs(height) < 1) height = 1;

                // Calculate rect x and y
                int rectX = gridX * Drawing.Grid; // Calculate rect x
                int rectY = (int)(-y * Drawing.Grid) + (Drawing.Height / 2); // Calculate rect y

                // If y not within screen range, continue
                if (rectY < 0 || rectY - height > Drawing.Height) continue;

                // Draw rect
                if (height > 0) rectY -= (int)height;
                Rectangle rect = new Rectangle(rectX, rectY, Drawing.Grid, (int)Math.Abs(height));
                Drawing.DrawRect(rect, Color.Black, game);
            }

            // Get and draw equation text
            string equation = "";
            // For each term
            for (int power = constants.Length - 1; power >= 0; power--)
            {
                float constant = constants[power]; // Get constant
                if (constant == 0) continue; // Continue if constant zero
                // If equation not empty
                if (equation != "")
                {
                    if (constant > 0) equation += " + "; // Positive constant
                    else equation += " - "; // Negative constant
                // If equation empty
                } else if (constant < 0) equation += "-"; // Negative constant
                if (Math.Abs(constant) != 1 || power == 0) equation += Math.Abs(constant); // Constant absolute value
                if (power == 1) equation += "x"; // Power of one
                else if (power != 0) equation += $"x^{power}"; // Nonzero power
            }
            if (equation == "") equation = "0"; // Zero if equation empty
            equation = "y = " + equation; // Prefix with y =
            Drawing.DrawText(equation, new Vector2(8, 8), Color.Black, game); // Draw text

            // Draw scale text
            float minX = -(Drawing.GridWidth / 2) * scale;
            float minY = -(Drawing.GridHeight / 2) * scale;
            string minText = $"min: ({minX}, {minY})";
            Drawing.DrawText(minText, new Vector2(8, 24), Color.Black, game);
            float maxX = (Drawing.GridWidth / 2) * scale;
            float maxY = (Drawing.GridHeight / 2) * scale;
            string maxText = $"max: ({maxX}, {maxY})";
            Drawing.DrawText(maxText, new Vector2(8, 40), Color.Black, game);
        }
    }
}
