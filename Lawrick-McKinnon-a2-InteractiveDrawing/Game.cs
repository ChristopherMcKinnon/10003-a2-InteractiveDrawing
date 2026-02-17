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
        static int[] canvasSize = [600,800];
        static int scale;
        static int screenDiffX = 0;
        static int screenDiffY = 0;


        static Vector2[] musclePoints = [
            new Vector2(0.2324f, 0.0159f), // A 0
            new Vector2(0.4447f, 0.0720f), // B 1
            new Vector2(0.5609f, 0.0765f), // C 2
            new Vector2(0.9021f, 0.1189f), // D 3
            new Vector2(0.7128f, 0.1011f), // E 4
            new Vector2(0.7128f, 0.1011f), // F 5
            new Vector2(0.9228f, 0.1212f), // G 6
            new Vector2(0.9809f, 0.0921f), // H 7
            new Vector2(1.0479f, 0.1189f), // I 8 
            new Vector2(-0.1847f, -0.0878f), // J 9
            new Vector2(0.9630f, 0.0385f), // K 10 
            new Vector2(0.1632f, -0.0910f), // L 11
            new Vector2(0.5251f, -0.1848f), // M 12
            new Vector2(0.3352f, -0.1826f), // N 13
            new Vector2(0.0425f, -0.0798f), // O 14
            new Vector2(0.7859f, -0.1224f), // P 15
            new Vector2(0.9608f, -0.0798f), // Q 16
            new Vector2(0.8550f, -0.0104f), // R 17
            new Vector2(0.1808f, -0.1843f), // S 18
            new Vector2(0.0492f, -0.1647f), // T 19
            new Vector2(-0.0360f, -0.1886f), // U 20
            new Vector2(-0.6738f, -0.0275f), // V 21
            new Vector2(-0.1155f, -0.1650f), // W 22
            new Vector2(-0.2465f, -0.1628f), // Z 23
            new Vector2(-0.6480f, -0.1113f), // A1 24
            new Vector2(-0.7382f, -0.1414f), // B1 25
            new Vector2(0.1265f, 0.0180f), // C1 26
            new Vector2(0.0314f, -0.0143f), // D1 27
            new Vector2(-0.0382f, -0.0490f), // E1 28
            new Vector2(-0.1242f, 0.0159f), // F1 29
            new Vector2(-0.3667f, 0.0175f), // G1 30
            new Vector2(0.3773f, -0.1289f), // H1 31
            new Vector2(0.6497f, -0.1354f), // I1 32
            new Vector2(0.3773f, 0.0202f), // J1 33
            new Vector2(0.6489f, 0.0289f), // K1 34

            ];

        static int[][] assignMusclePoints = [
                [0,1], [1,2], [2,5], [5,4],
                [2,3], [4,6], [6,7], [7,8],
                [7,8], [3,10], [10,7], [14,11],
                [11,13], [13,12], [12,15], [15,16],
                [0,26], [26,27], [27,29], [29,30],
                [25,24], [24,23], [23,22], [20,19],
                [19,14], [9,24], [0,33], [34,33],
                [34,3], [15,32], [32,31], [31,11],
                [14,0], [19,18], [18,13], [16,17],
                [17,10], [20,22], [21,30], [9,28],
                [27,28], [28,14]
                
                ];
        static void DrawMuscles()
        {
            for (int i = 0; i < assignMusclePoints.Length; i++)
            {
                // musclePoints[assignMusclePoints[i][0]]
                Draw.Line(TransformVerticies(musclePoints[assignMusclePoints[i][0]]) , TransformVerticies(musclePoints[assignMusclePoints[i][1]]));
            }
        }
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 

        static public Vector2 TransformVerticies(Vector2 v)
        {
            // Not sure if i can use Math.Min() here, so I made my own check
            if (canvasSize[0] < canvasSize[1])
            {
                scale = canvasSize[0]/2;
                screenDiffY = (canvasSize[1] - canvasSize[0])/2;
            } else
            {
                scale = canvasSize[1]/2;
                screenDiffX = (canvasSize[0] - canvasSize[1])/2;
            }

            // Math is x*(w/2)+w/2  >   (x+1)(w/2)

            v.X = (v.X + 1.0f) * (scale + screenDiffX);
            v.Y = (-v.Y + 1.0f) * (scale + screenDiffY);

            return v;
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

            DrawMuscles();
            // Convert every verticy to screenspace
            
        }
    }

}
