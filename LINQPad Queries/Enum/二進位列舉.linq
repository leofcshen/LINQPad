<Query Kind="Statements" />

//Action<EnumPermissionType> CheckEnum = (input) =>
//  Enum.GetValues(typeof(EnumPermissionType))
//    .Cast<EnumPermissionType>()
//    .Where(permission => (input & permission) == permission)
//    .ToList()
//    .ForEach(permission => ("包含列舉值 " + permission).Dump());
		
//void CheckEnum(EnumPermissionType input) {
//	foreach (EnumPermissionType permission in Enum.GetValues(typeof(EnumPermissionType))) {
//		if ((input & permission) == permission) {			
//			("包含列舉值 " + permission).Dump();
//		}
//	}
//}

//void CheckEnum<T>(T input) where T : Enum {
//	foreach (T permission in Enum.GetValues(typeof(T))) {
//		if ((Convert.ToInt32(input) & Convert.ToInt32(permission)) == Convert.ToInt32(permission)) {			
//			("包含列舉值 " + permission).Dump();
//		}
//	}
//}

void CheckEnum<T>(T input) where T : Enum {
  Enum.GetValues(typeof(T))
    .OfType<T>()
    .Where(permission => (Convert.ToInt32(input) & Convert.ToInt32(permission)) == Convert.ToInt32(permission))
    .ToList()
    .ForEach(permission => ("包含列舉值 " + permission).Dump());
}

var permission1 = EnumPermissionType.Read | EnumPermissionType.Add | EnumPermissionType.Edit;
permission1.Dump(nameof(permission1));
Convert.ToInt32(permission1).Dump("int of " + nameof(permission1));
CheckEnum(permission1);

(new string(Convert.ToChar('='), 100)).Dump();
/////////////////////////////////////////////////////////////////////////////////////////////

var permission2 = EnumPermissionType.AllExcludeExport;
permission2.Dump(nameof(permission2));
Convert.ToInt32(permission2).Dump("int of " + nameof(permission2));
CheckEnum(permission2);

var permission3 = EnumPermissionType1.AA | EnumPermissionType1.CC;
permission3.Dump(nameof(permission3));
Convert.ToInt32(permission3).Dump("int of " + nameof(permission3));
CheckEnum(permission3);

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
	AllExcludeExport = Read | Add | Edit | Delete | Print | RunFlow
}

[Flags]
public enum EnumPermissionType1 {
	None = 0,
	AA = 1,
	BB = 2,
	CC = 4
}

