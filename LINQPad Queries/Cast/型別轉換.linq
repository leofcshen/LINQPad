<Query Kind="Statements" />

#region -- 隱含轉換 --
#region -- 數值 --
//long(64 位元整數) 可儲存任何 int(32 位元整數)
int num = 2147483647;
long bigNum = num;
#endregion

#region -- 參考型別 --
//針對參考型別，一律會執行從某個類別到其任何一個直接或間接基底類別或介面的隱含轉換。
//因為衍生類別一律會包含基底類別的所有成員，所以不需要特殊語法。
Derived d = new Derived();
Base b = d;

//從基底類別無法隱含轉換為衍生類別，要用明確轉換
//Base bb = new Base();
//Derived dd = bb;
#endregion
#endregion

#region -- 明確轉換 --
#region -- 數值 --
double x = 1234.7;
int a =(int)x;
a.Dump(); //1234
#endregion

#region -- 參考型別 --
//基底類型轉換為衍生類型，需要明確轉換
Derived dd = new Derived();
Base bb = dd;
Derived ddd = (Derived)bb;

//下列轉型執行階段會出錯
//Base bbb = new Base();
//Derived dddd = (Derived)bbb;
#endregion
#endregion

//在某些參考型別轉換中，編譯器無法判斷轉換是否有效。 正確編譯的轉型作業可能會在執行階段失敗。
Test(new Mammal());

static void Test(Animal a) {
	// 執行階段出錯
	// System.InvalidCastException at run time
	// Unable to cast object of type 'Mammal' to type 'Reptile'
	Reptile r = (Reptile)a;
}

public class Base { }

public class Derived : Base { }

class Animal {
	public void Eat() => Console.WriteLine("Eating.");
	public override string ToString() => "I am an animal.";
}

class Reptile : Animal { }
class Mammal : Animal { }

