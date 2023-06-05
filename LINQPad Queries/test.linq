<Query Kind="Statements">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Jobs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
</Query>

BenchmarkRunner.Run<MyClass>();



[MemoryDiagnoser]
public class MyClass {
	//轉成暗碼 Pas*********
	private const string ClearValue = "Password123!";

	/// <summary>
	/// 幼稚園方法
	/// <para>記憶體耗費 400 B</para>
	/// </summary>
	[Benchmark]
	public string MaskNaive() {
		var firstChars = ClearValue.Substring(0, 3);
		var length = ClearValue.Length - 3;
		for (int i = 0; i < length; i++) {
			// string 是 immutable，每次都 allocate 新的 string
			firstChars += '*';
		}
		return firstChars;
	}

	/// <summary>
	/// 使用 StringBuilder
	/// <para>記憶體耗費 184 B</para>
	/// </summary> 
	[Benchmark]
	public string MaskStringBuilder() {
		var firstChars = ClearValue.Substring(0, 3);
		var length = ClearValue.Length - 3;
		var stringBuilder = new StringBuilder(firstChars);
		for (int i = 0; i < length; i++) {
			stringBuilder.Append('*');
		}
		//ToString() 時才分配
		return stringBuilder.ToString();
	}

	/// <summary>
	/// 使用 New String
	/// <para>記憶體耗費 120 B</para>
	/// </summary>
	[Benchmark]
	public string MaskNewString() {
		var firstChars = ClearValue.Substring(0, 3);
		var length = ClearValue.Length - 3;
		var asterisks = new string('*', length);
		return firstChars + asterisks;
	}


	/// <summary>
	/// 使用 span
	/// <para>記憶體耗費 48 B</para>
	/// </summary>
	[Benchmark]
	public string MaskStringCreate() {
      return string.Create(ClearValue.Length, ClearValue, (span, value) => {
        value.AsSpan().CopyTo(span);
        span[3..].Fill('*');
      });
	}

	/// <summary>
	/// 使用 Padding
	/// <para>記憶體耗費 80 B</para>
	/// </summary>
	[Benchmark]
	public string MaskPadding() {
		var firstChars = ClearValue.Substring(0, 3);
		var length = ClearValue.Length;
		//Paddin 底層也是使用 span
		return firstChars.PadRight(length, '*');
	}
}