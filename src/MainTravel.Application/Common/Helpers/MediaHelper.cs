namespace MainTravel.Application.Common.Helpers
{
    public class MediaHelper
    {
        public static string DefaultImagePath { get; } = "media/images/default.png";

        public static string MakeImageName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string extension = fileInfo.Extension;
            string name = "IMAGE_" + Guid.NewGuid() + extension;

            return name;
        }

        public static string[] GetImageExtensions()
        {
            return new string[]
            {
                ".png",
                ".avg",
                ".jpg",
                ".jpeg",
            };
        }
    }
}