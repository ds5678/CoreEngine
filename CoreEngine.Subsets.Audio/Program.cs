namespace CoreEngine.Subsets.Audio;

internal class Program
{
	static void Main(string[] args)
	{
		foreach (string device in OpenTK.Audio.OpenAL.ALC.GetString(OpenTK.Audio.OpenAL.AlcGetStringList.AllDevicesSpecifier))
		{
			Console.WriteLine(device);
		}
		Console.WriteLine("Done!");
	}
}
