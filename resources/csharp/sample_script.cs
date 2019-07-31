public DataTable Process(DataTable inputTable, Dictionary<string, string> args)
{
	DataTable output = df; 
	var n = df.Rows.Count; 
	var g = int.Parse(args["gain"]); 
	var f = int.Parse(args["cycles"]); 
	output.Columns.Add(new DataColumn("fx", typeof(double))); 
	foreach (var row in output.AsEnumerable()) 
	{ 
		row["fx"] = g * Math.Sin((long)row["x"] / (double)n * 2 * Math.PI * f); 
	}
	
	return result;
}