<Query Kind="Program" />

void Main() {
	//方法一
	string value = "ABC";

	R1().Dump();
	R2().Dump();
	//R3(value,10).Dump();

	//方法三
	StringBuilder sb = new StringBuilder(value.Length * 10);
	for (int i = 0; i < 10; i++) {
		sb.Append(value);
	}
	string repeatString2 = sb.ToString();
	repeatString2.Dump();
}

string value = "ABCD";
int times=10;
string R3() => Enumerable.Range(0, times).Aggregate(new StringBuilder(value.Length * times), (sb, _) => sb.Append(value)).ToString();


string R1() => new StringBuilder(value.Length * 10).Insert(0, value, 10).ToString();
string R2() => string.Concat(Enumerable.Repeat(value, 10));
string R4() {
	StringBuilder sb = new StringBuilder("ABCD".Length * 10);
	for (int i = 0; i < 10; i++) {
		sb.Append(value);
	}
	return sb.ToString();
}
