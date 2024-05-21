using OpenTK.Audio.OpenAL;

namespace CoreEngine.Subsets.Audio;

internal class Program
{
	static void Main(string[] args)
	{
		{
			ALDevice device = ALC.OpenDevice(null);
			ALContext context = ALC.CreateContext(device, (int[]?)null);
			ALC.MakeContextCurrent(context);

			ALContext currentContext = ALC.GetCurrentContext();
			if (currentContext != IntPtr.Zero)
			{
				ALDevice currentDevice = ALC.GetContextsDevice(currentContext);
				string currentDeviceName = ALC.GetString(currentDevice, AlcGetString.DefaultDeviceSpecifier);
				Console.WriteLine($"Current Audio Device Name: {currentDeviceName}");
			}
			else
			{
				Console.WriteLine("No current context found.");
			}

			// Don't forget to clean up the context and device
			ALC.DestroyContext(context);
			ALC.CloseDevice(device);
		}
		foreach (string device in OpenTK.Audio.OpenAL.ALC.GetString(OpenTK.Audio.OpenAL.AlcGetStringList.AllDevicesSpecifier))
		{
			Console.WriteLine(device);
		}
		Console.WriteLine("Done!");
	}
}
