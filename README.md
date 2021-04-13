# MonoGraph
A graphing tool built in MonoGame.

![Graph](https://user-images.githubusercontent.com/27871609/114557820-49c16200-9c27-11eb-8167-071790a3d2a0.png)

## Installation/Running

Ensure [Visual Studio](https://visualstudio.microsoft.com/downloads/) and [MonoGame](https://www.monogame.net/downloads/) are installed.

Clone the project by running `git clone https://github.com/csaye/monograph`

Open in Visual Studio and press the big play button or use F5 to run.

## Settings

[Drawing.cs](MonoGraph/Drawing.cs)
```cs
public const int Grid = 1; // Size of grid
public const int GridWidth = 512; // Width of grid
public const int GridHeight = 512; // Height of grid
```

[Graph.cs](MonoGraph/Graph.cs)
```cs
// Equation in form c[0]x^0 + c[1] x^1 + ... + c[n - 1] x^(n-1) + c[n] x^n
// Ex. { 0, 0, 0, 1 } graphs 0 + 0x + 0x^2 + 1x^3 = x^3
private readonly float[] constants = new float[] { 0, 0, 0, 1 };

// Graph scale (modifies graph min/max)
// Width/height is 512, so a scale of 0.01 = min/max of (-2.56, -2.56) to (2.56, 2.56)
private const float scale = 0.01f;
```
