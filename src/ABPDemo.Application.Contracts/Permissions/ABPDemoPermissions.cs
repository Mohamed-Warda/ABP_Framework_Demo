namespace ABPDemo.Permissions;

public static class ABPDemoPermissions
{
    public const string GroupName = "ABPDemo";

    // Permissions Names
    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class ProductPermissions
    {
        public const string MainGroupName = "Product";

        //Product Group & Permissions
        public const string ProductGroupName = MainGroupName + ".Products";
        public const string CreateEditProductPermission = ProductGroupName + ".CreateEdit";
        public const string DeleteProductPermission = ProductGroupName + ".Delete";
        public const string GetProductPermission = ProductGroupName + ".Get";
        public const string ListProductPermission = ProductGroupName + ".List";
    }
}
