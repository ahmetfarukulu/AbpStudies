namespace Allegory.Sample.Permissions
{
    public class SamplePermissions
    {
        public const string GroupName = "Sample";

        public static class Products
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
