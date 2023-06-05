<Query Kind="Statements" />

var permission1 = EnumPermissionType.Read | EnumPermissionType.Add | EnumPermissionType.Edit;
permission1.Dump(nameof(permission1));
Convert.ToInt32(permission1).Dump("int of " + nameof(permission1));
CheckEnum(permission1);

Console.WriteLine(new string(Convert.ToChar('-'), 10));

var permission2 = EnumPermissionType.All;
permission2.Dump(nameof(permission2));
Convert.ToInt32(permission2).Dump("int of " + nameof(permission2));
CheckEnum(permission2);

static void CheckEnum(EnumPermissionType input) {
	foreach (EnumPermissionType permission in Enum.GetValues(typeof(EnumPermissionType))) {
		if ((input & permission) == permission) {
			Console.WriteLine("包含列舉值 " + permission);
		}
	}
}

[Flags]
public enum EnumPermissionType {
	None = 0,
	Read = 1,
	Add = 2,
	Edit = 4,
	Delete = 8,
	Print = 16,
	RunFlow = 32,
	Export = 64,
	All = Read | Add | Edit | Delete | Print | RunFlow
}

