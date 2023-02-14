namespace Level2_Task1_Userinterface
{
    public static class PathClass
    {
        public static readonly string defaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly string configPath = @"Resources\Config.json";
        public static readonly string testDataPath = @"Resources\TestData.json";
        public static readonly string expectedResultsPath = @"Resources\ExpectedResults.json";
        public static readonly string avatarImagePath = defaultPath + @"\Resources\sample_image.jpg";
    }
}
