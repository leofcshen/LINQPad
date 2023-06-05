<Query Kind="Program" />

void Main() {
	
	//char
	string repeatChar = new string(Convert.ToChar('-'), 10);
	repeatChar.Dump();
	
	#region -- string --
	string value = "ABC";
	int times = 10;
	
	//方法一	
	string repeatString = new StringBuilder(value.Length * times).Insert(0, value, times).ToString();
	repeatString.Dump();
	
	//方法二
	string repeatString1 = string.Concat(Enumerable.Repeat(value, times));
	repeatString1.Dump();
	
	//方法三
	StringBuilder sb = new StringBuilder(value.Length * times);
	for (int i = 0; i < times; i++) {
		sb.Append(value);
	}
	string repeatString2 = sb.ToString();
	repeatString2.Dump();
	
	//方法四
	string repeatString3 = Enumerable.Range(0, times).Aggregate(new StringBuilder(value.Length * times), (sb, _) => sb.Append(value)).ToString();
	#endregion
	
	#region -- 使用擴充方法 --
	string repeatCharExtensions = StringExtensions.GetRepeatWord('-', times);
	repeatCharExtensions.Dump();
	
	string repeatStringExtensions = StringExtensions.GetRepeatWord("ABC", times);
	repeatStringExtensions.Dump();
	#endregion	 
}

string value = "ABC";
int times = 10;
string R1() => new StringBuilder(value.Length * times).Insert(0, value, times).ToString();
string R2() => string.Concat(Enumerable.Repeat(value, times));
string R3() => Enumerable.Range(0, times).Aggregate(new StringBuilder(value.Length * times), (sb, _) => sb.Append(value)).ToString();
string R4() {
	StringBuilder sb = new StringBuilder(value.Length * times);
	for (int i = 0; i < times; i++) {
		sb.Append(value);
	}
	return sb.ToString();
}