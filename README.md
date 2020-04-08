# BannerGenerator
A bunch of utilities to generate banners for Mount &amp; Blade II: Bannerlord

## Setup

- Refernce the class library `BannerGenerator` in your project
- Use the methods named `Utilities.Generate()` to generate a banner code as a string

- To get a banner from an **item list** and a background (similar to https://bannerlord.party/banner/)

```cs
var backgroundParams = new BackgroundGeneratorParams {
	MeshId = BackgroundMesh.Fill,
	Colour1 = Colour.White,
	Colour2 = Colour.White,
};
var itemParams = new List<ItemGeneratorParams> {
	new ItemGeneratorParams
	{
		MeshId = Mesh.Bird0,
		Colour1 = Colour.Black,
		Colour2 = Colour.Black,
		Size = Utilities.SUGGESTED_ITEM_DIMENSIONS,
		AlignX = AlignX.Centre,
		AlignY = AlignY.Centre
	}
};
Console.WriteLine(Utilities.Generate(backgroundParams, itemParams));
```

- To get a banner for a **pattern** and a background

```cs
var backgroundParams = new BackgroundGeneratorParams {
	MeshId = BackgroundMesh.Fill,
	Colour1 = Colour.White,
	Colour2 = Colour.White,
};
var patternParams = new PatternGeneratorParams {
	MeshId = Mesh.Flora0,
	Type = PatternType.CrossDiagonal,
	Margin = 300,
	Colour1 = Colour.Black,
	Colour2 = Colour.Black,
	Size = Utilities.SUGGESTED_ITEM_DIMENSIONS,
};
Console.WriteLine(Utilities.Generate(backgroundParams, patternParams));
```