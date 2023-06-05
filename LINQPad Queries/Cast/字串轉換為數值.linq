<Query Kind="Statements" />

#region -- Parse --
string str1 = "1";
int number1 = int.Parse(str1);
number1.Dump("int.Parse(1)");

string str2 = "abc";
try {
	//失敗會 exception
	int number2 = int.Parse(str2);
} catch (Exception ex) {
	ex.Message.Dump("int.Parse(\"\")");
}
#endregion

#region -- TryParse --
string str3 = "3";
bool castSuccess1 = int.TryParse(str3, out int numValue1);
numValue1.Dump("int.TryParse(\"3\")");

string str4 = "abc";
bool castSuccess2 = int.TryParse(str4, out int numValue2);
numValue2.Dump("int.TryParse(\"abc\")，轉型失敗 會是 int 的 default 0");

if(int.TryParse(str4, out int numValue3)){
	numValue3.Dump();
}
#endregion

#region -- Convert --
string str5 = "5";
int number5 = Convert.ToInt32(str5);
number5.Dump("Convert.ToInt32(\"5\")");

string str6 = "abc";
try {
	int number6 = Convert.ToInt32(str6);
	number6.Dump("Convert.ToInt32(\"5\")");
} catch (Exception ex) {
	ex.Message.Dump("Convert.ToInt32(\"abc\")");
}
#endregion
