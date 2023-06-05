<Query Kind="Statements" />

int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
array.Dump();

int[,] newArray = ReverseArray(array);
newArray.Dump();


static void PrintArray(int[,] pArray) {
	for (int i = 0; i < pArray.GetLength(0); i++)
	{
		for (int j = 0; j < pArray.GetLength(1); j++)
			Console.Write(pArray[i, j]);
		Console.WriteLine();
	}
}

#region -- 反轉陣列 --
/// <summary>
/// 反轉陣列
/// </summary>
static int[,] ReverseArray(int[,] pArray) {
	int rows = pArray.GetLength(0);
	int cols = pArray.GetLength(1);

	int[,] array = new int[cols, rows];

	for (int i = 0; i < cols; i++)
	{
		for (int j = 0; j < rows; j++)
		{
			array[i, j] = pArray[j, i];
		}
	}

	return array;
}
#endregion