// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        static int[] canvasSize = [600,600];
        static int[][] myList = [[12],[34]];
        

        

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 
        
        public Vector2 TransformVerticies(Vector2 v)
        {
            
            float xFactor = (canvasSize[0]) / 2;
            float yFactor = (canvasSize[1]) / 2;

            // Math is x*(w/2)+w/2  >   (x+1)(w/2)

            v.X = (v.X + 1.0f) * xFactor;
            v.Y = (v.Y + 1.0f) * yFactor;

            return v;
        }

        public void DrawCube(float size)
        {
            float side = (size / 2.0f);
            /*
            Vector3[] verticies = [
                new Vector3(-side, -side, -side),   // 0
                new Vector3(side, -side, -side),    // 1
                new Vector3(-side, side, -side),    // 2
                new Vector3(side, side, -side),     // 3
                new Vector3(-side, -side, side),    // 4
                new Vector3(side, -side, side),     // 5
                new Vector3(-side, side, side),     // 6
                new Vector3(side, side, side)       // 7
                ];
            Vector2[] verticies = [
                new Vector2(-side / -side, -side / -side),   // 0
                new Vector2(side / -side, -side / -side),    // 1
                new Vector2(-side / -side, side / -side),    // 2
                new Vector2(side / -side, side / -side),     // 3
                new Vector2(-side / side, -side / side),    // 4
                new Vector2(side / side, -side / side),     // 5
                new Vector2(-side / side, side / side),     // 6
                new Vector2(side / side, side / side)       // 7
                ];
             */
            Vector2[] verticies = [
                new Vector2(-side, -side),   // 0
                new Vector2(side, -side),    // 1
                new Vector2(-side, side),    // 2
                new Vector2(side, side),     // 3
                new Vector2(-side, -side),    // 4
                new Vector2(side, -side),     // 5
                new Vector2(-side, side),     // 6
                new Vector2(side, side)       // 7
                ];

            int[][] assignPoints = [
                [0, 1], [1, 3], [3, 2], [2, 0],
                [0, 4], [1, 5], [3, 7], [2, 6],
                [4, 6], [5, 7], [7, 6], [6, 4]
                ];
            for (int i = 0; i < verticies.Length; i++)
            {
                verticies[i] = TransformVerticies(verticies[i]);
            }
            for (int i = 0; i < assignPoints.Length; i++)
            {
                Draw.Line(verticies[assignPoints[i][0]], verticies[assignPoints[i][1]]);
            }
        }

        public void Setup()
        {
            Window.SetSize(canvasSize[0], canvasSize[1]);
            Window.TargetFPS = 60;
            Window.SetTitle("2D Drawing - Christopher Lawrick-McKinnon");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White); // Clear screen
            DrawCube(1f);

            // Convert every verticy to screenspace
            
        }
    }

}
