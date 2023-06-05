<Query Kind="Program" />

void Main() {
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class StringsExtensions {
	/// <summary>
	/// 產生重複文字
	/// </summary>
	public static string GetRepeatWord<T>(T pData, int pCount) {
		if (pData is null) throw new ArgumentNullException(nameof(pData));
		if (pData is char ch) return new string(ch, pCount);
		if (pData is string str) {

			//StringBuilder sb = new StringBuilder(str.Length * pCount);
			//for (int i = 0; i < pCount; i++) {
			//	sb.Append(str);
			//}
			//
			//return sb.ToString();
			return string.Concat(Enumerable.Repeat(pData, 10));
		}

		throw new ArgumentException($"pData 資料型別不可為 {typeof(T)}, 型別限制為 {typeof(char)} 或 {typeof(string)}。");
	}
}

