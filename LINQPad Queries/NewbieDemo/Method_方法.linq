<Query Kind="Statements" />

//一般方法
string CheckGreaterThan2(int pNumber) {
	if(pNumber > 2){
		return $"{pNumber} 大於 2";
	}
	return $"{pNumber} 不大於 2";
}

CheckGreaterThan2(2).Dump(nameof(CheckGreaterThan2));
CheckGreaterThan2(3).Dump(nameof(CheckGreaterThan2));

//Lambda 運算式
string CheckGreaterThan2_Lambda(int pNumber) => $"{pNumber} {(pNumber > 2 ? string.Empty : "不")}大於 2";
//string CheckGreaterThan2_Lambda(int pNumber) => pNumber > 2 ? $"{pNumber} 大於 2" : $"{pNumber} 不大於 2";

CheckGreaterThan2_Lambda(2).Dump(nameof(CheckGreaterThan2_Lambda));
CheckGreaterThan2_Lambda(3).Dump(nameof(CheckGreaterThan2_Lambda));

//Lamda 運算式的參數在編譯時為強型別，編譯器推斷得出參數型別時可省略型別宣告
int[] numbers = { 4, 7, 10};
int product = numbers.Aggregate(1, (interim, next) => interim * next);
product.Dump();

//匿名方法
