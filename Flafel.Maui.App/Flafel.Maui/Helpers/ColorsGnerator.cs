namespace Flafel.Maui.Helpers
{
    public static class ColorsGnerator
    {
        public static string GenerateRandomPastelColor()
        {
            var random = new Random();
            var hue = random.Next(0, 360);
            var saturation = random.Next(70, 101);
            var lightness = random.Next(40, 71);

            return $"hsl({hue}, {saturation}%, {lightness}%)";
        }
    }
}
