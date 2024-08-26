In MainWindow.xaml.cs replace "xml" to "json" inn26 line to use json format
string format = "xml";



Example json
```json
[
  {
    "type": "line",
    "a": "10; 10",
    "b": "300; 200",
    "color": "127; 0; 255; 255"
  },
  {
    "type": "circle",
    "center": "100; 10",
    "radius": 15.0,
    "filled": false,
    "color": "127; 255; 0; 255"
  },
  {
    "type": "triangle",
    "a": "10; 10",
    "b": "10; 200",
    "c": "300; 300",
    "filled": true,
    "color": "127; 0; 255; 255"
  }
]
```


Example xml

```xml
<Shapes>
	<Shape type="line">
		<a>10; 10</a>
		<b>300; 200</b>
		<color>127; 0; 255; 255</color>
	</Shape>
	<Shape type="circle">
		<center>120; 75</center>
		<radius>13.0</radius>
		<filled>true</filled>
		<color>127; 255; 0; 255</color>
	</Shape>
	<Shape type="triangle">
		<a>100; 50</a>
		<b>10; 200</b>
		<c>300; 300</c>
		<filled>true</filled>
		<color>127; 0; 255; 255</color>
	</Shape>
</Shapes>
```
