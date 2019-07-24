result = df; 
var n = df.Rows.Count; 
var g = int.Parse(kargs["gain"]); 
var f = int.Parse(kargs["cycles"]); 
result.Columns.Add(new DataColumn("fx", typeof(double))); 
foreach (var row in result.AsEnumerable()) 
{ 
    row["fx"] = g * Math.Sin((long)row["x"] / (double)n * 2 * Math.PI * f); 
}